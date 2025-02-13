namespace _10040TalhaYasar
{
    partial class TYFormGiris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.TYLabelKullaniciAdi = new System.Windows.Forms.Label();
            this.TYLabelSifre = new System.Windows.Forms.Label();
            this.TYLabelGuvenlikKodu = new System.Windows.Forms.Label();
            this.TYtextBoxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.TYtextBoxSifre = new System.Windows.Forms.TextBox();
            this.TYtextBoxGuvenlikKodu = new System.Windows.Forms.TextBox();
            this.TYbuttonGiris = new System.Windows.Forms.Button();
            this.TYlinkLabelYeniKayit = new System.Windows.Forms.LinkLabel();
            this.TYlabelKod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TYLabelKullaniciAdi
            // 
            this.TYLabelKullaniciAdi.AutoSize = true;
            this.TYLabelKullaniciAdi.Location = new System.Drawing.Point(37, 10);
            this.TYLabelKullaniciAdi.Name = "TYLabelKullaniciAdi";
            this.TYLabelKullaniciAdi.Size = new System.Drawing.Size(67, 13);
            this.TYLabelKullaniciAdi.TabIndex = 0;
            this.TYLabelKullaniciAdi.Text = "Kullanıcı Adı:";
            // 
            // TYLabelSifre
            // 
            this.TYLabelSifre.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.TYLabelSifre.AutoSize = true;
            this.TYLabelSifre.Location = new System.Drawing.Point(73, 44);
            this.TYLabelSifre.Name = "TYLabelSifre";
            this.TYLabelSifre.Size = new System.Drawing.Size(31, 13);
            this.TYLabelSifre.TabIndex = 1;
            this.TYLabelSifre.Text = "Şifre:";
            // 
            // TYLabelGuvenlikKodu
            // 
            this.TYLabelGuvenlikKodu.AutoSize = true;
            this.TYLabelGuvenlikKodu.Location = new System.Drawing.Point(24, 107);
            this.TYLabelGuvenlikKodu.Name = "TYLabelGuvenlikKodu";
            this.TYLabelGuvenlikKodu.Size = new System.Drawing.Size(80, 13);
            this.TYLabelGuvenlikKodu.TabIndex = 2;
            this.TYLabelGuvenlikKodu.Text = "Güvenlik Kodu:";
            // 
            // TYtextBoxKullaniciAdi
            // 
            this.TYtextBoxKullaniciAdi.Location = new System.Drawing.Point(111, 7);
            this.TYtextBoxKullaniciAdi.Name = "TYtextBoxKullaniciAdi";
            this.TYtextBoxKullaniciAdi.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxKullaniciAdi.TabIndex = 1;
            this.TYtextBoxKullaniciAdi.Tag = "";
            // 
            // TYtextBoxSifre
            // 
            this.TYtextBoxSifre.Location = new System.Drawing.Point(111, 41);
            this.TYtextBoxSifre.Name = "TYtextBoxSifre";
            this.TYtextBoxSifre.PasswordChar = '*';
            this.TYtextBoxSifre.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxSifre.TabIndex = 2;
            // 
            // TYtextBoxGuvenlikKodu
            // 
            this.TYtextBoxGuvenlikKodu.Location = new System.Drawing.Point(111, 107);
            this.TYtextBoxGuvenlikKodu.MaxLength = 6;
            this.TYtextBoxGuvenlikKodu.Name = "TYtextBoxGuvenlikKodu";
            this.TYtextBoxGuvenlikKodu.Size = new System.Drawing.Size(149, 20);
            this.TYtextBoxGuvenlikKodu.TabIndex = 3;
            // 
            // TYbuttonGiris
            // 
            this.TYbuttonGiris.Location = new System.Drawing.Point(111, 133);
            this.TYbuttonGiris.Name = "TYbuttonGiris";
            this.TYbuttonGiris.Size = new System.Drawing.Size(75, 23);
            this.TYbuttonGiris.TabIndex = 4;
            this.TYbuttonGiris.Text = "Giriş";
            this.TYbuttonGiris.UseVisualStyleBackColor = true;
            this.TYbuttonGiris.Click += new System.EventHandler(this.TYbuttonGiris_Click);
            this.TYbuttonGiris.Enter += new System.EventHandler(this.TYbuttonGiris_Click);
            // 
            // TYlinkLabelYeniKayit
            // 
            this.TYlinkLabelYeniKayit.AutoSize = true;
            this.TYlinkLabelYeniKayit.Location = new System.Drawing.Point(206, 138);
            this.TYlinkLabelYeniKayit.Name = "TYlinkLabelYeniKayit";
            this.TYlinkLabelYeniKayit.Size = new System.Drawing.Size(54, 13);
            this.TYlinkLabelYeniKayit.TabIndex = 5;
            this.TYlinkLabelYeniKayit.TabStop = true;
            this.TYlinkLabelYeniKayit.Text = "Yeni Kayıt";
            this.TYlinkLabelYeniKayit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TYlinkLabelYeniKayit_LinkClicked);
            // 
            // TYlabelKod
            // 
            this.TYlabelKod.AutoSize = true;
            this.TYlabelKod.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TYlabelKod.Location = new System.Drawing.Point(134, 64);
            this.TYlabelKod.Name = "TYlabelKod";
            this.TYlabelKod.Size = new System.Drawing.Size(76, 31);
            this.TYlabelKod.TabIndex = 8;
            this.TYlabelKod.Text = "KOD";
            this.TYlabelKod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TYFormGiris
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 165);
            this.Controls.Add(this.TYlabelKod);
            this.Controls.Add(this.TYlinkLabelYeniKayit);
            this.Controls.Add(this.TYbuttonGiris);
            this.Controls.Add(this.TYtextBoxGuvenlikKodu);
            this.Controls.Add(this.TYtextBoxSifre);
            this.Controls.Add(this.TYtextBoxKullaniciAdi);
            this.Controls.Add(this.TYLabelGuvenlikKodu);
            this.Controls.Add(this.TYLabelSifre);
            this.Controls.Add(this.TYLabelKullaniciAdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TYFormGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TYFormGiris_FormClosed);
            this.Load += new System.EventHandler(this.TYFormGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TYLabelKullaniciAdi;
        private System.Windows.Forms.Label TYLabelSifre;
        private System.Windows.Forms.Label TYLabelGuvenlikKodu;
        private System.Windows.Forms.TextBox TYtextBoxKullaniciAdi;
        private System.Windows.Forms.TextBox TYtextBoxSifre;
        private System.Windows.Forms.TextBox TYtextBoxGuvenlikKodu;
        private System.Windows.Forms.Button TYbuttonGiris;
        private System.Windows.Forms.LinkLabel TYlinkLabelYeniKayit;
        private System.Windows.Forms.Label TYlabelKod;
    }
}

