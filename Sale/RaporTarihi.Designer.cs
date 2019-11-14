namespace Sale
{
    partial class RaporTarihi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RaporTarihi));
            this.dtPickerIlk = new System.Windows.Forms.DateTimePicker();
            this.dtPickerSon = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOnay = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // dtPickerIlk
            // 
            this.dtPickerIlk.CustomFormat = "";
            this.dtPickerIlk.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerIlk.Location = new System.Drawing.Point(156, 70);
            this.dtPickerIlk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtPickerIlk.Name = "dtPickerIlk";
            this.dtPickerIlk.Size = new System.Drawing.Size(172, 21);
            this.dtPickerIlk.TabIndex = 1;
            this.dtPickerIlk.ValueChanged += new System.EventHandler(this.dtPickerIlk_ValueChanged);
            // 
            // dtPickerSon
            // 
            this.dtPickerSon.CustomFormat = "";
            this.dtPickerSon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPickerSon.Location = new System.Drawing.Point(156, 113);
            this.dtPickerSon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtPickerSon.Name = "dtPickerSon";
            this.dtPickerSon.Size = new System.Drawing.Size(172, 21);
            this.dtPickerSon.TabIndex = 2;
            this.dtPickerSon.ValueChanged += new System.EventHandler(this.dtPickerSon_ValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 11);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(348, 21);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Lütfen raporunu alacağınız tarih aralıklarını giriniz.";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(26, 72);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(124, 20);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Başlangıç Zamanı :";
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(61, 114);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(89, 20);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Bitiş Zamanı :";
            // 
            // btnOnay
            // 
            this.btnOnay.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnOnay.ImageOptions.SvgImage")));
            this.btnOnay.Location = new System.Drawing.Point(48, 169);
            this.btnOnay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOnay.Name = "btnOnay";
            this.btnOnay.Size = new System.Drawing.Size(116, 64);
            this.btnOnay.TabIndex = 3;
            this.btnOnay.Text = "Onayla";
            this.btnOnay.Click += new System.EventHandler(this.btnOnay_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIptal.ImageOptions.SvgImage")));
            this.btnIptal.Location = new System.Drawing.Point(216, 169);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(116, 64);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // RaporTarihi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 257);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOnay);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dtPickerSon);
            this.Controls.Add(this.dtPickerIlk);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RaporTarihi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RaporTarihi";
            this.Load += new System.EventHandler(this.RaporTarihi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPickerIlk;
        private System.Windows.Forms.DateTimePicker dtPickerSon;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnOnay;
        private DevExpress.XtraEditors.SimpleButton btnIptal;
    }
}