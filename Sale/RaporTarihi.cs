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

namespace Sale
{
    public partial class RaporTarihi : DevExpress.XtraEditors.XtraForm
    {
        public RaporTarihi()
        {
            InitializeComponent();
        }
        public static string ilkTarih, sonTarih;
        public static bool onay;

        private void btnOnay_Click(object sender, EventArgs e)
        {
            ilkTarih = dtPickerIlk.Value.Year.ToString() +"-"+ dtPickerIlk.Value.Month.ToString()+"-" + dtPickerIlk.Value.Day.ToString();
            sonTarih = dtPickerSon.Value.Year.ToString() + "-" + dtPickerSon.Value.Month.ToString() + "-" + dtPickerSon.Value.Day.ToString();
            onay = true;
            this.Dispose();
        }

        private void dtPickerIlk_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickerSon.Value < dtPickerIlk.Value)
            {
                MessageBox.Show("2. Tarih büyük olamaz");
                dtPickerSon.Value = dtPickerIlk.Value;
            }
        }

        private void dtPickerSon_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickerSon.Value < dtPickerIlk.Value)
            {
                MessageBox.Show("2. Tarih küçük olamaz");
                dtPickerIlk.Value = dtPickerSon.Value;
            }
        }

        private void RaporTarihi_Load(object sender, EventArgs e)
        {
            ilkTarih = ""; sonTarih = ""; onay = false;
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            onay = false;
            this.Dispose();
        }
    }
}