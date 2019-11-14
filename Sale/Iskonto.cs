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
    public partial class Iskonto : DevExpress.XtraEditors.XtraForm
    {
        public Iskonto()
        {
            InitializeComponent();
        }

        private void Iskonto_Load(object sender, EventArgs e)
        {
            txtIskontoTl.Visible = false;
            txtIskontoTl.Enabled = false;

            txtIskontoYuzde.Visible = false;
            txtIskontoYuzde.Enabled = false;

            if (IskontoGiris.girisTuru == "%")
            {
                txtIskontoYuzde.Visible = true;
                txtIskontoYuzde.Enabled = true;
                txtIskontoYuzde.Text = "% ";
            }
            if (IskontoGiris.girisTuru == "₺")
            {

                txtIskontoTl.Visible = true;
                txtIskontoTl.Enabled = true;
                txtIskontoTl.Text = "₺ ";
            }

        }

        private void txtTemizle_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text = "% ";
            txtIskontoTl.Text = "₺ ";
        }

        #region dokunmatik
        private void txt1_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "1";
            txtIskontoTl.Text += "1";
        }

        private void txt2_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "2";
            txtIskontoTl.Text += "2";
        }

        private void txt3_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "3";
            txtIskontoTl.Text += "3";
        }

        private void txt4_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "4";
            txtIskontoTl.Text += "4";
        }

        private void txt5_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "5";
            txtIskontoTl.Text += "5";
        }

        private void txt6_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "6";
            txtIskontoTl.Text += "6";
        }

        private void txt7_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "7";
            txtIskontoTl.Text += "7";
        }

        private void txt8_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "8";
            txtIskontoTl.Text += "8";
        }

        private void txt9_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "9";
            txtIskontoTl.Text += "9";
        }

        private void txt0_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += "0";
            txtIskontoTl.Text += "0";
        }

        private void txtNokta_Click(object sender, EventArgs e)
        {
            txtIskontoYuzde.Text += ",";
            txtIskontoTl.Text += ",";
        }
        #endregion

        private void txtOnay_Click(object sender, EventArgs e)
        {
            if (txtIskontoYuzde.Text != "% " && txtIskontoTl.Text != "₺ ")
            {
                if (IskontoGiris.girisTuru == "%")
                {
                    decimal urunIskonto = Decimal.Round((UrunSatis.toplam * (Convert.ToDecimal(txtIskontoYuzde.Text.Substring(2)) / 100)), 2);
                    urunIskonto = Decimal.Round(urunIskonto, 2);
                    if (urunIskonto < UrunSatis.toplam)
                    {
                        UrunSatis.iskonto = urunIskonto;
                        UrunSatis.txtEdit.Text = urunIskonto.ToString() + " ₺";
                    }
                    else
                        MessageBox.Show("Iskonto tutarını kontrol ediniz.");
                }
                if (IskontoGiris.girisTuru == "₺")
                {
                    if (Convert.ToDecimal(txtIskontoTl.Text.Substring(2)) < UrunSatis.toplam)
                    {
                        UrunSatis.iskonto = Convert.ToDecimal(txtIskontoTl.Text.Substring(2));
                        UrunSatis.txtEdit.Text = (Decimal.Round(UrunSatis.iskonto, 2)).ToString() + " ₺";
                    }
                    else
                        MessageBox.Show("Iskonto tutarını kontrol ediniz.");
                }
                this.Close();
            }
            else
                MessageBox.Show("Iskonto tutarı girmediniz.");

        }
    }
}