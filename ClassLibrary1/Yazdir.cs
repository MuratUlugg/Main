using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClassLibrary1
{
    public class Yazdir
    {
        Veri veriBaglanti = new Veri();

        private ListView fisListesi;

        static bool devamiVar = false;
        static int sayfa = 1;
        private string tarih, garson, masa, adisyonNo, mutfakAdi , adisyonAdi;
        private decimal iskonto;
        private List<string> deneme = new List<string>();

        public ListView FisListesi
        {
            set
            {
                this.fisListesi = value;
            }
        }

        public string Tarih
        {
            set
            {
                this.tarih = value;
            }
        }

        public string Garson
        {
            set
            {
                this.garson = value;
            }
        }

        public string Masa
        {
            set
            {
                this.masa = value;
            }
        }

        public string AdisyonNo
        {
            set
            {
                this.adisyonNo = value;
            }
        }

        public decimal Iskonto
        {
            set
            {
                this.iskonto = value;
            }
        }

        public List<String> Deneme
        {
            set
            {
                this.deneme = value;
            }
        }

        public string mutfakAl()
        {
            SqlConnection baglanti = veriBaglanti.getBaglanti();
            SqlCommand komut = new SqlCommand("SELECT TOP(1) * FROM TBLYAZICI WHERE mutfak=1", baglanti);
            SqlDataReader oku; oku = komut.ExecuteReader();
            while (oku.Read())
            {
                mutfakAdi = oku[1].ToString();
            }
            return mutfakAdi;
        }
        public string adisyonAl()
        {
            SqlConnection baglanti = veriBaglanti.getBaglanti();
            SqlCommand komut = new SqlCommand("SELECT TOP(1) * FROM TBLYAZICI WHERE adisyon=1", baglanti);
            SqlDataReader oku; oku = komut.ExecuteReader();
            while (oku.Read())
            {
                adisyonAdi = oku[1].ToString();
            }
            return adisyonAdi;
        }
        public void Fis(object sender, PrintPageEventArgs e)
        {
            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz---- 80,3276

            // Bu sekilde sabit bir printer'a yonlendire biliriz
            //e.PageSettings.PrinterSettings.PrinterName = yaziciAdi;

            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 12);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            e.Graphics.DrawString(veriBaglanti.TabelaAdi, myFont, sbrush, 60, 5);
            e.Graphics.DrawLine(myPen, 0, 25, 200, 25);

            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Near;

            myFont = new Font("Calibri", 9);
            e.Graphics.DrawString("Adisyon No: " + adisyonNo, myFont, sbrush, 0, 30);
            e.Graphics.DrawString("Tarih: " + tarih, myFont, sbrush, 0, 50);

            e.Graphics.DrawString("Masa No: " + masa, myFont, sbrush, 0, 70);
            e.Graphics.DrawString("Garson: " + garson, myFont, sbrush, 0, 90);
            e.Graphics.DrawLine(myPen, 0, 110, 200, 110);

            e.HasMorePages = true;

            myStringFormat.Alignment = StringAlignment.Center;
            myFont = new Font("Calibri", 8, FontStyle.Bold);
            e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 0, 115);
            e.Graphics.DrawString("Adet", myFont, sbrush, 70, 115);
            e.Graphics.DrawString("Birim Fiyatı", myFont, sbrush, 100, 115);
            e.Graphics.DrawString("Tutar", myFont, sbrush, 160, 115);
            e.HasMorePages = true;

            e.Graphics.DrawLine(myPen, 0, 130, 200, 130);

            int y = 140;

            myStringFormat.Alignment = StringAlignment.Near;

            decimal gTotal = 0;

            foreach (ListViewItem lvi in fisListesi.Items)
            {
                e.Graphics.DrawString(lvi.SubItems[0].Text, myFont, sbrush, 0, y, myStringFormat);
                e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 80, y);
                decimal bFiyat = Convert.ToDecimal(lvi.SubItems[2].Text) / Convert.ToDecimal(lvi.SubItems[1].Text);
                decimal fiyat = Convert.ToDecimal(lvi.SubItems[2].Text);
                gTotal += fiyat;
                e.Graphics.DrawString(bFiyat.ToString("c"), myFont, sbrush, 110, y, myStringFormat);
                e.Graphics.DrawString(fiyat.ToString("c"), myFont, sbrush, 160, y, myStringFormat);
                e.HasMorePages = true;

                y += 20;
            }

            e.Graphics.DrawLine(myPen, 0, y, 200, y);

            myStringFormat.Alignment = StringAlignment.Far;
            e.Graphics.DrawString("Ara Toplam : " + gTotal.ToString("c"), myFont, sbrush, 200, y + 10, myStringFormat);
            e.Graphics.DrawString("İndirim Tutarı : " + iskonto.ToString("c"), myFont, sbrush, 200, y + 30, myStringFormat);
            e.Graphics.DrawString("Toplam Tiyat : " + (gTotal - iskonto).ToString("c"), myFont, sbrush, 200, y + 50, myStringFormat);
            e.HasMorePages = false;



            /*Image aImg = Image.FromFile("");

            // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 30 mm yukseklik 42 mm olarak atadik.
            e.Graphics.DrawImage(aImg, 10, 25, 30, 42);*/


            // Her baskida sayfa sayisini artiralim.
            sayfa++;

            // baski 10 sayfa ise son sayfada devami olmayacagini belirtelim.
            if (sayfa == 10)
                devamiVar = false;

            // devami varsa sonraki sayfaya gecelim.
            if (devamiVar)
                e.HasMorePages = true;



        }

        public void Mutfak(object sender, PrintPageEventArgs e)
        {
            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz---- 80,3276

            // Bu sekilde sabit bir printer'a yonlendire biliriz
            //e.PageSettings.PrinterSettings.PrinterName = yaziciAdi;

            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 12);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            e.Graphics.DrawString("GELEN SİPARİŞ", myFont, sbrush, 60, 5);
            e.Graphics.DrawLine(myPen, 0, 25, 200, 25);

            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Near;

            myFont = new Font("Calibri", 9);
            e.Graphics.DrawString("Adisyon No: " + adisyonNo, myFont, sbrush, 0, 30);
            e.Graphics.DrawString("Tarih: " + tarih, myFont, sbrush, 0, 50);
            e.Graphics.DrawString("Masa No: " + masa, myFont, sbrush, 0, 70);
            e.Graphics.DrawString("Garson: " + garson, myFont, sbrush, 0, 90);
            e.Graphics.DrawLine(myPen, 0, 110, 200, 110);

            e.HasMorePages = true;

            myStringFormat.Alignment = StringAlignment.Center;
            myFont = new Font("Calibri", 12, FontStyle.Bold);
            e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 0, 115);
            e.Graphics.DrawString("", myFont, sbrush, 120, 115);
            e.Graphics.DrawString("Adet", myFont, sbrush, 150, 115);

            e.HasMorePages = true;

            e.Graphics.DrawLine(myPen, 0, 140, 200, 140);

            int y = 140;

            myStringFormat.Alignment = StringAlignment.Near;

            foreach (ListViewItem lvi in fisListesi.Items)
            {

                e.Graphics.DrawString(lvi.SubItems[0].Text, myFont, sbrush, 0, y, myStringFormat);
                e.Graphics.DrawString("X", myFont, sbrush, 130, y);
                e.Graphics.DrawString(lvi.SubItems[1].Text, myFont, sbrush, 160, y, myStringFormat);

                e.HasMorePages = true;

                y += 20;
            }

            e.Graphics.DrawLine(myPen, 0, y, 200, y);
            e.HasMorePages = false;


            /*Image aImg = Image.FromFile("");

            // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 30 mm yukseklik 42 mm olarak atadik.
            e.Graphics.DrawImage(aImg, 10, 25, 30, 42);*/


            // Her baskida sayfa sayisini artiralim.
            sayfa++;

            // baski 10 sayfa ise son sayfada devami olmayacagini belirtelim.
            if (sayfa == 10)
                devamiVar = false;

            // devami varsa sonraki sayfaya gecelim.
            if (devamiVar)
                e.HasMorePages = true;

        }

        public void MutfakGuncelle(object sender, PrintPageEventArgs e)
        {
            // Bundan sonra X, Y, Genislik, Yukseklik gibi olculerde
            // Pixel degil Milimetre kullanicahiz---- 80,3276

            // Bu sekilde sabit bir printer'a yonlendire biliriz
            //e.PageSettings.PrinterSettings.PrinterName = yaziciAdi;

            //Yazı fontumu ve çizgi çizmek için fırçamı ve kalem nesnemi oluşturdum
            Font myFont = new Font("Calibri", 12);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            //Bu kısımda sipariş formu yazısını ve çizgileri yazdırıyorum
            e.Graphics.DrawString("GELEN SİPARİŞ", myFont, sbrush, 60, 5);
            e.Graphics.DrawLine(myPen, 0, 25, 200, 25);

            StringFormat myStringFormat = new StringFormat();
            myStringFormat.Alignment = StringAlignment.Near;

            myFont = new Font("Calibri", 9);
            e.Graphics.DrawString("Adisyon No: " + adisyonNo, myFont, sbrush, 0, 30);
            e.Graphics.DrawString("Tarih: " + tarih, myFont, sbrush, 0, 50);
            e.Graphics.DrawString("Masa No: " + masa, myFont, sbrush, 0, 70);
            e.Graphics.DrawString("Garson: " + garson, myFont, sbrush, 0, 90);
            e.Graphics.DrawLine(myPen, 0, 110, 200, 110);

            e.HasMorePages = true;

            myStringFormat.Alignment = StringAlignment.Center;
            myFont = new Font("Calibri", 10, FontStyle.Bold);
            e.Graphics.DrawString("Ürün Adı", myFont, sbrush, 0, 115);
            e.Graphics.DrawString("", myFont, sbrush, 105, 115);
            e.Graphics.DrawString("Adet", myFont, sbrush, 150, 115);

            e.HasMorePages = true;

            e.Graphics.DrawLine(myPen, 0, 140, 200, 140);

            int y = 140;

            myStringFormat.Alignment = StringAlignment.Near;

            foreach (string isim in deneme)
            {
                string[] urun = isim.Split('$');

                e.Graphics.DrawString(urun[0], myFont, sbrush, 0, y, myStringFormat);
                e.Graphics.DrawString("X", myFont, sbrush, 110, y);
                if (Convert.ToInt32(urun[1]) < 0)
                {
                    e.Graphics.DrawString(urun[1]+"\t İPTAL", myFont, sbrush, 130, y, myStringFormat);
                }
                else
                    e.Graphics.DrawString(urun[1], myFont, sbrush, 160, y, myStringFormat);

                e.HasMorePages = true;

                y += 20;
            }

            e.Graphics.DrawLine(myPen, 0, y, 200, y);
            e.HasMorePages = false;

            deneme.Clear();


            /*Image aImg = Image.FromFile("");

            // Resim ekleme sol'dan 10 mm, yukardan 25 mm atliyarak
            // resmi resize etmek isterseniz bunuda bunuda
            // genislik 30 mm yukseklik 42 mm olarak atadik.
            e.Graphics.DrawImage(aImg, 10, 25, 30, 42);*/


            // Her baskida sayfa sayisini artiralim.
            sayfa++;

            // baski 10 sayfa ise son sayfada devami olmayacagini belirtelim.
            if (sayfa == 10)
                devamiVar = false;

            // devami varsa sonraki sayfaya gecelim.
            if (devamiVar)
                e.HasMorePages = true;



        }



    }
}
