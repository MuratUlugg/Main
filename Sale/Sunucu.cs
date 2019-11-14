using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ClassLibrary1;
namespace Sale
{
    public partial class Sunucu : DevExpress.XtraEditors.XtraForm
    {
        Veri veri = new Veri();

        public Sunucu()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string kulad = txtKul.Text;
            string s = txtSunucu.Text;
            string sifre = txtSıfre.Text;
            try
            {
                IniIslemleri.VeriYaz("Sunucu Bilgileri", "SunucuAdi", txtSunucu.Text);
                IniIslemleri.VeriYaz("Kullanıcı Bilgileri", "KullaniciAdi", txtKul.Text);
                IniIslemleri.VeriYaz("Şifre Bilgileri", "sifre", txtSıfre.Text);


                veri.mordorOlustur();
                veri.mordorTabloOlustur();
                veri.kontrolDurumu();


                Sunucu formkapa = new Sunucu();
                formkapa.Close();

               

                FirmaOlustur form = new FirmaOlustur();
                form.Show();
                this.Hide();

            }
            catch (Exception)
            {

                MessageBox.Show("Bağlantı Hatası");
                IniIslemleri.veriSil();

            }
        }

        private void Sunucu_Load(object sender, EventArgs e)
        {

        }

        private void txtSıfre_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}