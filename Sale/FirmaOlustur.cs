using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using ClassLibrary1;
namespace Sale
{
    public partial class FirmaOlustur : DevExpress.XtraEditors.XtraForm
    {
        public FirmaOlustur()
        {
            InitializeComponent();
        }
        Veri veriSinif = new Veri();
        private void btnOlustur_Click(object sender, EventArgs e)
        {
            if (txtFirma.Text != "")
            {
                veriSinif.firmaDbOlustur(txtFirma.Text);
                veriSinif.firmaTabloOlustur(txtFirma.Text);

            }
            SqlConnection baglanti = veriSinif.getMordor(txtDb.Text);
            SqlCommand komut = new SqlCommand("INSERT INTO TBLFIRMA (lisans_no,tabela_adi,varsayilan,veritabani_adi) VALUES (@lisans,@tabela,@varsayilan,@db)", baglanti);
            komut.Parameters.AddWithValue("@lisans", txtLisans.Text);
            komut.Parameters.AddWithValue("@tabela", txtFirma.Text.ToUpper());
            if (cbVarsayilan.Checked == true)
            {
                komut.Parameters.AddWithValue("@varsayilan", 1);
            }
            else
                komut.Parameters.AddWithValue("@varsayilan", 0);

            komut.Parameters.AddWithValue("@db", txtFirma.Text.ToUpper());
            komut.ExecuteNonQuery();
            baglanti.Close();


            veriSinif.kontrolDurumu();
            

            Giris form = new Giris();
            form.Show();
            this.Dispose();
            this.Close();

        }

        private void FirmaOlustur_Load(object sender, EventArgs e)
        {
        }
    }
}