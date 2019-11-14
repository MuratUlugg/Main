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
    public partial class Giris : DevExpress.XtraEditors.XtraForm
    {
        public Giris()
        {
            InitializeComponent();
        }

        Veri veriTabani = new Veri();
        public static string kullanici;

        private void Giris_Load(object sender, EventArgs e)
        {
            txtSifre.Text = "";
            veriTabani.kontrolDurumu();
        }
        #region TusTakimi

        private void btn1_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtSifre.Text += "0";
        }
        #endregion

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(txtSifre.Text.Length>0)
            txtSifre.Text = txtSifre.Text.Substring(0,txtSifre.Text.Length-1);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            SqlConnection baglanti = veriTabani.getBaglanti();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLKULLANICI",baglanti);
            SqlDataReader oku;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (txtSifre.Text == oku[3].ToString())
                {
                    kontrol = true;
                    UrunSatis uS = new UrunSatis();
                    kullanici = oku[1].ToString();
                    uS.ShowDialog();
                    this.Close();
                    break;
                }
                else
                {
                    kontrol = false;
                }
            }
            if (kontrol == false)
                MessageBox.Show("Kullanıcı Bulunamadı");

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}