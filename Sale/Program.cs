using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace Sale
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();

            string sunucuAdi = ClassLibrary1.IniIslemleri.VeriOku("Sunucu Bilgileri", "SunucuAdi");
            string kullaniciAdi = ClassLibrary1.IniIslemleri.VeriOku("Kullanıcı Bilgileri", "KullaniciAdi");
            string sifre = ClassLibrary1.IniIslemleri.VeriOku("Şifre Bilgileri", "sifre");

            if (sunucuAdi == "" &&  kullaniciAdi == "" && sifre == "")
            {
                Application.Run(new Sunucu());
            }
            else
            {
                Application.Run(new Giris());
            }

            }
        }

}
