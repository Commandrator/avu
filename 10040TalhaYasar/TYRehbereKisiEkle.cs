using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _10040TalhaYasar
{
    public partial class TYRehbereKisiEkle : MetroFramework.Forms.MetroForm
    {
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");
        public int ID = -1;
        public TYRehbereKisiEkle()
        {
            InitializeComponent();
        }

        private void TYRehbereKisiEkle_Load(object sender, EventArgs e)
        {
 
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (TYmetroTextBoxIsım.Text == "")
                MessageBox.Show("Bir isim girin.", "İSİM BOŞ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYmetroTextBoxSoyisim.Text == "")
                MessageBox.Show("Bir soyisim girin.", "SOYİSİM BOŞ OLAMAZ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TYmetroTextBoxTelefon.Text == "")
                MessageBox.Show("Bir telefon numarası girin.", "TELEFON NUMARASI BOŞ OLAMAZ HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string _regex = @"^[a-zA-ZçÇğĞıİöÖşŞüÜ]+$";             //hem isimde hem soy isimde türkçe karakter olduğu için tek bir değişken yardımı ile çalıştırmak için.
                if (!Regex.IsMatch(TYmetroTextBoxIsım.Text, _regex))    //Gelen geğer yanılş ise doğruya çevirip hata mesajının görükmei sağlanacak.
                    MessageBox.Show("İsim rakam içermemelidir.", "İSİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!Regex.IsMatch(TYmetroTextBoxSoyisim.Text, _regex))
                    MessageBox.Show("Soyisim rakam içermemelidir.", "SOYİSİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!Regex.IsMatch(TYmetroTextBoxTelefon.Text, @"^0[0-9]{10}$"))
                    MessageBox.Show("Lütfen başında 0 olan 11 haneli kişi numarasını girin.", "TELFON NUMARASI HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        connection.Open();
                        int k = 0;
                        //ID BULMA SORGUSU
                        while(k != -1 )     //Kişi kaydı yoksa kaydın eklenmesinina 
                        {
                            int userID = foundAddedUserId();        //-1 kullanıcı olmadığı anlamında gelir.
                            if (userID != -1)
                            {
                                //ID'Sİ BULUNMUŞ KİŞİNİN TELEFONUNU REHBERE EKLEME SORGUSU
                                saveUserOfTelephoneDirectory(userID);
                                k = -1;
                            }
                            else if (userID == -1)
                            {
                                //KİŞİ EKLEME SORGUSU
                                addTelephoneDirectory();
                            }
                            else
                            {
                                MessageBox.Show("Kayıt esnasında beklenmeyen bir hata ile karşılaşıldı", "DANIŞAN EKLEME HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                k = -1;
                            }
                        }                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }            
        }
        private void addTelephoneDirectory()
        {
            string sorgu = "INSERT INTO TY_TELEPHONEDIRECTORY(TY_TDID, TY_NAME, TY_SURNAME) VALUES(@ID, @NAME, @SURNAME)";
            SqlCommand sqlCommand = new SqlCommand(sorgu, connection);
            sqlCommand.Parameters.AddWithValue("@ID", ID);
            sqlCommand.Parameters.AddWithValue("@NAME", TYmetroTextBoxIsım.Text);
            sqlCommand.Parameters.AddWithValue("@SURNAME", TYmetroTextBoxSoyisim.Text);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();// Bir sonraki sorgu işlemini yapabilmek için SqlCommand nesnesini kapatır.
        }
        private void saveUserOfTelephoneDirectory(int foundID)
        {
            string sorgu = "INSERT INTO TY_TELEPHONENUMBER(TY_NUMBER_ID, TY_TYPE, TY_NUMBER) VALUES(@ID, @TYPE, @NUMBER)";
            SqlCommand sqlAddNumber = new SqlCommand(sorgu, connection);
            sqlAddNumber.Parameters.AddWithValue("@ID", foundID);
            sqlAddNumber.Parameters.AddWithValue("@TYPE", TYlistBoxType.SelectedItem.ToString());
            sqlAddNumber.Parameters.AddWithValue("@NUMBER", Convert.ToInt64(TYmetroTextBoxTelefon.Text));
            sqlAddNumber.ExecuteNonQuery();
            MessageBox.Show($"{TYmetroTextBoxIsım.Text + ' ' + TYmetroTextBoxSoyisim.Text} kişisi rehbere eklendi", "DANIŞAN EKLEME HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private int foundAddedUserId()
        {
            string sorgu = "SELECT TY_ID FROM TY_TELEPHONEDIRECTORY WHERE TY_TDID = @ID AND TY_NAME = @NAME AND TY_SURNAME = @SURNAME";
            SqlCommand sqlFoundID = new SqlCommand(sorgu, connection);
            sqlFoundID.Parameters.AddWithValue("@ID", ID);
            sqlFoundID.Parameters.AddWithValue("@NAME", TYmetroTextBoxIsım.Text);
            sqlFoundID.Parameters.AddWithValue("@SURNAME", TYmetroTextBoxSoyisim.Text);
            using (SqlDataReader FaundedID = sqlFoundID.ExecuteReader())
            {
                if (FaundedID.HasRows)
                {
                    FaundedID.Read();// Bir sonraki sorgu işlemini yapabilmek için SqlCommand nesnesini kapatır.
                    int foundID = FaundedID.GetInt32(0);
                    FaundedID.Close();
                    return foundID;
                }
                else
                    return -1;
            }
        }
    }
}
