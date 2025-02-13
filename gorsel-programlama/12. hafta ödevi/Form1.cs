using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _12.hafta_ödevi
{
    public partial class save : Form
    {
        public save()
        {
            InitializeComponent();
        }
        Regex name = new Regex(@"^[a-zA-z]{2}[a-zA-Z]*$");
        Regex eposta = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
        Regex telFormat1 = new Regex(@"^+90(([0-9]{3})-([0-9]{3})-([0-9]{2})-([0-9]{2}))$");
        Regex telFormat2 = new Regex(@"^+44(([0-9]{3})-([0-9]{3})-([0-9]{2})-([0-9]{2}))$");
        private void selectPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog resimDosya = new OpenFileDialog();
            resimDosya.Filter = "Resim Dosyası |*.jpg;*.png | Tüm Dosyalar |*.*";
            resimDosya.ShowDialog();
            string resimDosyaYolu = resimDosya.FileName;
            textBox4.Text = resimDosyaYolu;
        }

        private void save_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!name.IsMatch(textBox1.Text))
            {
                MessageBox.Show("İsim formatını gözden geçirin.", "isim regex hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.Text == "" || (comboBox1.Text == "Türkiye" && !telFormat1.IsMatch(textBox2.Text)) || (comboBox1.Text == "İngiltere" && !telFormat2.IsMatch(textBox2.Text)))
            {
                MessageBox.Show("Ülke formatınızı gözden geçirin.", "Telefon regex hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!eposta.IsMatch(textBox3.Text))
            {
                MessageBox.Show("Eposta formatını gözden geçirin.", "Eposta regex hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string adSoyad = textBox1.Text;
                string eposta = textBox2.Text;
                string tel = textBox3.Text;
                dataGridView1.Rows.Add(adSoyad, eposta, tel); ;
                textBox1.Text = "";
                textBox4.Text = "";
            }
        }

    }
}
