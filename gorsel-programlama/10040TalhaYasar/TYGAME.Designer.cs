namespace _10040TalhaYasar
{
    partial class TYGAME
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
            this.TYmetroLabel = new MetroFramework.Controls.MetroLabel();
            this.TYmetroRadioButtonKolay = new MetroFramework.Controls.MetroRadioButton();
            this.TYmetroRadioButtonOrta = new MetroFramework.Controls.MetroRadioButton();
            this.TYmetroRadioButtonZor = new MetroFramework.Controls.MetroRadioButton();
            this.TYmetroButtonBasla = new MetroFramework.Controls.MetroButton();
            this.TYmetroListViewSkor = new MetroFramework.Controls.MetroListView();
            this.SuspendLayout();
            // 
            // TYmetroLabel
            // 
            this.TYmetroLabel.AutoSize = true;
            this.TYmetroLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TYmetroLabel.Location = new System.Drawing.Point(94, 60);
            this.TYmetroLabel.Name = "TYmetroLabel";
            this.TYmetroLabel.Size = new System.Drawing.Size(112, 19);
            this.TYmetroLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.TYmetroLabel.TabIndex = 0;
            this.TYmetroLabel.Text = "ZORLUK SEVİYESİ";
            // 
            // TYmetroRadioButtonKolay
            // 
            this.TYmetroRadioButtonKolay.AutoSize = true;
            this.TYmetroRadioButtonKolay.Location = new System.Drawing.Point(121, 102);
            this.TYmetroRadioButtonKolay.Name = "TYmetroRadioButtonKolay";
            this.TYmetroRadioButtonKolay.Size = new System.Drawing.Size(58, 15);
            this.TYmetroRadioButtonKolay.TabIndex = 1;
            this.TYmetroRadioButtonKolay.Text = "KOLAY";
            this.TYmetroRadioButtonKolay.UseSelectable = true;
            // 
            // TYmetroRadioButtonOrta
            // 
            this.TYmetroRadioButtonOrta.AutoSize = true;
            this.TYmetroRadioButtonOrta.Location = new System.Drawing.Point(125, 136);
            this.TYmetroRadioButtonOrta.Name = "TYmetroRadioButtonOrta";
            this.TYmetroRadioButtonOrta.Size = new System.Drawing.Size(51, 15);
            this.TYmetroRadioButtonOrta.TabIndex = 2;
            this.TYmetroRadioButtonOrta.Text = "ORTA";
            this.TYmetroRadioButtonOrta.UseSelectable = true;
            // 
            // TYmetroRadioButtonZor
            // 
            this.TYmetroRadioButtonZor.AutoSize = true;
            this.TYmetroRadioButtonZor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TYmetroRadioButtonZor.Location = new System.Drawing.Point(127, 167);
            this.TYmetroRadioButtonZor.Name = "TYmetroRadioButtonZor";
            this.TYmetroRadioButtonZor.Size = new System.Drawing.Size(46, 15);
            this.TYmetroRadioButtonZor.TabIndex = 3;
            this.TYmetroRadioButtonZor.Text = "ZOR";
            this.TYmetroRadioButtonZor.UseSelectable = true;
            // 
            // TYmetroButtonBasla
            // 
            this.TYmetroButtonBasla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TYmetroButtonBasla.Location = new System.Drawing.Point(94, 199);
            this.TYmetroButtonBasla.Name = "TYmetroButtonBasla";
            this.TYmetroButtonBasla.Size = new System.Drawing.Size(112, 23);
            this.TYmetroButtonBasla.TabIndex = 4;
            this.TYmetroButtonBasla.Text = "Başla";
            this.TYmetroButtonBasla.UseSelectable = true;
            this.TYmetroButtonBasla.Click += new System.EventHandler(this.metroButton1_Click_1);
            // 
            // TYmetroListViewSkor
            // 
            this.TYmetroListViewSkor.BackColor = System.Drawing.SystemColors.Desktop;
            this.TYmetroListViewSkor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TYmetroListViewSkor.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TYmetroListViewSkor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TYmetroListViewSkor.FullRowSelect = true;
            this.TYmetroListViewSkor.GridLines = true;
            this.TYmetroListViewSkor.LabelWrap = false;
            this.TYmetroListViewSkor.Location = new System.Drawing.Point(15, 240);
            this.TYmetroListViewSkor.Name = "TYmetroListViewSkor";
            this.TYmetroListViewSkor.Size = new System.Drawing.Size(271, 149);
            this.TYmetroListViewSkor.TabIndex = 5;
            this.TYmetroListViewSkor.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TYmetroListViewSkor.UseCompatibleStateImageBehavior = false;
            this.TYmetroListViewSkor.UseSelectable = true;
            this.TYmetroListViewSkor.View = System.Windows.Forms.View.Details;
            // 
            // TYGAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.TYmetroListViewSkor);
            this.Controls.Add(this.TYmetroButtonBasla);
            this.Controls.Add(this.TYmetroRadioButtonZor);
            this.Controls.Add(this.TYmetroRadioButtonOrta);
            this.Controls.Add(this.TYmetroRadioButtonKolay);
            this.Controls.Add(this.TYmetroLabel);
            this.MaximizeBox = false;
            this.Name = "TYGAME";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MATEMATİK OYUNU";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.SeaGreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TYGAME_FormClosed);
            this.Load += new System.EventHandler(this.TYGAME_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel TYmetroLabel;
        private MetroFramework.Controls.MetroRadioButton TYmetroRadioButtonKolay;
        private MetroFramework.Controls.MetroRadioButton TYmetroRadioButtonOrta;
        private MetroFramework.Controls.MetroRadioButton TYmetroRadioButtonZor;
        private MetroFramework.Controls.MetroButton TYmetroButtonBasla;
        private MetroFramework.Controls.MetroListView TYmetroListViewSkor;
    }
}