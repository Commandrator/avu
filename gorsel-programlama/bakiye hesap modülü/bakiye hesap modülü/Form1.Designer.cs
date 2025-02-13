namespace bakiye_hesap_modülü
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            button1 = new Button();
            groupBox3 = new GroupBox();
            label5 = new Label();
            comboBox2 = new ComboBox();
            dateTimePicker2 = new DateTimePicker();
            label4 = new Label();
            groupBox2 = new GroupBox();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            groupBox4 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBox2 = new TextBox();
            label6 = new Label();
            islem = new DataGridViewTextBoxColumn();
            kimden = new DataGridViewTextBoxColumn();
            kime = new DataGridViewTextBoxColumn();
            Verilen_tarih = new DataGridViewTextBoxColumn();
            anlinacak_tarih = new DataGridViewTextBoxColumn();
            miktar = new DataGridViewTextBoxColumn();
            verecek = new DataGridViewTextBoxColumn();
            Bakiye = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.ControlDarkDark;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { islem, kimden, kime, Verilen_tarih, anlinacak_tarih, miktar, verecek, Bakiye });
            dataGridView1.Location = new Point(312, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(846, 479);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Location = new Point(11, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(295, 479);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Borç-Alıcı işlemir";
            // 
            // button1
            // 
            button1.Location = new Point(176, 444);
            button1.Name = "button1";
            button1.Size = new Size(110, 29);
            button1.TabIndex = 10;
            button1.Text = "İşlemi Onayla";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Controls.Add(dateTimePicker2);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(8, 282);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(279, 130);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Alıcı";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 90);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 11;
            label5.Text = "Tarih:";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(87, 28);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(170, 23);
            comboBox2.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(87, 86);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(170, 23);
            dateTimePicker2.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 32);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 0;
            label4.Text = "Alıcı:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new Point(7, 125);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(279, 139);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Borç veren";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 91);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "Tarih:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(88, 87);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(170, 23);
            dateTimePicker1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(88, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(170, 23);
            textBox1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 58);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Miktar:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 3;
            label1.Text = "Borç veren:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(88, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(170, 23);
            comboBox1.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(radioButton2);
            groupBox4.Controls.Add(radioButton1);
            groupBox4.Location = new Point(8, 22);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(278, 90);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "işlem tipi";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(12, 53);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(61, 19);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Borç al";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(14, 23);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(68, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Borç ver";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(87, 57);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(170, 23);
            textBox2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 60);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 8;
            label6.Text = "Miktar:";
            // 
            // islem
            // 
            islem.HeaderText = "işlem";
            islem.Name = "islem";
            // 
            // kimden
            // 
            kimden.HeaderText = "Kimden (Borç sahibi)";
            kimden.Name = "kimden";
            kimden.Width = 75;
            // 
            // kime
            // 
            kime.HeaderText = "Kime (Alıcı)";
            kime.Name = "kime";
            // 
            // Verilen_tarih
            // 
            Verilen_tarih.HeaderText = "Ne Zaman (İşlem yapılaacağı Tarih)";
            Verilen_tarih.Name = "Verilen_tarih";
            // 
            // anlinacak_tarih
            // 
            anlinacak_tarih.HeaderText = "Ne zaman(Alınacak Tarih)";
            anlinacak_tarih.Name = "anlinacak_tarih";
            anlinacak_tarih.Width = 130;
            // 
            // miktar
            // 
            miktar.HeaderText = "Ne Kadar (Alacak)";
            miktar.Name = "miktar";
            // 
            // verecek
            // 
            verecek.HeaderText = "Ne Kadar(Verecek)";
            verecek.Name = "verecek";
            // 
            // Bakiye
            // 
            Bakiye.HeaderText = "Bakiye";
            Bakiye.Name = "Bakiye";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 516);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private Button button1;
        private GroupBox groupBox3;
        private Label label5;
        private ComboBox comboBox2;
        private DateTimePicker dateTimePicker2;
        private Label label4;
        private GroupBox groupBox2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private ComboBox comboBox1;
        private GroupBox groupBox4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox textBox2;
        private Label label6;
        private DataGridViewTextBoxColumn islem;
        private DataGridViewTextBoxColumn kimden;
        private DataGridViewTextBoxColumn kime;
        private DataGridViewTextBoxColumn Verilen_tarih;
        private DataGridViewTextBoxColumn anlinacak_tarih;
        private DataGridViewTextBoxColumn miktar;
        private DataGridViewTextBoxColumn verecek;
        private DataGridViewTextBoxColumn Bakiye;
    }
}
