using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using ClassLibrary1;
namespace Sale
{
    public partial class UrunSatis : DevExpress.XtraEditors.XtraForm
    {

        PrintDocument pDoc, pDocMutfak;
        Yazdir yazici = new Yazdir();

        public UrunSatis()
        {
            InitializeComponent();

            pDoc = new PrintDocument();
            pDocMutfak = new PrintDocument();

            // Print event'i yaratiliyor.
            pDoc.PrintPage += new PrintPageEventHandler(yazici.Fis);
            pDocMutfak.PrintPage += new PrintPageEventHandler(yazici.Mutfak);

            pDocMutfak.PrinterSettings.PrinterName = yazici.mutfakAl();

            pDoc.PrinterSettings.PrinterName = yazici.adisyonAl();
        }

        Veri veriSinif = new Veri();
        public static string zaman, stokKodu;
        public static int siraNo;
        public static int adet = 0;
        public static decimal toplam = 0, fiyat = 0, iskonto = 0;
        public static TextEdit txtEdit;
        List<string> olanUrunler = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            SqlConnection baglantiTarih = veriSinif.getBaglanti();
            SqlDataReader okuTarih, oku2Sira;
            SqlCommand komutTarih = new SqlCommand("Select TOP(1) tarih from TBLADISYONUST ORDER BY tarih desc", baglantiTarih);
            SqlCommand komutSira = new SqlCommand("Select TOP(1) SIRA_NO FROM TBLADISYONUST ORDER BY a desc", baglantiTarih);
            okuTarih = komutTarih.ExecuteReader(); oku2Sira = komutSira.ExecuteReader();
            string gun = "", ay = "";
            while (okuTarih.Read())
            {

                while (oku2Sira.Read())
                {
                    siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                }
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + DateTime.Now.Day;
                }
                else
                    gun = DateTime.Now.Day.ToString();
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + DateTime.Now.Month;
                }
                else
                    ay = DateTime.Now.Month.ToString();

                //if (okuTarih[0].ToString() != (gun + "." + ay + "." + DateTime.Now.Year.ToString() + " 00:00:00"))
                //{
                //    siraNo = 0;
                //}
                //else
                //{
                //    while (oku2Sira.Read())
                //    {
                //        siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                //    }
                //}
            }
            btnYazdir.Enabled = false;

            grupPanel.Visible = false;
            urunPanel.Visible = false;
            masaPanel.Visible = false;
            masaGrupPanel.Visible = false;

            /*ÜRÜN BUTONLARI KONUM*/
            btnGonder.Location = new Point(12, 7);
            btnIskontoSec.Location = new Point(12, btnGonder.Location.Y + 105);
            btnNakit.Location = new Point(12, btnIskontoSec.Location.Y + 105);
            btnKart.Location = new Point(12, btnNakit.Location.Y + 105);
            btnOdeme.Location = new Point(12, btnKart.Location.Y + 105);
            btnIptal.Location = new Point(12, btnOdeme.Location.Y + 240);

            /*GİRİŞ BUTONLARI KONUM*/
            btnAcikSiparis.Location = new Point(12, 7);
            btnSelfServis.Location = new Point(12, btnAcikSiparis.Location.Y + 105);
            btnMasaServis.Location = new Point(12, btnSelfServis.Location.Y + 105);
            btnMasaDegistir.Location = new Point(12, btnMasaServis.Location.Y + 105);
            btnMasaBirlestir.Location = new Point(12, btnMasaDegistir.Location.Y + 105);
            btnKilitle.Location = new Point(12, btnKilitle.Location.Y + 240);


            txtEdit = txtIskonto;
            txtAraToplam.Text = "0 ₺";
            txtIskonto.Text = "0 ₺";
            /*LİSTVİEW SÜTUN OLUŞTURMA*/
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("Ürün Adı", 160);
            listView1.Columns.Add("Adet", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("Fiyat", 90, HorizontalAlignment.Right);
            listView1.Columns.Add("", 30);
            listView1.Columns.Add("Stok_KODU", 0);

            #region ÜrünKategoriButonları
            SqlConnection baglanti = veriSinif.getBaglanti();
            SqlDataReader oku;
            SqlCommand komut = new SqlCommand("Select * from TBLURUNGRUP", baglanti);
            oku = komut.ExecuteReader();
            int i = 0;
            int top = 5;
            int left = 5;
            while (oku.Read())
            {
                SimpleButton btn = new SimpleButton();
                btn.Text = oku[1].ToString();
                btn.Name = oku[0].ToString();
                btn.Location = new Point(left, top);
                btn.Width = 100;
                btn.Height = 100;
                left += i + 110;
                btn.Click += new EventHandler(grupOlustur);

                grupPanel.Controls.Add(btn);
                i++;
            }
            baglanti.Close();
            #endregion

            #region MasaKategoriButonları
            SqlConnection baglanti2 = veriSinif.getBaglanti();
            SqlDataReader oku2;
            SqlCommand komut2 = new SqlCommand("Select * from TBLMASAGRUP", baglanti2);
            oku2 = komut2.ExecuteReader();
            i = 0;
            top = 5;
            left = 5;
            while (oku2.Read())
            {
                SimpleButton btnMasagrup = new SimpleButton();
                btnMasagrup.Text = oku2[1].ToString();
                btnMasagrup.Name = oku2[0].ToString();
                btnMasagrup.Location = new Point(left, top);
                btnMasagrup.Width = 100;
                btnMasagrup.Height = 100;
                left += i + 110;
                btnMasagrup.Click += new EventHandler(masaGrupOlustur);
                masaGrupPanel.Controls.Add(btnMasagrup);
                i++;
            }
            baglanti2.Close();
            #endregion
        }

        #region ÜrünButonları
        private void grupOlustur(object sender, EventArgs e)
        {
            SqlConnection baglanti = veriSinif.getBaglanti();
            urunPanel.Controls.Clear();
            SqlDataReader oku;
            SqlDataReader urunGrup;
            SqlCommand komut = new SqlCommand("Select * from TBLURUNGRUP", baglanti);
            SqlCommand urunListesi = new SqlCommand("Select * from TBLURUN where GRUP_ID=" + ((SimpleButton)sender).Name.ToString(), baglanti);
            oku = komut.ExecuteReader();
            urunGrup = urunListesi.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == ((SimpleButton)sender).Name.ToString())
                {
                    int top = 5;
                    int left = 5;
                    while (urunGrup.Read())
                    {
                        SimpleButton btn2 = new SimpleButton();
                        btn2.Text = urunGrup[2].ToString() + "\n\n" + Decimal.Round(Convert.ToDecimal(urunGrup[6].ToString()), 2).ToString() + " ₺";
                        btn2.Name = urunGrup[0].ToString();
                        btn2.Tag = Convert.ToDecimal(urunGrup[6].ToString());
                        btn2.Location = new Point(left, top);
                        btn2.Width = 100;
                        btn2.Height = 100;
                        left += 110;
                        if ((left + 100) >= sagPanel.Location.X - 400)
                        {
                            top += 109; left = 5;
                        }
                        btn2.Click += new EventHandler(urunEkle);

                        urunPanel.Controls.Add(btn2);

                    }
                }
            }
            baglanti.Close();
        }

        private void urunEkle(object sender, EventArgs e)
        {
            string[] urunAdiAlma = ((SimpleButton)sender).Text.Split('\n');

            Boolean esitmi = false;
            fiyat = Convert.ToDecimal(((SimpleButton)sender).Tag.ToString());
            fiyat = Decimal.Round(fiyat, 2);

            adet = 1;
            if (listView1.Items.Count > 0)
            {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (urunAdiAlma[0] == listView1.Items[i].SubItems[0].Text)
                    {
                        esitmi = true;
                        adet = Convert.ToInt32(listView1.Items[i].SubItems[1].Text) + 1;
                        listView1.Items.RemoveAt(i);
                        break;
                    }
                    else esitmi = false;
                }
                if (esitmi == false || adet > 1)
                {
                    string[] bilgiler = { urunAdiAlma[0], adet.ToString(), (fiyat * Convert.ToDecimal(adet)).ToString(), " ₺", ((SimpleButton)sender).Name };
                    listView1.Items.Add(new ListViewItem(bilgiler));
                    toplam = toplam + fiyat;
                }
            }
            else
            {
                string[] bilgiler = { urunAdiAlma[0], adet.ToString(), (fiyat * Convert.ToDecimal(adet)).ToString(), " ₺", ((SimpleButton)sender).Name };
                listView1.Items.Add(new ListViewItem(bilgiler));
                toplam = toplam + fiyat;
            }
            txtAraToplam.Text = toplam.ToString() + " ₺";

        }
        #endregion

        #region MasaButonları
        private void masaGrupOlustur(object sender, EventArgs e)
        {
            acikMasaPanel.Visible = false;
            masaPanel.Visible = true;
            SqlConnection baglanti = veriSinif.getBaglanti();
            masaPanel.Controls.Clear();
            SqlDataReader oku;
            SqlDataReader masaGrup;
            SqlCommand komut = new SqlCommand("Select * from TBLMASAGRUP", baglanti);
            SqlCommand masaListesi = new SqlCommand("Select * from TBLMASALISTE where grup_id=" + ((SimpleButton)sender).Name.ToString(), baglanti);

            oku = komut.ExecuteReader();
            masaGrup = masaListesi.ExecuteReader();
            while (oku.Read())
            {
                if (oku[0].ToString() == ((SimpleButton)sender).Name.ToString())
                {
                    int top = 5;
                    int left = 5;
                    while (masaGrup.Read())
                    {
                        bool masaKontrol = false;
                        SimpleButton btnMasa = new SimpleButton();
                        btnMasa.Text = masaGrup[1].ToString();
                        btnMasa.Name = masaGrup[0].ToString();
                        btnMasa.Location = new Point(left, top);
                        btnMasa.Width = 100;
                        btnMasa.Height = 100;
                        left += 110;
                        if ((left + 100) >= sagPanel.Location.X - 400)
                        {
                            top += 109; left = 5;
                        }
                        SqlCommand acikMasaOlusturmaKontrol = new SqlCommand("SELECT adisyonno,masano,yekun,garson FROM TBLADISYONUST WHERE DURUM=-1", baglanti);
                        SqlDataReader acikMasaOlusturmaKontrolOku = acikMasaOlusturmaKontrol.ExecuteReader();
                        while (acikMasaOlusturmaKontrolOku.Read())
                        {
                            if (btnMasa.Text == acikMasaOlusturmaKontrolOku[1].ToString())
                            {
                                masaKontrol = true;
                                break;
                            }
                        }
                        if (masaKontrol == true)
                        {
                            btnMasa.Text = acikMasaOlusturmaKontrolOku[0].ToString() + "\n" + acikMasaOlusturmaKontrolOku[1].ToString() + "\n" + Decimal.Round(Convert.ToDecimal(acikMasaOlusturmaKontrolOku[2].ToString()), 2) + " ₺\n" + acikMasaOlusturmaKontrolOku[3].ToString();
                            btnMasa.Font = new Font(btnMasa.Font.FontFamily, 12);
                            btnMasa.Name = acikMasaOlusturmaKontrolOku[0].ToString();
                            btnMasa.Click += new EventHandler(acikMasaGetir);
                            masaPanel.Controls.Add(btnMasa);
                        }
                        else
                        {
                            btnMasa.Click += new EventHandler(masaGir);
                            masaPanel.Controls.Add(btnMasa);
                        }
                    }
                }
            }
            baglanti.Close();
        }

        private void masaGir(object sender, EventArgs e)
        {
            masaPanel.Visible = false;
            masaGrupPanel.Visible = false;
            urunPanel.Visible = true;
            grupPanel.Visible = true;
            sagGirisPanel.Visible = false;
            sagUrunPanel.Visible = true;
            acikMasaPanel.Visible = false;

            #region NormalMasa
            SqlConnection baglantiTarih = veriSinif.getBaglanti();
            SqlDataReader okuTarih, oku2Sira;
            SqlCommand komutTarih = new SqlCommand("Select TOP(1) tarih from TBLADISYONUST ORDER BY tarih desc", baglantiTarih);
            SqlCommand komutSira = new SqlCommand("Select TOP(1) SIRA_NO FROM TBLADISYONUST ORDER BY a desc", baglantiTarih);
            okuTarih = komutTarih.ExecuteReader(); oku2Sira = komutSira.ExecuteReader();
            string gun = "",ay="";
            while (okuTarih.Read())
            {
                while (oku2Sira.Read())
                {
                    siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                }
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + DateTime.Now.Day;
                }
                else
                    gun = DateTime.Now.Day.ToString();
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + DateTime.Now.Month;
                }
                else
                    ay = DateTime.Now.Month.ToString();

                //if (okuTarih[0].ToString() != (gun + "." + ay + "." + DateTime.Now.Year.ToString() + " 00:00:00"))
                //{
                //    siraNo = 0;
                //}
                //else
                //{
                //    while (oku2Sira.Read())
                //    {
                //        siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                //    }
                //}
            }
            baglantiTarih.Close();
            lblAcilisZamani.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            lblMasaNo.Text = ((SimpleButton)sender).Text;
            lblGarson.Text = Giris.kullanici;
            //Adisyon
            lblAdisyonNo.Text = "A" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + siraNo;
            #endregion




        }
        #endregion

        #region ListView
        private void btnArttir_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count > 0)
            {
                //Listboxtaki verileri bölüp değişkenlere atama işlemi.
                adet = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
                string isim = listView1.SelectedItems[0].SubItems[0].Text;
                fiyat = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[2].Text) / Convert.ToDecimal(adet);
                fiyat = Decimal.Round(fiyat, 2);
                stokKodu = listView1.SelectedItems[0].SubItems[4].Text;

                //Veriyi listedeki yerinden silmek.
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                adet++;
                //veriyi tekrar ekleyerek güncellemek
                string[] bilgiler = { isim, adet.ToString(), (fiyat * Convert.ToDecimal(adet)).ToString(), " ₺", stokKodu };
                listView1.Items.Add(new ListViewItem(bilgiler));
                toplam = toplam + fiyat;

                //Son işlem yapılan elemanı seçme
                listView1.Items[listView1.Items.Count - 1].Selected = true;
                listView1.Items[listView1.Items.Count - 1].BackColor = ColorTranslator.FromHtml("#0078d7");
                listView1.Items[listView1.Items.Count - 1].ForeColor = Color.White;

            }
            else
            {
                MessageBox.Show("Abi Adisyondan Ürün Seçmelisin");
            }
            txtAraToplam.Text = toplam.ToString() + " ₺";

        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                //Listboxtaki verileri bölüp değişkenlere atama işlemi.
                adet = Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text);
                string isim = listView1.SelectedItems[0].SubItems[0].Text;
                fiyat = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[2].Text) / Convert.ToDecimal(adet);
                fiyat = Decimal.Round(fiyat, 2);
                stokKodu = listView1.SelectedItems[0].SubItems[4].Text;

                if (adet > 1)
                {
                    adet--;
                    toplam = toplam - fiyat;
                    listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                    string[] bilgiler = { isim, adet.ToString(), (fiyat * Convert.ToDecimal(adet)).ToString(), " ₺", stokKodu };
                    listView1.Items.Add(new ListViewItem(bilgiler));

                    //Son işlem yapılan elemanı seçme
                    listView1.Items[listView1.Items.Count - 1].Selected = true;
                    listView1.Items[listView1.Items.Count - 1].BackColor = ColorTranslator.FromHtml("#0078d7");
                    listView1.Items[listView1.Items.Count - 1].ForeColor = Color.White;
                }
                else
                {
                    listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                    toplam = toplam - fiyat;
                }
            }
            else
            {
                MessageBox.Show("Abi Adisyondan Ürün Seçmelisin");
            }
            txtAraToplam.Text = toplam.ToString() + " ₺";

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items[listView1.Items.Count - 1].BackColor = Color.White;
            listView1.Items[listView1.Items.Count - 1].ForeColor = Color.Black;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DialogResult secenek = MessageBox.Show("Adisyonu temizlemek istediğinize emin misiniz?", "Adisyon Boşaltma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (secenek == DialogResult.Yes)
                {
                    toplam = 0;
                    iskonto = 0;
                    listView1.Items.Clear();
                    MessageBox.Show("Adisyon tertemiz.");
                    txtAraToplam.Text = "0 ₺";
                    txtIskonto.Text = "0 ₺";
                    txtGenelToplam.Text = "0 ₺";
                }
                else
                {
                    MessageBox.Show("Temizlikten vazgeçtiniz.");
                }
            }
            else
            {
                MessageBox.Show("Adisyon zaten boş.");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0 && listView1.SelectedItems.Count == 1)
            {
                DialogResult secenek = MessageBox.Show("Bu ürünü adisyondan kaldırmak istediğinize emin misiniz?", "Ürün Silme Kontrolü", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secenek == DialogResult.Yes)
                {
                    fiyat = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[2].Text);
                    fiyat = Decimal.Round(fiyat, 2);
                    toplam = toplam - fiyat;

                    listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
                    MessageBox.Show("Ürün silindi");
                }
                else
                {
                    MessageBox.Show("Ürünü silmekten vazgeçtiniz.");
                }
            }
            else
            {
                MessageBox.Show("Ürün seçilmediği için silme işlemi yapılamaz.");
            }

            txtAraToplam.Text = toplam.ToString() + " ₺";

        }
        #endregion

        #region GenelToplam
        private void txtAraToplam_TextChanged(object sender, EventArgs e)
        {
            if (iskonto == 0)
                txtGenelToplam.Text = toplam.ToString() + " ₺";
            else
                txtGenelToplam.Text = Decimal.Round((toplam - iskonto), 2).ToString() + " ₺";
        }

        private void txtIskontoIptal_Click(object sender, EventArgs e)
        {
            iskonto = 0;
            txtIskonto.Text = "0 ₺";
        }

        private void txtIskonto_TextChanged(object sender, EventArgs e)
        {
            txtGenelToplam.Text = Decimal.Round((toplam - iskonto), 2).ToString() + " ₺";
        }
        #endregion

        #region ÜrünButonları
        private void btnIptal_Click(object sender, EventArgs e)
        {
            masaPanel.Visible = false;
            masaGrupPanel.Visible = true;
            urunPanel.Visible = false;
            grupPanel.Visible = false;
            sagUrunPanel.Visible = false;
            sagGirisPanel.Visible = true;
            btnYazdir.Enabled = false;

            txtAraToplam.Text = "";
            txtIskonto.Text = "";
            txtGenelToplam.Text = "";
            lblAcilisZamani.Text = "";
            lblMasaNo.Text = "";
            lblAdisyonNo.Text = "";
            lblGarson.Text = "";
            lblSonİslem.Text = "";
            listView1.Items.Clear();
            toplam = 0; iskonto = 0; fiyat = 0; adet = 0;

        }

        private void btnGonder_Click(object sender, EventArgs e)
        {

            string gelenNo = "";
            if (listView1.Items.Count > 0)
            {
                SqlConnection baglanti = veriSinif.getBaglanti();
                SqlDataReader birimOku;
                bool kayitKontrol = false;
                #region AçıkMasaAdisyonAlma
                SqlCommand acikMasaKontrol = new SqlCommand("select adisyonno from TBLADISYONUST", baglanti);
                SqlDataReader acikMasaKontrolOku = acikMasaKontrol.ExecuteReader();
                while (acikMasaKontrolOku.Read())
                {
                    if (lblAdisyonNo.Text == acikMasaKontrolOku[0].ToString())
                    {
                        gelenNo = acikMasaKontrolOku[0].ToString();
                        break;
                    }
                }
                #endregion
                /*Yeni Masa İşlemleri*/
                if (gelenNo == "")
                {
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        SqlCommand komut = new SqlCommand("insert into TBLADISYON (tarih,masa,garson,adisyonno,urunadi,birim,miktari,birimfiyati,durum) VALUES (@tarih,@masaNo,@garsonAdi,@adisyonNo,@urunAdi,@birim,@miktar,@birimFiyat,@durum)", baglanti);
                        SqlCommand birimkomutu = new SqlCommand("SELECT  BRM1 FROM TBLURUN WHERE STOK_KODU='" + listView1.Items[i].SubItems[4].Text + "'", baglanti);

                        komut.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                        komut.Parameters.AddWithValue("@masaNo", lblMasaNo.Text);
                        komut.Parameters.AddWithValue("@garsonAdi", lblGarson.Text);
                        komut.Parameters.AddWithValue("@adisyonNo", lblAdisyonNo.Text);
                        komut.Parameters.AddWithValue("@urunAdi", listView1.Items[i].SubItems[0].Text);

                        birimOku = birimkomutu.ExecuteReader();
                        while (birimOku.Read())
                        {
                            komut.Parameters.AddWithValue("@birim", birimOku[0].ToString());
                        }
                        komut.Parameters.AddWithValue("@miktar", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                        komut.Parameters.AddWithValue("@birimFiyat", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[2].Text) / Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                        komut.Parameters.AddWithValue("@durum", "-1");

                        if (komut.ExecuteNonQuery() > 0)
                            kayitKontrol = true;
                    }
                    if (kayitKontrol == true)
                    {
                        SqlCommand komutAdsUst = new SqlCommand("insert into TBLADISYONUST (tarih,masano,garson,adisyonno,tutar,indirim,yekun,durum,Odeme,MASA_ACAN,SIRA_NO)VALUES(@tarih,@masano,@garson,@adisyonno,@tutar,@indirim,@yekun,@durum,@odeme,@MASA_ACAN,@SIRA_NO)", baglanti);
                        komutAdsUst.Parameters.AddWithValue("@tarih", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
                        komutAdsUst.Parameters.AddWithValue("@masano", lblMasaNo.Text);
                        komutAdsUst.Parameters.AddWithValue("@garson", Giris.kullanici);
                        komutAdsUst.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                        komutAdsUst.Parameters.AddWithValue("@tutar", toplam);
                        komutAdsUst.Parameters.AddWithValue("@indirim", iskonto);
                        komutAdsUst.Parameters.AddWithValue("@yekun", toplam - iskonto);
                        komutAdsUst.Parameters.AddWithValue("@durum", "-1");
                        komutAdsUst.Parameters.AddWithValue("@odeme", 0);
                        komutAdsUst.Parameters.AddWithValue("@MASA_ACAN", Giris.kullanici);
                        komutAdsUst.Parameters.AddWithValue("@SIRA_NO", siraNo);
                        komutAdsUst.ExecuteNonQuery();


                        pDocMutfak.PrintPage -= new PrintPageEventHandler(yazici.MutfakGuncelle);
                        pDocMutfak.PrintPage += new PrintPageEventHandler(yazici.Mutfak);

                        yazici.FisListesi = listView1;
                        yazici.AdisyonNo = lblAdisyonNo.Text;
                        yazici.Masa = lblMasaNo.Text;
                        yazici.Tarih = lblAcilisZamani.Text;
                        yazici.Garson = lblGarson.Text;
                        yazici.Iskonto = iskonto;
                        pDocMutfak.Print();

                        btnIptal.PerformClick();
                    }

                }
                /*Açık Masa İşlemleri*/
                else
                {
                    List<string> deneme = new List<string>();
                    deneme.Clear();

                    int anahtar = 0;/*Açık masa Adet Güncelleme */
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        SqlCommand acikMasaUrunKontrol = new SqlCommand("Select * from TBLADISYON where adisyonno='" + gelenNo + "'", baglanti);
                        SqlDataReader acikMasaUrunKontrolOku;
                        acikMasaUrunKontrolOku = acikMasaUrunKontrol.ExecuteReader();

                        while (acikMasaUrunKontrolOku.Read())
                        {
                            if (listView1.Items[i].SubItems[0].Text == acikMasaUrunKontrolOku[4].ToString())
                            {
                                if (listView1.Items[i].SubItems[1].Text != acikMasaUrunKontrolOku[6].ToString())
                                {

                                    int fark = Convert.ToInt32(listView1.Items[i].SubItems[1].Text) - Convert.ToInt32(acikMasaUrunKontrolOku[6].ToString());

                                    deneme.Add(listView1.Items[i].SubItems[0].Text + "$" + fark.ToString());

                                    anahtar = Convert.ToInt32(acikMasaUrunKontrolOku[15].ToString());
                                    SqlCommand acikUrunGuncelle = new SqlCommand("UPDATE TBLADISYON SET miktari=" + Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2) + " where anahtar=" + anahtar, baglanti);

                                    string sorgum = "UPDATE TBLADISYONUST SET tutar=@toplam, garson=@garson, indirim=@iskonto, yekun=@yekun where adisyonno=@gelen";
                                    SqlCommand acikUrunUstGuncelle = new SqlCommand(); acikUrunUstGuncelle.Connection = baglanti;
                                    acikUrunUstGuncelle.CommandText = sorgum;
                                    acikUrunUstGuncelle.Parameters.AddWithValue("@toplam", toplam);
                                    acikUrunUstGuncelle.Parameters.AddWithValue("@garson", lblGarson.Text);
                                    acikUrunUstGuncelle.Parameters.AddWithValue("@iskonto", iskonto);
                                    acikUrunUstGuncelle.Parameters.AddWithValue("@yekun", toplam - iskonto);
                                    acikUrunUstGuncelle.Parameters.AddWithValue("@gelen", gelenNo);
                                    acikUrunUstGuncelle.ExecuteNonQuery();

                                    acikUrunGuncelle.ExecuteNonQuery();
                                    acikUrunUstGuncelle.ExecuteNonQuery();

                                }
                            }
                        }
                    }

                    /*Açık Masa Yeni ürün ekleme*/
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        bool deger = false;
                        SqlCommand acikMasaKontrol1 = new SqlCommand("SELECT urunadi FROM TBLADISYON WHERE adisyonno='" + gelenNo + "'", baglanti);
                        SqlDataReader acikMasaKontrol12;
                        acikMasaKontrol12 = acikMasaKontrol1.ExecuteReader();
                        while (acikMasaKontrol12.Read())
                        {
                            if (listView1.Items[i].SubItems[0].Text == acikMasaKontrol12[0].ToString())
                            {
                                deger = false;
                                break;
                            }
                            else
                                deger = true;
                        }
                        if (deger == true)
                        {
                            SqlCommand acikMasaYeniUrunEkle = new SqlCommand("INSERT INTO TBLADISYON (tarih,masa,garson,adisyonno,urunadi,birim,miktari,birimfiyati,durum) VALUES (@tarih,@masaNo,@garsonAdi,@adisyonNo,@urunAdi,@birim,@miktar,@birimFiyat,@durum)", baglanti);
                            SqlCommand acikMasaBirimKomutu = new SqlCommand("SELECT BRM1 FROM TBLURUN WHERE STOK_KODU='" + listView1.Items[i].SubItems[4].Text + "'", baglanti);
                            SqlDataReader acikMasaBirimOku;
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@masaNo", lblMasaNo.Text);
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@garsonAdi", lblGarson.Text);
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@adisyonNo", gelenNo);
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@urunAdi", listView1.Items[i].SubItems[0].Text);

                            acikMasaBirimOku = acikMasaBirimKomutu.ExecuteReader();
                            while (acikMasaBirimOku.Read())
                            {
                                acikMasaYeniUrunEkle.Parameters.AddWithValue("@birim", acikMasaBirimOku[0].ToString());
                            }
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@miktar", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@birimFiyat", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[2].Text) / Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                            acikMasaYeniUrunEkle.Parameters.AddWithValue("@durum", "-1");
                            acikMasaYeniUrunEkle.ExecuteNonQuery();

                            string sorgum = "UPDATE TBLADISYONUST SET tutar=@toplam, garson=@garson, indirim=@iskonto, yekun=@yekun where adisyonno=@gelen";
                            SqlCommand acikUrunUstGuncelle = new SqlCommand(); acikUrunUstGuncelle.Connection = baglanti;
                            acikUrunUstGuncelle.CommandText = sorgum;
                            acikUrunUstGuncelle.Parameters.AddWithValue("@toplam", toplam);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@garson", lblGarson.Text);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@iskonto", iskonto);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@yekun", toplam - iskonto);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@gelen", gelenNo);
                            acikUrunUstGuncelle.ExecuteNonQuery();

                            acikUrunUstGuncelle.ExecuteNonQuery();

                            deneme.Add(listView1.Items[i].SubItems[0].Text + "$" + listView1.Items[i].SubItems[1].Text);

                        }

                    }

                    /*Açık Masa Ürün Silme*/
                    #region Açıkmasa ürün silme
                    olanUrunler.Clear();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        SqlCommand acikMasaUrunSecme = new SqlCommand("SELECT urunadi FROM TBLADISYON WHERE adisyonno='" + gelenNo + "'", baglanti);
                        SqlDataReader acikMasaUrunSilmeKontrol; acikMasaUrunSilmeKontrol = acikMasaUrunSecme.ExecuteReader();

                        while (acikMasaUrunSilmeKontrol.Read())
                        {
                            if (listView1.Items[i].SubItems[0].Text == acikMasaUrunSilmeKontrol[0].ToString())
                            {
                                olanUrunler.Add(acikMasaUrunSilmeKontrol[0].ToString());
                            }
                        }
                    }
                    SqlCommand olmayanUrunBul = new SqlCommand("SELECT urunadi,anahtar,miktari FROM TBLADISYON WHERE adisyonno='" + gelenNo + "'", baglanti);
                    SqlDataReader olmayanOku;
                    olmayanOku = olmayanUrunBul.ExecuteReader();
                    while (olmayanOku.Read())
                    {
                        if (!olanUrunler.Contains(olmayanOku[0].ToString()))
                        {
                            deneme.Add(olmayanOku[0].ToString() + "$-" + olmayanOku[2].ToString());

                            SqlCommand acikMasaUrunSil = new SqlCommand("delete from TBLADISYON where urunadi='" + olmayanOku[0].ToString() + "'", baglanti);
                            acikMasaUrunSil.ExecuteNonQuery();

                            string sorgum = "UPDATE TBLADISYONUST SET tutar=@toplam, garson=@garson, indirim=@iskonto, yekun=@yekun where adisyonno=@gelen";
                            SqlCommand acikUrunUstGuncelle = new SqlCommand(); acikUrunUstGuncelle.Connection = baglanti;
                            acikUrunUstGuncelle.CommandText = sorgum;
                            acikUrunUstGuncelle.Parameters.AddWithValue("@toplam", toplam);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@garson", lblGarson.Text);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@iskonto", iskonto);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@yekun", toplam - iskonto);
                            acikUrunUstGuncelle.Parameters.AddWithValue("@gelen", gelenNo);
                            acikUrunUstGuncelle.ExecuteNonQuery();

                        }
                    }
                    #endregion

                    string iskontoUstGuncelle = "UPDATE TBLADISYONUST SET indirim=@iskonto, yekun=@yekun where adisyonno=@gelen";
                    SqlCommand adsUstGuncelle = new SqlCommand(); adsUstGuncelle.Connection = baglanti;
                    adsUstGuncelle.CommandText = iskontoUstGuncelle;
                    adsUstGuncelle.Parameters.AddWithValue("@iskonto", iskonto);
                    adsUstGuncelle.Parameters.AddWithValue("@yekun", toplam - iskonto);
                    adsUstGuncelle.Parameters.AddWithValue("@gelen", gelenNo);
                    adsUstGuncelle.ExecuteNonQuery();
                    adsUstGuncelle.Dispose();


                    pDocMutfak.PrintPage -= new PrintPageEventHandler(yazici.Mutfak);
                    pDocMutfak.PrintPage += new PrintPageEventHandler(yazici.MutfakGuncelle);

                    yazici.Deneme = deneme;
                    yazici.AdisyonNo = lblAdisyonNo.Text;
                    yazici.Masa = lblMasaNo.Text;
                    yazici.Tarih = lblAcilisZamani.Text;
                    yazici.Garson = lblGarson.Text;
                    yazici.Iskonto = iskonto;
                    if (deneme.Count > 0)
                        pDocMutfak.Print();

                }
                btnIptal.PerformClick();

                baglanti.Close();
            }
            else
                MessageBox.Show("Adisyonda Ürün Yok");


        }

        private void btnIskontoSec_Click(object sender, EventArgs e)
        {
            IskontoGiris iskontoGiris = new IskontoGiris();
            iskontoGiris.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "UluPOS\t\t" + " Kullanıcı:  " + Giris.kullanici + "\t\t" + DateTime.Now.ToLongTimeString() + "  " + DateTime.Now.ToLongDateString();
            zaman = DateTime.Now.ToLongTimeString();

        }

        private void btnNakit_Click(object sender, EventArgs e)
        {
            string gelenNo = "";
            if (listView1.Items.Count > 0)
            {
                SqlConnection baglanti = veriSinif.getBaglanti();
                #region AçıkMasaAdisyonAlma
                SqlCommand acikMasaKontrol = new SqlCommand("select adisyonno from TBLADISYONUST WHERE DURUM=-1 ", baglanti);
                SqlDataReader acikMasaKontrolOku = acikMasaKontrol.ExecuteReader();
                while (acikMasaKontrolOku.Read())
                {
                    if (lblAdisyonNo.Text == acikMasaKontrolOku[0].ToString())
                    {
                        gelenNo = acikMasaKontrolOku[0].ToString();
                        break;
                    }
                }
                #endregion
                DialogResult secenek = MessageBox.Show("Ödeme nakit alınacak onaylıyor musunuz?", "Nakit Ödeme", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (secenek == DialogResult.OK)
                {
                    /*Yeni Masa İşlemleri*/
                    if (gelenNo == "")
                    {
                        if (lblMasaNo.Text.Contains("Self-Servis"))
                        {
                            SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                            nakitOdeme.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                            nakitOdeme.Parameters.AddWithValue("@odeme", 1);
                            nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                            nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                            nakitOdeme.Parameters.AddWithValue("@selfServis", true);
                            nakitOdeme.ExecuteNonQuery();
                            btnYazdir.PerformClick();
                        }
                        else
                        {
                            SqlDataReader birimOku;
                            bool kayitKontrol = false;
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                SqlCommand komut = new SqlCommand("insert into TBLADISYON (tarih,masa,garson,adisyonno,urunadi,birim,miktari,birimfiyati,durum) VALUES (@tarih,@masaNo,@garsonAdi,@adisyonNo,@urunAdi,@birim,@miktar,@birimFiyat,@durum)", baglanti);
                                SqlCommand birimkomutu = new SqlCommand("SELECT  BRM1 FROM TBLURUN WHERE STOK_KODU=" + listView1.Items[i].SubItems[4].Text, baglanti);

                                komut.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                                komut.Parameters.AddWithValue("@masaNo", lblMasaNo.Text);
                                komut.Parameters.AddWithValue("@garsonAdi", lblGarson.Text);
                                komut.Parameters.AddWithValue("@adisyonNo", lblAdisyonNo.Text);
                                komut.Parameters.AddWithValue("@urunAdi", listView1.Items[i].SubItems[0].Text);

                                birimOku = birimkomutu.ExecuteReader();
                                while (birimOku.Read())
                                {
                                    komut.Parameters.AddWithValue("@birim", birimOku[0].ToString());
                                }
                                komut.Parameters.AddWithValue("@miktar", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                                komut.Parameters.AddWithValue("@birimFiyat", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[2].Text) / Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                                komut.Parameters.AddWithValue("@durum", "-1");

                                if (komut.ExecuteNonQuery() > 0)
                                    kayitKontrol = true;
                            }
                            if (kayitKontrol == true)
                            {
                                SqlCommand komutAdsUst = new SqlCommand("insert into TBLADISYONUST (tarih,masano,garson,adisyonno,tutar,indirim,yekun,durum,Odeme,MASA_ACAN,SIRA_NO)VALUES(@tarih,@masano,@garson,@adisyonno,@tutar,@indirim,@yekun,@durum,@odeme,@MASA_ACAN,@SIRA_NO)", baglanti);
                                komutAdsUst.Parameters.AddWithValue("@tarih", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
                                komutAdsUst.Parameters.AddWithValue("@masano", lblMasaNo.Text);
                                komutAdsUst.Parameters.AddWithValue("@garson", Giris.kullanici);
                                komutAdsUst.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                                komutAdsUst.Parameters.AddWithValue("@tutar", toplam);
                                komutAdsUst.Parameters.AddWithValue("@indirim", iskonto);
                                komutAdsUst.Parameters.AddWithValue("@yekun", toplam - iskonto);
                                komutAdsUst.Parameters.AddWithValue("@durum", "0");
                                komutAdsUst.Parameters.AddWithValue("@odeme", 1);
                                komutAdsUst.Parameters.AddWithValue("@MASA_ACAN", Giris.kullanici);
                                komutAdsUst.Parameters.AddWithValue("@SIRA_NO", siraNo);
                                komutAdsUst.ExecuteNonQuery();

                                SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                                nakitOdeme.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                                nakitOdeme.Parameters.AddWithValue("@odeme", 1);
                                nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                                nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                                nakitOdeme.Parameters.AddWithValue("@selfServis", false);
                                nakitOdeme.ExecuteNonQuery();

                                btnIptal.PerformClick();
                            }
                        }

                    }
                    /*Açık Masa İşlemleri*/
                    else
                    {
                        SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                        nakitOdeme.Parameters.AddWithValue("@adisyonno", gelenNo);
                        nakitOdeme.Parameters.AddWithValue("@odeme", 1);
                        nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                        nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                        nakitOdeme.Parameters.AddWithValue("@selfServis", false);
                        int onay = nakitOdeme.ExecuteNonQuery();
                        if (onay > 0)
                        {
                            SqlCommand adisyonUstDurum = new SqlCommand("UPDATE TBLADISYONUST SET durum=@durum WHERE adisyonno='" + gelenNo + "'", baglanti);
                            adisyonUstDurum.Parameters.AddWithValue("@durum", 0);
                            adisyonUstDurum.ExecuteNonQuery();
                            btnYazdir.PerformClick();
                        }

                    }
                    btnIptal.PerformClick();

                    baglanti.Close();
                }
                else
                    MessageBox.Show("İşlem yapılmadı");
            }
            else
                MessageBox.Show("Adisyonda Ürün Yok");
        }

        private void btnKart_Click(object sender, EventArgs e)
        {
            string gelenNo = "";
            if (listView1.Items.Count > 0)
            {
                SqlConnection baglanti = veriSinif.getBaglanti();
                #region AçıkMasaAdisyonAlma
                SqlCommand acikMasaKontrol = new SqlCommand("select adisyonno from TBLADISYONUST WHERE DURUM=-1 ", baglanti);
                SqlDataReader acikMasaKontrolOku = acikMasaKontrol.ExecuteReader();
                while (acikMasaKontrolOku.Read())
                {
                    if (lblAdisyonNo.Text == acikMasaKontrolOku[0].ToString())
                    {
                        gelenNo = acikMasaKontrolOku[0].ToString();
                        break;
                    }
                }
                #endregion
                DialogResult secenek = MessageBox.Show("Ödeme kredi kartı ile alınacak onaylıyor musunuz?", "Kredi Kartı Ödemesi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (secenek == DialogResult.OK)
                {
                    /*Yeni Masa İşlemleri*/
                    if (gelenNo == "")
                    {
                        if (lblMasaNo.Text.Contains("Self-Servis"))
                        {
                            SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                            nakitOdeme.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                            nakitOdeme.Parameters.AddWithValue("@odeme", 2);
                            nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                            nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                            nakitOdeme.Parameters.AddWithValue("@selfServis", true);
                            nakitOdeme.ExecuteNonQuery();
                            btnYazdir.PerformClick();
                        }
                        else
                        {
                            SqlDataReader birimOku;
                            bool kayitKontrol = false;
                            for (int i = 0; i < listView1.Items.Count; i++)
                            {
                                SqlCommand komut = new SqlCommand("insert into TBLADISYON (tarih,masa,garson,adisyonno,urunadi,birim,miktari,birimfiyati,durum) VALUES (@tarih,@masaNo,@garsonAdi,@adisyonNo,@urunAdi,@birim,@miktar,@birimFiyat,@durum)", baglanti);
                                SqlCommand birimkomutu = new SqlCommand("SELECT  BRM1 FROM TBLURUN WHERE STOK_KODU=" + listView1.Items[i].SubItems[4].Text, baglanti);

                                komut.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                                komut.Parameters.AddWithValue("@masaNo", lblMasaNo.Text);
                                komut.Parameters.AddWithValue("@garsonAdi", lblGarson.Text);
                                komut.Parameters.AddWithValue("@adisyonNo", lblAdisyonNo.Text);
                                komut.Parameters.AddWithValue("@urunAdi", listView1.Items[i].SubItems[0].Text);

                                birimOku = birimkomutu.ExecuteReader();
                                while (birimOku.Read())
                                {
                                    komut.Parameters.AddWithValue("@birim", birimOku[0].ToString());
                                }
                                komut.Parameters.AddWithValue("@miktar", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                                komut.Parameters.AddWithValue("@birimFiyat", Decimal.Round(Convert.ToDecimal(listView1.Items[i].SubItems[2].Text) / Convert.ToDecimal(listView1.Items[i].SubItems[1].Text), 2));
                                komut.Parameters.AddWithValue("@durum", "-1");

                                if (komut.ExecuteNonQuery() > 0)
                                    kayitKontrol = true;
                            }
                            if (kayitKontrol == true)
                            {
                                SqlCommand komutAdsUst = new SqlCommand("insert into TBLADISYONUST (tarih,masano,garson,adisyonno,tutar,indirim,yekun,durum,Odeme,MASA_ACAN,SIRA_NO)VALUES(@tarih,@masano,@garson,@adisyonno,@tutar,@indirim,@yekun,@durum,@odeme,@MASA_ACAN,@SIRA_NO)", baglanti);
                                komutAdsUst.Parameters.AddWithValue("@tarih", DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day);
                                komutAdsUst.Parameters.AddWithValue("@masano", lblMasaNo.Text);
                                komutAdsUst.Parameters.AddWithValue("@garson", Giris.kullanici);
                                komutAdsUst.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                                komutAdsUst.Parameters.AddWithValue("@tutar", toplam);
                                komutAdsUst.Parameters.AddWithValue("@indirim", iskonto);
                                komutAdsUst.Parameters.AddWithValue("@yekun", toplam - iskonto);
                                komutAdsUst.Parameters.AddWithValue("@durum", "0");
                                komutAdsUst.Parameters.AddWithValue("@odeme", 2);
                                komutAdsUst.Parameters.AddWithValue("@MASA_ACAN", Giris.kullanici);
                                komutAdsUst.Parameters.AddWithValue("@SIRA_NO", siraNo);
                                komutAdsUst.ExecuteNonQuery();

                                SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                                nakitOdeme.Parameters.AddWithValue("@adisyonno", lblAdisyonNo.Text);
                                nakitOdeme.Parameters.AddWithValue("@odeme", 2);
                                nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                                nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                                nakitOdeme.Parameters.AddWithValue("@selfServis", false);
                                nakitOdeme.ExecuteNonQuery();

                                btnIptal.PerformClick();
                            }
                        }

                    }
                    /*Açık Masa İşlemleri*/
                    else
                    {
                        SqlCommand nakitOdeme = new SqlCommand("INSERT INTO TBLODEME (adisyonno,odeme,miktar,tarih,SelfServis) VALUES (@adisyonno,@odeme,@miktar,@tarih,@selfServis)", baglanti);
                        nakitOdeme.Parameters.AddWithValue("@adisyonno", gelenNo);
                        nakitOdeme.Parameters.AddWithValue("@odeme", 2);
                        nakitOdeme.Parameters.AddWithValue("@miktar", toplam - iskonto);
                        nakitOdeme.Parameters.AddWithValue("@tarih", lblAcilisZamani.Text);
                        nakitOdeme.Parameters.AddWithValue("@selfServis", false);
                        int onay = nakitOdeme.ExecuteNonQuery();
                        if (onay > 0)
                        {
                            SqlCommand adisyonUstDurum = new SqlCommand("UPDATE TBLADISYONUST SET durum=@durum WHERE adisyonno='" + gelenNo + "'", baglanti);
                            adisyonUstDurum.Parameters.AddWithValue("@durum", 0);
                            adisyonUstDurum.ExecuteNonQuery();
                            btnYazdir.PerformClick();
                        }

                    }
                    btnIptal.PerformClick();

                    baglanti.Close();
                }
                else
                    MessageBox.Show("İşlem yapılmadı");
            }
            else
                MessageBox.Show("Adisyonda Ürün Yok");
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count <= 0)
            {
                MessageBox.Show("Ürün olmadığı için yazdırma işlemi yapılamaz.", "Yazdırma Uyarısı");
            }
            else
            {
                yazici.FisListesi = listView1;

                yazici.AdisyonNo = lblAdisyonNo.Text;
                yazici.Masa = lblMasaNo.Text;
                yazici.Tarih = lblAcilisZamani.Text;
                yazici.Garson = lblGarson.Text;
                yazici.Iskonto = iskonto;


                pDoc.Print();
                btnYazdir.Enabled = false;
                btnGonder.PerformClick();
            }
        }

        private void btnZrapor_Click(object sender, EventArgs e)
        {
            string iT, sT;
            decimal zToplamFiyat = 0, zToplamYekun = 0, zToplamIskonto = 0;// zToplamUrunAlis = 0, zToplamKar = 0;
            RaporTarihi rp = new RaporTarihi();
            rp.ShowDialog();
            bool onay = RaporTarihi.onay;
            if (onay == true)
            {
                iT = RaporTarihi.ilkTarih; sT = RaporTarihi.sonTarih;
                SqlConnection baglanti = veriSinif.getBaglanti();
                SqlCommand komut = new SqlCommand("SELECT tutar,indirim,yekun FROM TBLADISYONUST WHERE tarih BETWEEN '" + iT + "' AND '" + sT + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    zToplamFiyat += Convert.ToDecimal(oku[0].ToString());
                    zToplamIskonto += Convert.ToDecimal(oku[1].ToString());
                    zToplamYekun += Convert.ToDecimal(oku[2].ToString());
                }
                MessageBox.Show("Toplam Fiyat=" + zToplamFiyat.ToString("c") + "\n Toplam İndirim=" + zToplamIskonto.ToString("c") + "\nToplam Yekun=" + zToplamYekun.ToString("c"));

            }
            else
            {

            }
        }

        #endregion

        #region GirişButonları
        private void btnAcikSiparis_Click(object sender, EventArgs e)
        {
            acikMasaPanel.Controls.Clear();
            masaGrupPanel.Visible = false;
            grupPanel.Visible = false;
            urunPanel.Visible = false;
            masaPanel.Visible = false;
            sagUrunPanel.Visible = false;
            acikMasaPanel.Visible = true;
            acikMasaPanel.BringToFront();

            SqlConnection baglanti = veriSinif.getBaglanti();
            SqlDataReader acikMasaOku;
            SqlCommand komut = new SqlCommand("SELECT adisyonno,masano,yekun,garson FROM TBLADISYONUST WHERE DURUM=-1", baglanti);
            acikMasaOku = komut.ExecuteReader();
            int top = 5, left = 5;
            while (acikMasaOku.Read())
            {
                SimpleButton acikMasa = new SimpleButton();
                acikMasa.Text = acikMasaOku[0].ToString() + "\n" + acikMasaOku[1].ToString() + "\n" + Decimal.Round(Convert.ToDecimal(acikMasaOku[2].ToString()), 2) + " ₺\n" + acikMasaOku[3].ToString();
                acikMasa.Font = new Font(acikMasa.Font.FontFamily, 12);
                //acikMasa.Font = new Font(acikMasa.Font, acikMasa.Font.Style ^ FontStyle.Bold);

                acikMasa.Name = acikMasaOku[0].ToString();
                acikMasa.Location = new Point(left, top);
                acikMasa.Width = 130;
                acikMasa.Height = 110;
                left += 140;
                if ((left + 130) >= sagPanel.Location.X - 400)
                {
                    top += 109; left = 5;
                }
                acikMasa.Click += new EventHandler(acikMasaGetir);
                acikMasaPanel.Controls.Add(acikMasa);
            }
            baglanti.Close();
        }

        private void btnMasaDegistir_Click(object sender, EventArgs e)
        {

        }

        private void btnMasaBirlestir_Click(object sender, EventArgs e)
        {

        }

        private void btnKilitle_Click(object sender, EventArgs e)
        {
            this.Close();
            Giris frm = new Giris();
            frm.ShowDialog();
        }

        private void acikMasaGetir(object sender, EventArgs e)
        {
            btnYazdir.Enabled = true;
            listView1.Items.Clear();
            string AdsNo;
            AdsNo = ((SimpleButton)sender).Name.ToString();
            SqlConnection baglanti = veriSinif.getBaglanti();
            SqlDataReader adisyonOku, adisyonUstOku;
            SqlCommand tblAdisyon = new SqlCommand("SELECT tarih,masa,garson,adisyonno,urunadi,miktari,birimfiyati,iskonto_orani,toplam,STOK_KODU FROM TBLADISYON where adisyonno='" + ((SimpleButton)sender).Name + "'", baglanti);
            SqlCommand tblAdisyonUst = new SqlCommand("Select tarih,adisyonno,masano,garson,tutar,indirim,yekun from TBLADISYONUST where adisyonno='" + ((SimpleButton)sender).Name + "'", baglanti);
            adisyonOku = tblAdisyon.ExecuteReader(); adisyonUstOku = tblAdisyonUst.ExecuteReader();
            while (adisyonOku.Read())
            {
                string[] bilgiler = { adisyonOku[4].ToString(), adisyonOku[5].ToString(), Decimal.Round(Convert.ToDecimal(adisyonOku[8]), 2).ToString(), " ₺", adisyonOku[9].ToString() };
                listView1.Items.Add(new ListViewItem(bilgiler));
                lblAcilisZamani.Text = adisyonOku[0].ToString();
            }
            while (adisyonUstOku.Read())
            {
                txtAraToplam.Text = Decimal.Round(Convert.ToDecimal(adisyonUstOku[4]), 2).ToString() + " ₺";
                toplam = Decimal.Round(Convert.ToDecimal(adisyonUstOku[4]), 2);
                txtIskonto.Text = Decimal.Round(Convert.ToDecimal(adisyonUstOku[5]), 2).ToString() + " ₺";
                iskonto = Decimal.Round(Convert.ToDecimal(adisyonUstOku[5]), 2);
                txtGenelToplam.Text = Decimal.Round(Convert.ToDecimal(adisyonUstOku[6]), 2).ToString() + " ₺";

                lblAdisyonNo.Text = adisyonUstOku[1].ToString();
                lblMasaNo.Text = adisyonUstOku[2].ToString();
                lblGarson.Text = adisyonUstOku[3].ToString();

            }

            baglanti.Close();
            acikMasaPanel.Visible = false;
            masaPanel.Visible = false;
            masaGrupPanel.Visible = false;
            urunPanel.Visible = true;
            grupPanel.Visible = true;
            sagGirisPanel.Visible = false;
            sagUrunPanel.Visible = true;

        }

        private void btnSelfServis_Click(object sender, EventArgs e)
        {
            masaGrupPanel.Visible = false;
            masaPanel.Visible = false;
            urunPanel.Visible = true;
            grupPanel.Visible = true;
            sagGirisPanel.Visible = false;
            sagUrunPanel.Visible = true;
            acikMasaPanel.Visible = false;

            SqlConnection baglantiTarih = veriSinif.getBaglanti();
            SqlDataReader okuTarih, oku2Sira;
            SqlCommand komutTarih = new SqlCommand("Select TOP(1) tarih from TBLADISYONUST ORDER BY tarih desc", baglantiTarih);
            SqlCommand komutSira = new SqlCommand("Select TOP(1) SIRA_NO FROM TBLADISYONUST ORDER BY a desc", baglantiTarih);
            okuTarih = komutTarih.ExecuteReader(); oku2Sira = komutSira.ExecuteReader();
            string gun = "", ay = "";
            while (okuTarih.Read())
            {
                while (oku2Sira.Read())
                {
                    siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                }
                if (DateTime.Now.Day < 10)
                {
                    gun = "0" + DateTime.Now.Day;
                }
                else
                    gun = DateTime.Now.Day.ToString();
                if (DateTime.Now.Month < 10)
                {
                    ay = "0" + DateTime.Now.Month;
                }
                else
                    ay = DateTime.Now.Month.ToString();

                //if (okuTarih[0].ToString() != (gun + "." + ay + "." + DateTime.Now.Year.ToString() + " 00:00:00"))
                //{
                //    siraNo = 0;
                //}
                //else
                //{
                //    while (oku2Sira.Read())
                //    {
                //        siraNo = Convert.ToInt32(oku2Sira[0]) + 1;
                //    }
                //}
            }
            baglantiTarih.Close();
            lblAcilisZamani.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
            lblGarson.Text = Giris.kullanici;
            lblMasaNo.Text = "Self-Servis" + siraNo;
            //Adisyon
            lblAdisyonNo.Text = "S" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + siraNo;

        }

        private void btnMasaServis_Click(object sender, EventArgs e)
        {
            acikMasaPanel.Visible = false;
            masaGrupPanel.Visible = true;
            masaPanel.Visible = false;
            masaPanel.BringToFront();
        }
        #endregion

    }
}
