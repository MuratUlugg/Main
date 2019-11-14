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
            this.txtSıfre.Location = new System.Drawing.Point(130, 96);
            this.txtSıfre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSıfre.Name = "txtSıfre";
            this.txtSıfre.Properties.Appearance.Options.UseImage = true;
            this.txtSıfre.Size = new System.Drawing.Size(107, 20);
            this.txtSıfre.TabIndex = 3;
            this.txtSıfre.EditValueChanged += new System.EventHandler(this.txtSıfre_EditValueChanged);
            // 
            // txtSunucu
            // 
            this.txtSunucu.Location = new System.Drawing.Point(130, 29);
            this.txtSunucu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSunucu.Name = "txtSunucu";
            this.txtSunucu.Size = new System.Drawing.Size(107, 20);
            this.txtSunucu.TabIndex = 1;
            // 
            // txtKul
            // 
            this.txtKul.Location = new System.Drawing.Point(130, 63);
            this.txtKul.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKul.Name = "txtKul";
            this.txtKul.Size = new System.Drawing.Size(107, 20);
            this.txtKul.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(46, 99);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 13;
            this.labelControl3.Text = "Şifre :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(46, 67);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(62, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Kullanıcı Adı :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(46, 31);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Sunucu Adı :";
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.simpleButton2.Location = new System.Drawing.Point(36, 147);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(98, 44);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "İptal";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(153, 147);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(103, 44);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Kaydet";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Sunucu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 225);
            this.Controls.Add(this.txtSıfre);
            this.Controls.Add(this.txtSunucu);
            this.Controls.Add(this.txtKul);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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