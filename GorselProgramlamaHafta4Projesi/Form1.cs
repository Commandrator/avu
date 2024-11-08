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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //String userName = "admin";
        //String password = "admin";

        public static bool CheckUsername(String username) {

            var usernames = new[] {"admin", "smtdncr", "ogrenci"};
            return usernames.Contains(username);
        }

        public static bool CheckPassword(String password) {
            var passwords = new[] { "admin", "smtdncr", "ogrenci" };
            return passwords.Contains(password);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Kullanıcı adı veya şifre alanı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!CheckUsername(txtUserName.Text))
            {
                MessageBox.Show("Kullanıcı adını yanlış girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!CheckPassword(txtPassword.Text))
            {
                MessageBox.Show("Şifrenizi yanlış girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                String userName = txtUserName.Text;
                Form2 frm2 = new Form2() { 
                    userName = userName
                };
                frm2.Show();
                this.Hide();
            }
        }
    }
}
