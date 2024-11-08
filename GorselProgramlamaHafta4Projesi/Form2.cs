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
    public partial class Form2 : Form
    {
        public string userName = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }

        private void ürünEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }

        private void yeniMalzemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
            */

            button1.PerformClick();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Sayın " + userName + " hoşgeldiniz.";
            label1.ForeColor = Color.Red;
        }
    }
}
