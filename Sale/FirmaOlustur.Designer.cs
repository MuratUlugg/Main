namespace Sale
{
    partial class FirmaOlustur
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
            this.txtDb = new DevExpress.XtraEditors.TextEdit();
            this.txtFirma = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbVarsayilan = new DevExpress.XtraEditors.CheckEdit();
            this.txtLisans = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnOlustur = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVarsayilan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLisans.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDb
            // 
            this.txtDb.Location = new System.Drawing.Point(151, 44);
            this.txtDb.Name = "txtDb";
            this.txtDb.Size = new System.Drawing.Size(147, 24);
            this.txtDb.TabIndex = 0;
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(151, 97);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(147, 24);
            this.txtFirma.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 17);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "DataBase Adı:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(36, 104);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Firma Adı:";
            // 
            // cbVarsayilan
            // 
            this.cbVarsayilan.Location = new System.Drawing.Point(73, 210);
            this.cbVarsayilan.Name = "cbVarsayilan";
            this.cbVarsayilan.Properties.Caption = "Varsayılan";
            this.cbVarsayilan.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.cbVarsayilan.Size = new System.Drawing.Size(94, 21);
            this.cbVarsayilan.TabIndex = 5;
            // 
            // txtLisans
            // 
            this.txtLisans.Location = new System.Drawing.Point(151, 149);
            this.txtLisans.Name = "txtLisans";
            this.txtLisans.Size = new System.Drawing.Size(147, 24);
            this.txtLisans.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(36, 152);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(98, 17);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Lisans Numarası:";
            // 
            // btnOlustur
            // 
            this.btnOlustur.Location = new System.Drawing.Point(173, 202);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(125, 29);
            this.btnOlustur.TabIndex = 2;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // FirmaOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 320);
            this.Controls.Add(this.cbVarsayilan);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.txtLisans);
            this.Controls.Add(this.txtFirma);
            this.Controls.Add(this.txtDb);
            this.Name = "FirmaOlustur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirmaOlustur";
            this.Load += new System.EventHandler(this.FirmaOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbVarsayilan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLisans.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDb;
        private DevExpress.XtraEditors.TextEdit txtFirma;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit cbVarsayilan;
        private DevExpress.XtraEditors.TextEdit txtLisans;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnOlustur;
    }
}