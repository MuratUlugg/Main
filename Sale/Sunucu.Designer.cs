namespace Sale
{
    partial class Sunucu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sunucu));
            this.txtSıfre = new DevExpress.XtraEditors.TextEdit();
            this.txtSunucu = new DevExpress.XtraEditors.TextEdit();
            this.txtKul = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSıfre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKul.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSıfre
            // 
            this.txtSıfre.Location = new System.Drawing.Point(152, 126);
            this.txtSıfre.Name = "txtSıfre";
            this.txtSıfre.Properties.Appearance.Options.UseImage = true;
            this.txtSıfre.Size = new System.Drawing.Size(125, 24);
            this.txtSıfre.TabIndex = 3;
            this.txtSıfre.EditValueChanged += new System.EventHandler(this.txtSıfre_EditValueChanged);
            // 
            // txtSunucu
            // 
            this.txtSunucu.Location = new System.Drawing.Point(152, 38);
            this.txtSunucu.Name = "txtSunucu";
            this.txtSunucu.Size = new System.Drawing.Size(125, 24);
            this.txtSunucu.TabIndex = 1;
            // 
            // txtKul
            // 
            this.txtKul.Location = new System.Drawing.Point(152, 82);
            this.txtKul.Name = "txtKul";
            this.txtKul.Size = new System.Drawing.Size(125, 24);
            this.txtKul.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(54, 130);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 17);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Şifre :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(54, 88);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 17);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Kullanıcı Adı :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 41);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 17);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Sunucu Adı :";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(42, 192);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(114, 57);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "İptal";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(178, 192);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(120, 57);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Sunucu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 294);
            this.Controls.Add(this.txtSıfre);
            this.Controls.Add(this.txtSunucu);
            this.Controls.Add(this.txtKul);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Name = "Sunucu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sunucu Ayarı";
            this.Load += new System.EventHandler(this.Sunucu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSıfre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSunucu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKul.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtSıfre;
        private DevExpress.XtraEditors.TextEdit txtSunucu;
        private DevExpress.XtraEditors.TextEdit txtKul;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}