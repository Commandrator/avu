namespace _10040TalhaYasar
{
    partial class TYYeniKayit
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
            this.TYbuttonKaydet = new System.Windows.Forms.Button();
            this.TYtextBoxSifre = new System.Windows.Forms.TextBox();
            this.TYtextBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.TYLabelSifre = new System.Windows.Forms.Label();
            this.TYLabelKullaniciAdi = new System.Windows.Forms.Label();
            this.TYdateTimePickerYas = new System.Windows.Forms.DateTimePicker();
            this.TYcomboBoxCinsiyet = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TYlabelIsım = new System.Windows.Forms.Label();
            this.TYlabelSoyısım = new System.Windows.Forms.Label();
            this.TYtextBoxIsim = new System.Windows.Forms.TextBox();
            this.TYtextBoxSoyisim = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TYbuttonKaydet
            // 
            this.TYbuttonKaydet.Location = new System.Drawing.Point(175, 169);
            this.TYbuttonKaydet.Name = "TYbuttonKaydet";
            this.TYbuttonKaydet.Size = new System.Drawing.Size(75, 23);
            this.TYbuttonKaydet.TabIndex = 7;
            this.TYbuttonKaydet.Text = "Kaydet";
            this.TYbuttonKaydet.UseVisualStyleBackColor = true;
            this.TYbuttonKaydet.Click += new System.EventHandler(this.TYbuttonKaydet_Click);
            this.TYbuttonKaydet.Enter += new System.EventHandler(this.TYbuttonKaydet_Click);
            // 
            // TYtextBoxSifre
            // 
            this.TYtextBoxSifre.Location = new System.Drawing.Point(101, 90);
            this.TYtextBoxSifre.Name = "TYtextBoxSifre";
            this.TYtextBoxSifre.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxSifre.TabIndex = 4;
            // 
            // TYtextBoxKullaniciAdi
            // 
            this.TYtextBoxKullaniciAdi.Location = new System.Drawing.Point(101, 12);
            this.TYtextBoxKullaniciAdi.Name = "TYtextBoxKullaniciAdi";
            this.TYtextBoxKullaniciAdi.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxKullaniciAdi.TabIndex = 1;
            this.TYtextBoxKullaniciAdi.Tag = "";
            // 
            // TYLabelSifre
            // 
            this.TYLabelSifre.AutoSize = true;
            this.TYLabelSifre.Location = new System.Drawing.Point(61, 93);
            this.TYLabelSifre.Name = "TYLabelSifre";
            this.TYLabelSifre.Size = new System.Drawing.Size(31, 13);
            this.TYLabelSifre.TabIndex = 8;
            this.TYLabelSifre.Text = "Şifre:";
            // 
            // TYLabelKullaniciAdi
            // 
            this.TYLabelKullaniciAdi.AutoSize = true;
            this.TYLabelKullaniciAdi.Location = new System.Drawing.Point(25, 15);
            this.TYLabelKullaniciAdi.Name = "TYLabelKullaniciAdi";
            this.TYLabelKullaniciAdi.Size = new System.Drawing.Size(67, 13);
            this.TYLabelKullaniciAdi.TabIndex = 7;
            this.TYLabelKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // TYdateTimePickerYas
            // 
            this.TYdateTimePickerYas.Location = new System.Drawing.Point(101, 143);
            this.TYdateTimePickerYas.Name = "TYdateTimePickerYas";
            this.TYdateTimePickerYas.Size = new System.Drawing.Size(149, 20);
            this.TYdateTimePickerYas.TabIndex = 6;
            // 
            // TYcomboBoxCinsiyet
            // 
            this.TYcomboBoxCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TYcomboBoxCinsiyet.FormattingEnabled = true;
            this.TYcomboBoxCinsiyet.ItemHeight = 13;
            this.TYcomboBoxCinsiyet.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.TYcomboBoxCinsiyet.Location = new System.Drawing.Point(101, 116);
            this.TYcomboBoxCinsiyet.Name = "TYcomboBoxCinsiyet";
            this.TYcomboBoxCinsiyet.Size = new System.Drawing.Size(149, 21);
            this.TYcomboBoxCinsiyet.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Doğum Tarihi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Cinsiyet:";
            // 
            // TYlabelIsım
            // 
            this.TYlabelIsım.AutoSize = true;
            this.TYlabelIsım.Location = new System.Drawing.Point(64, 41);
            this.TYlabelIsım.Name = "TYlabelIsım";
            this.TYlabelIsım.Size = new System.Drawing.Size(28, 13);
            this.TYlabelIsım.TabIndex = 18;
            this.TYlabelIsım.Text = "İsim:";
            // 
            // TYlabelSoyısım
            // 
            this.TYlabelSoyısım.AutoSize = true;
            this.TYlabelSoyısım.Location = new System.Drawing.Point(47, 67);
            this.TYlabelSoyısım.Name = "TYlabelSoyısım";
            this.TYlabelSoyısım.Size = new System.Drawing.Size(45, 13);
            this.TYlabelSoyısım.TabIndex = 19;
            this.TYlabelSoyısım.Text = "Soyisim:";
            // 
            // TYtextBoxIsim
            // 
            this.TYtextBoxIsim.Location = new System.Drawing.Point(101, 38);
            this.TYtextBoxIsim.Name = "TYtextBoxIsim";
            this.TYtextBoxIsim.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxIsim.TabIndex = 2;
            this.TYtextBoxIsim.Tag = "";
            // 
            // TYtextBoxSoyisim
            // 
            this.TYtextBoxSoyisim.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TYtextBoxSoyisim.Location = new System.Drawing.Point(101, 64);
            this.TYtextBoxSoyisim.Name = "TYtextBoxSoyisim";
            this.TYtextBoxSoyisim.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxSoyisim.TabIndex = 3;
            this.TYtextBoxSoyisim.Tag = "";
            // 
            // TYYeniKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 207);
            this.Controls.Add(this.TYtextBoxSoyisim);
            this.Controls.Add(this.TYtextBoxIsim);
            this.Controls.Add(this.TYlabelSoyısım);
            this.Controls.Add(this.TYlabelIsım);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TYcomboBoxCinsiyet);
            this.Controls.Add(this.TYdateTimePickerYas);
            this.Controls.Add(this.TYbuttonKaydet);
            this.Controls.Add(this.TYtextBoxSifre);
            this.Controls.Add(this.TYtextBoxKullaniciAdi);
            this.Controls.Add(this.TYLabelSifre);
            this.Controls.Add(this.TYLabelKullaniciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TYYeniKayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kayıt Sayfası";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TYYeniKayit_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TYbuttonKaydet;
        private System.Windows.Forms.TextBox TYtextBoxSifre;
        private System.Windows.Forms.TextBox TYtextBoxKullaniciAdi;
        private System.Windows.Forms.Label TYLabelSifre;
        private System.Windows.Forms.Label TYLabelKullaniciAdi;
        private System.Windows.Forms.DateTimePicker TYdateTimePickerYas;
        private System.Windows.Forms.ComboBox TYcomboBoxCinsiyet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TYlabelIsım;
        private System.Windows.Forms.Label TYlabelSoyısım;
        private System.Windows.Forms.TextBox TYtextBoxIsim;
        private System.Windows.Forms.TextBox TYtextBoxSoyisim;
    }
}