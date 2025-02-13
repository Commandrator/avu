using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorselProgramlamaHafta4Projesi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //groupBox1.Hide();
            groupBox1.Visible = false;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Lütfen boş bırakmayınız!","Boşluk Kontrol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else { 
                DialogResult cevap = MessageBox.Show("Eklemeyi onaylıyor musunuz?", "Onay İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cevap == DialogResult.Yes)
                {
                    String productCode = textBox1.Text;
                    String productName = textBox2.Text;
                    String type = comboBox1.Text;
                    String price = textBox3.Text;
                    String supplier = textBox4.Text;

                    label11.Text = productCode;
                    label12.Text = productName;
                    label13.Text = type;
                    label14.Text = price;
                    label15.Text = supplier;

                    groupBox1.Visible = true;

                    textBox1.Text = "";
                    textBox2.Clear();
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.SelectedIndex = 0;

                    MessageBox.Show("Kayıt işleminizi gerçekleştirdiniz", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            /* 
              if (checkBox1.Checked)
             {
                 String productCode = textBox1.Text;
                 String productName = textBox2.Text;
                 String type = comboBox1.Text;
                 String price = textBox3.Text;
                 String supplier = textBox4.Text;

                 label11.Text = productCode;
                 label12.Text = productName;
                 label13.Text = type;
                 label14.Text = price;
                 label15.Text = supplier;

                 groupBox1.Visible = true;

                 textBox1.Text = "";
                 textBox2.Clear();
                 textBox3.Text = "";
                 textBox4.Text = "";
                 comboBox1.SelectedIndex = 0;

                 MessageBox.Show("Kayıt işleminizi gerçekleştirdiniz", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
             else {
                 MessageBox.Show("Kayıt onayı vermediğiniz taktirde işleminiz kayıt edilmez","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
             }
             */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                button1.Enabled = true;
            if (!checkBox1.Checked)
                button1.Enabled = false;
        }
    }
}
