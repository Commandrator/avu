using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10040TalhaYasar
{
    public partial class TYGAME : MetroFramework.Forms.MetroForm
    {
        public int ID = -1;    // Üst komponennten gelen verinin tanımlayıcısıdır.
        public string USERNAME = String.Empty;
        public string BIRTHDATE = String.Empty;
        public string GENDER = String.Empty;
        public int zorluk = 0;
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");
        public TYGAME()
        {
            InitializeComponent();
        }

        private void TYGAME_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string sorgu = "SELECT TY_ID, TY_DATE, TY_SCORE, TY_QUESTION FROM TY_GAME WHERE TY_ID=@userId ORDER BY ID DESC";
                SqlCommand game = new SqlCommand(sorgu, connection);
                game.Parameters.AddWithValue("@userId", ID);
                SqlDataReader user_query = game.ExecuteReader();
                if (user_query.HasRows)
                {
                    TYmetroListViewSkor.View = View.Details; // Görünümü ayrıntılar moduna ayarla
                    TYmetroListViewSkor.Columns.Add("Tarih", 100);
                    TYmetroListViewSkor.Columns.Add("Puan", 100);
                    while (user_query.Read())
                    {
                        DateTime dateTime = Convert.ToDateTime(user_query["TY_DATE"]);
                        string tarih = dateTime.ToShortDateString();
                        int skor = Convert.ToInt32(user_query["TY_SCORE"]);
                        int soruSayisi = Convert.ToInt32(user_query["TY_QUESTION"]);
                        int puan = (soruSayisi == 0 ? 0 : 100 / soruSayisi) * skor ;

                        ListViewItem item = new ListViewItem();
                        item.Text = tarih;
                        item.SubItems.Add(puan.ToString());
                        TYmetroListViewSkor.Items.Add(item);
                    }
                }
                else
                {
                    TYmetroListViewSkor.Visible = false;
                    this.Size = new Size(300, 250);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı esnasında bir hata oluştu.\n\n" + ex.ToString(), "Hata");
            }
            finally
            {
                connection.Close();
            }
        }

        private void TYGAME_FormClosed(object sender, FormClosedEventArgs e)
        {
            TYAnasayfa anasayfa = new TYAnasayfa()
            {
                ID = ID,
                USERNAME = USERNAME,
                GENDER = GENDER,
                BIRTHDATE = BIRTHDATE
            };
            anasayfa.Show();
            this.Hide();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            if (TYmetroRadioButtonKolay.Checked == true)
                zorluk = 0;
            else if (TYmetroRadioButtonOrta.Checked == true)
                zorluk = 1;
            else if (TYmetroRadioButtonZor.Checked == true)
                zorluk = 2;
            else
                zorluk = 0;
            Form soru = new TYSoru()
            {
                ID = ID,
                USERNAME = USERNAME,
                GENDER = GENDER,
                BIRTHDATE = BIRTHDATE,
                zorluk = zorluk
            };
            soru.Show();
            this.Hide();
        }

    }
}
