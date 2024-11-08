using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _10040TalhaYasar
{
    public partial class TYFormGiris : Form
    {

        Random random = new Random();       // random'un çağırılması durumnda rasgele bir sayı dönecektir.
        int randomNumber;                   // Bu yukardakinden bağımsız bir tamsayı değiştenidir.
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");
        public TYFormGiris()
        {
            InitializeComponent();
        }

        private void TYbuttonGiris_Click(object sender, EventArgs e)
        {
            if (TYtextBoxKullaniciAdi.Text == "")
                MessageBox.Show("Kullanıcı adı boş olamaz.", "AD BOŞ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYtextBoxSifre.Text == "")
                MessageBox.Show("Şifre boş olamaz.", "ŞİFRE BOŞ OLAMAZ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYtextBoxGuvenlikKodu.Text == "")
                MessageBox.Show("Güvenlik kodunu girin", "GÜVENLİK KODU BOŞ OLAMAZ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (Regex.IsMatch(TYtextBoxGuvenlikKodu.Text, @"^[0-9]{6}$") && TYtextBoxGuvenlikKodu.Text == randomNumber.ToString())
                {
                    try
                    {
                        object ID = 0;
                        string USERNAME = String.Empty;
                        string BIRTHDATE = String.Empty;
                        string GENDER = String.Empty;

                        connection.Open();

                        SqlCommand user = new SqlCommand("select TY_ID, TY_USERNAME, TY_BIRTHDATE, TY_GENDER from TY_USERS WHERE TY_USERS.TY_USERNAME=@username AND TY_USERS.TY_PASSWORD=@password", connection);
                        user.Parameters.AddWithValue("@username", TYtextBoxKullaniciAdi.Text);
                        user.Parameters.AddWithValue("@password", TYtextBoxSifre.Text);

                        SqlDataReader user_query = user.ExecuteReader();

                        if (user_query.Read())
                        {
                            DateTime dogumTarihi = Convert.ToDateTime(user_query.GetValue(2));  // Veri tabanından kullanıcının doğum tarihi seçilir.
                            DateTime bugun = DateTime.Now;                                      // bu günkü tarih alınır.
                            TimeSpan yasFarki = bugun - dogumTarihi;                            // şimdikiki tarihten doğum tarihi çıkartılır.
                            int yas = (int)(yasFarki.TotalDays / 365.25);                       // oluşan toplam gün sayısına çevirmek için 365.25' bölünür ve yaş değişkenine atanır.
                            string gender = String.Empty;
                            int genderData = Convert.ToInt32(user_query.GetValue(3));           // Gelend cinsiyet verisinin int türüne dönüştürülmesi için kullanıldı.
                            if (genderData  == 0)
                                gender = "Kadın";
                            else if (genderData == 1)
                                gender = "Erkek";
                            else
                                gender = "Belirtilmedi";

                            TYAnasayfa anasayfa = new TYAnasayfa                                // Yeni anasayfa formu oluşturmak için.
                            {
                                ID = user_query.GetValue(0),              // UserQuery içindeki oluşan dizide 0. elemanı çekip  ID olarak, oluşturulan forma aktarıyor.
                                USERNAME = user_query.GetValue(1).ToString(),                   // UserQuery içincekis diziden 1. elemanı çekip USERNAME olarka, oluşturulan froma aktarılıyor.
                                // NOT: İSİM VE SOY İSİM BİLGİLERİNİN KULLANILMASI İSTENMEDİĞİ İÇİN ÜST KOMPONENTE AKTARILMADI
                                BIRTHDATE = yas.ToString(),
                                GENDER = gender
                            };

                            anasayfa.Show();                    //Oluşan formu göstermek için.
                            this.Hide();                        //Aktif formu gizlemek için.
                        }
                        else
                            MessageBox.Show("Bu hesap mevcut değil", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else
                {
                    randomNumber = random.Next(100000, 999999);     // 6 haneli rasgele bir sayı oluşturmak için üst taraftaki random'u kullanacaktır. Hata olması durumunda sayının değişmesi için.
                    TYlabelKod.Text = randomNumber.ToString();      // label'a gidecek random sayının string türünde olması gerekmektedir. Hata durumunda sayının labele yeniden yazdırılması için.
                    MessageBox.Show("Güvenlik kodu hatalı.", "GÜVENLİK KODU HATASI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void TYFormGiris_Load(object sender, EventArgs e)
        {
            randomNumber = random.Next(100000, 999999);     // 6 haneli rasgele bir sayı oluşturmak için üst taraftaki random'u kullanacaktır.
            TYlabelKod.Text = randomNumber.ToString();      // label'a gidecek random sayının string türünde olması gerekmektedir.
        }

        private void TYlinkLabelYeniKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form YeniKayit = new TYYeniKayit();
            YeniKayit.Show();
            this.Hide();
        }

        private void TYFormGiris_FormClosed(object sender, FormClosedEventArgs e)
        {
            CIKIS();
        }

        private static void CIKIS()
        {
            Application.Exit();
        }
    }
}
