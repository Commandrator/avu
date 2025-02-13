using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace _10040TalhaYasar
{
    public partial class TYAnasayfa : MetroFramework.Forms.MetroForm
    {
        public object ID    = -1;    // Üst komponennten gelen verinin tanımlayıcısıdır.
        public string USERNAME  = String.Empty;
        public string BIRTHDATE = String.Empty;
        public string GENDER    = String.Empty;
        public TYAnasayfa()
        {
            InitializeComponent();
        }

        private void TYAnasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            TYTelefonRehberi rehber = new TYTelefonRehberi()
            {
                ID = Convert.ToInt32(ID),
                USERNAME = USERNAME,
                GENDER = GENDER,
                BIRTHDATE = BIRTHDATE
            };
            rehber.Show();
            this.Hide();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            TYGAME TYMATHGAME = new TYGAME()
            {
                ID = Convert.ToInt32(ID),
                USERNAME = USERNAME,
                GENDER = GENDER,
                BIRTHDATE = BIRTHDATE
            };
            TYMATHGAME.Show();
            this.Hide();
        }

        private void TYAnasayfa_Load(object sender, EventArgs e)
        {
            TYhtmlLabelUserInfo.Text = $"Kullanıcı: {USERNAME}\tYaşı: {BIRTHDATE}\tCinsiyeti: {GENDER}";
        }
    }
}
