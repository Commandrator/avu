namespace _10040TalhaYasar
{
    partial class TYAnasayfa
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
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.TYhtmlLabelUserInfo = new MetroFramework.Drawing.Html.HtmlLabel();
            this.SuspendLayout();
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(19, 63);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(125, 125);
            this.metroTile1.TabIndex = 0;
            this.metroTile1.Text = "Telefon Rehberi";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(167, 63);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(125, 125);
            this.metroTile2.TabIndex = 1;
            this.metroTile2.Text = "Matematik Oyunu";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.UseSelectable = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // TYhtmlLabelUserInfo
            // 
            this.TYhtmlLabelUserInfo.AutoScroll = true;
            this.TYhtmlLabelUserInfo.AutoScrollMinSize = new System.Drawing.Size(141, 23);
            this.TYhtmlLabelUserInfo.AutoSize = false;
            this.TYhtmlLabelUserInfo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TYhtmlLabelUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TYhtmlLabelUserInfo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TYhtmlLabelUserInfo.Location = new System.Drawing.Point(19, 26);
            this.TYhtmlLabelUserInfo.Name = "TYhtmlLabelUserInfo";
            this.TYhtmlLabelUserInfo.Size = new System.Drawing.Size(273, 26);
            this.TYhtmlLabelUserInfo.TabIndex = 2;
            this.TYhtmlLabelUserInfo.Text = "Kullanıcı, Yaşı ve Cinsiyeti";
            // 
            // TYAnasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 206);
            this.Controls.Add(this.TYhtmlLabelUserInfo);
            this.Controls.Add(this.metroTile2);
            this.Controls.Add(this.metroTile1);
            this.MaximizeBox = false;
            this.Name = "TYAnasayfa";
            this.Resizable = false;
            this.ShowIcon = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TYAnasayfa_FormClosed);
            this.Load += new System.EventHandler(this.TYAnasayfa_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Drawing.Html.HtmlLabel TYhtmlLabelUserInfo;
    }
}