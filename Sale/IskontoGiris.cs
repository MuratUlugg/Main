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
using ClassLibrary1;
namespace Sale
{
    public partial class IskontoGiris : DevExpress.XtraEditors.XtraForm
    {
        public IskontoGiris()
        {
            InitializeComponent();
        }

        public static string girisTuru;

        private void btnYuzde_Click(object sender, EventArgs e)
        {
            girisTuru = "%";
            this.Close();
        }

        private void btnTl_Click(object sender, EventArgs e)
        {
            girisTuru = "₺";
            this.Close();
        }

        private void IskontoGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Iskonto iskontoForm = new Iskonto();
            iskontoForm.ShowDialog();
        }
    }
}