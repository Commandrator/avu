using MetroFramework.Controls;
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
    public partial class TYTelefonRehberi : MetroFramework.Forms.MetroForm
    {
        public int ID = -1;             //Kullanıcı telefon rehberinin çekilmesi için kullanılacak.
        public string USERNAME = String.Empty;
        public string BIRTHDATE = String.Empty;
        public string GENDER = String.Empty;
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");
        public TYTelefonRehberi()
        {
            InitializeComponent();
        }

        private void TYTelefonRehberi_Load(object sender, EventArgs e)
        {
            GetTelephoneDirectoryDB();
        }
        private void TYTelefonRehberi_FormClosed(object sender, FormClosedEventArgs e)
        {
            TYAnasayfa anasayfa = new TYAnasayfa()
            {
                ID = ID, 
                USERNAME = USERNAME,
                BIRTHDATE = BIRTHDATE,
                GENDER = GENDER
            };
            anasayfa.Show();
            this.Hide();
        }

        private void TYMetroButtonKayıt_Click(object sender, EventArgs e)
        {
            TYRehbereKisiEkle newForm = new TYRehbereKisiEkle()
            {
                ID = ID
            };
            newForm.ShowDialog();
        }
        private void GetTelephoneDirectoryDB()
        {
            try
            {
                string getuserData = "SELECT TY_TELEPHONEDIRECTORY.TY_NAME AS 'isim', TY_TELEPHONEDIRECTORY.TY_SURNAME AS 'soyisim', TY_TELEPHONENUMBER.TY_NUMBER AS 'numara', TY_TELEPHONENUMBER.TY_TYPE AS 'tip' FROM TY_TELEPHONEDIRECTORY, TY_TELEPHONENUMBER, TY_USERS WHERE TY_USERS.TY_ID = @ID AND TY_USERS.TY_ID = TY_TELEPHONEDIRECTORY.TY_TDID AND TY_TELEPHONEDIRECTORY.TY_ID = TY_TELEPHONENUMBER.TY_NUMBER_ID ORDER BY TY_TELEPHONEDIRECTORY.TY_ID DESC";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(getuserData, connection);
                sqlCommand.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                TYMetroGridRehber.DataSource = dataTable;
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

        private void TY_Click(object sender, EventArgs e)
        {
            GetTelephoneDirectoryDB();
        }

    }
}
