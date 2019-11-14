namespace Sale
{
    partial class IskontoGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IskontoGiris));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnTl = new DevExpress.XtraEditors.SimpleButton();
            this.btnYuzde = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(215, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(214, 30);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "İskonto türünü seçiniz.";
            // 
            // btnTl
            // 
            this.btnTl.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTl.ImageOptions.SvgImage")));
            this.btnTl.Location = new System.Drawing.Point(28, 122);
            this.btnTl.Name = "btnTl";
            this.btnTl.Size = new System.Drawing.Size(250, 90);
            this.btnTl.TabIndex = 1;
            this.btnTl.Text = "TL Bazlı";
            this.btnTl.Click += new System.EventHandler(this.btnTl_Click);
            // 
            // btnYuzde
            // 
            this.btnYuzde.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnYuzde.ImageOptions.SvgImage")));
            this.btnYuzde.Location = new System.Drawing.Point(361, 122);
            this.btnYuzde.Name = "btnYuzde";
            this.btnYuzde.Size = new System.Drawing.Size(250, 90);
            this.btnYuzde.TabIndex = 2;
            this.btnYuzde.Text = "Yüzde Bazlı";
            this.btnYuzde.Click += new System.EventHandler(this.btnYuzde_Click);
            // 
            // IskontoGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 275);
            this.Controls.Add(this.btnYuzde);
            this.Controls.Add(this.btnTl);
            this.Controls.Add(this.labelControl1);
            this.Name = "IskontoGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IskontoGırıs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IskontoGiris_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnTl;
        private DevExpress.XtraEditors.SimpleButton btnYuzde;
    }
}