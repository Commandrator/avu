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
    public partial class TYYeniKayit : Form
    {
        Random random = new Random();       // random'un çağırılması durumnda rasgele bir sayı dönecektir.
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");
        public int gendetValue = 0;
        public TYYeniKayit()
        {
            InitializeComponent();
        }

        private void TYYeniKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            TYFormGiris TYgirisForm = new TYFormGiris();
            TYgirisForm.Show();
            this.Hide();
        }

        private void TYbuttonKaydet_Click(object sender, EventArgs e)
        {
            if (TYtextBoxKullaniciAdi.Text == "")
                MessageBox.Show("Kullanıcı adı boş olamaz.", "KULLANICI ADI BOŞ OLAMAZ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYtextBoxSifre.Text == "")
                MessageBox.Show("Şifre boş olamaz.", "ŞİFRE BOŞ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYcomboBoxCinsiyet.Text == "Cinsiyet Seç")
                MessageBox.Show("Cinsiyet seçimi yapınız.", "CİNSİYET SEÇİLMEDİ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!Regex.IsMatch(TYtextBoxKullaniciAdi.Text, @"^[0-9a-zA-Z]+$")) //Kullanıcı adı sadece rakam ve harflerden oluşabilir.
                    MessageBox.Show("Lütfen kullanıcı adına \"ş, ö, ı, ç, ğ ve ü\" harflerini;\n\"!^%+&/(*\" gibi özel karakter girmeyin.");
                else if (!Regex.IsMatch(TYtextBoxIsim.Text, @"^[a-zA-ZöçşğüıÖÇŞĞÜ]+$")) // yalnız türkçe karakterleri alması için.
                    MessageBox.Show("Lütfen isim sayı ve özel karakter içermemeli");
                else if (!Regex.IsMatch(TYtextBoxSoyisim.Text, @"^[a-zA-ZöçşğüıÖÇŞĞÜ]+$"))// yalnız türkçe karakterleri alması için.
                    MessageBox.Show("Lütfen soyisim sayı ve özel karakter içermemeli");
                else if (!Regex.IsMatch(TYtextBoxSifre.Text, @"^(?=.*[A-Za-z0-9])(?=.*[@#$%^&+=]).{6,}$")) // büyük-küçük harf ya da sayı olabailir; içinde özel karakter olmalı ve en az 6 karakter olmalı.
                    MessageBox.Show("Lütfen en az 6 ve içerisinde en az 1 tane özel karakter olan daha güçlü bir şifre girin.");
                else if (TYdateTimePickerYas.Value.Day == DateTime.Now.Day)
                    MessageBox.Show("Doğum yılınızı kontrol ediniz.");
                else
                    _db();
            }
        }
        private void _db()
        {
            try
            {
                connection.Open();
                SqlCommand _username = new SqlCommand("SELECT * FROM TY_USERS WHERE TY_USERS.TY_USERNAME=@username", connection);
                _username.Parameters.AddWithValue("@username", TYtextBoxKullaniciAdi.Text);
                SqlDataReader user_query = _username.ExecuteReader();
                if (user_query.Read() != true)
                {
                    user_query.Close(); // yukardaki sorguyu kapatmak için, açık olduğu zaman 2. sorguyu yapmıyor.
                    try
                    {
                        if (TYcomboBoxCinsiyet.Text == "Erkek")
                            gendetValue = 1;
                        else if (TYcomboBoxCinsiyet.Text == "Kadın")
                            gendetValue = 0;
                        else
                            gendetValue = 0;
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO TY_USERS (TY_USERNAME, TY_NAME, TY_SURNAME, TY_PASSWORD, TY_BIRTHDATE, TY_GENDER) VALUES (@username, @name, @surname, @password, @birthdate, @gender)", connection);
                        sqlCommand.Parameters.AddWithValue("@name", TYtextBoxIsim.Text);
                        sqlCommand.Parameters.AddWithValue("@username", TYtextBoxKullaniciAdi.Text);
                        sqlCommand.Parameters.AddWithValue("@surname", TYtextBoxSoyisim.Text);
                        sqlCommand.Parameters.AddWithValue("@password", TYtextBoxSifre.Text);
                        sqlCommand.Parameters.AddWithValue("@birthdate", TYdateTimePickerYas.Value);
                        sqlCommand.Parameters.AddWithValue("@gender", gendetValue);
                        sqlCommand.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı esnasında bir hata oluştu.\n\n" + ex.ToString(), "Hata");
                    }
                    finally
                    {
                        connection.Close();
                        Form giris = new TYFormGiris();
                        giris.Show();
                        this.Hide();
                    }
                }
                else
                {
                    user_query.Close(); // yukardaki sorguyu kapatmak için, açık olduğu zaman 2. sorguyu yapmıyor.
                    MessageBox.Show("Bu kullanıcı adı daha önce alınmış,\nBaşka bir kullanıcı adı deneyin.", "Kullanıcı adı mevcut", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı esnasında bir hata oluştu.\n\n" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
