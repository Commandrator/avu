using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Görsel_Programlama_hafta_5_db_connction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-9DU7ENM;Initial Catalog=db_hafta_5_proje;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand sqlKomutu = new SqlCommand("SELECT * FROM tabloOgrenci", connection);
                //sqlKomutu.ExecuteNonQuery();
                SqlDataReader sqlDataReader = sqlKomutu.ExecuteReader();
                richTextBox1.Text = richTextBox1.Text + "id" + "\t" + "adi" + "\t" + "not1" + "\t" + "not2" + "\t" + "ort" + "\n\n";
                while (sqlDataReader.Read())
                {
                    string id = sqlDataReader[0].ToString();
                    string adi = sqlDataReader[1].ToString();
                    string not1 = sqlDataReader[2].ToString();
                    string not2 = sqlDataReader[3].ToString();
                    double ort = (Convert.ToDouble(not1) * 0.4) + (Convert.ToDouble(not2) * 0.6);
                    richTextBox1.Text = richTextBox1.Text + id + "\t" + adi + "\t" + not1 + "\t" + not2 + "\t" + ort + "\n";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı esnasında bir hata oluştu." + ex);
            }
            finally { connection.Close(); }
        }

        DataSet ds = new DataSet();
        public void listele()
        {
            try
            {
                connection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tabloOgrenci", connection);
                sqlDataAdapter.Fill(ds, "ogrenci"); //ds değişkenine gelen verileri ekler.
                dataGridView1.DataSource = ds.Tables["ogrenci"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı esnasında bir hata oluştu.\n" + ex);
            }
            finally { connection.Close(); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Visible = true;
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand sqlEkleKomutu = new SqlCommand("insert into tabloOgrenci (ogrenciID, ogrenciAdi, not1, not2) values (@ogrenciID, @ogrenciAdi, @not1, @not2)", connection);
                sqlEkleKomutu.Parameters.AddWithValue("@ogrenciID", textBox1.Text);
                sqlEkleKomutu.Parameters.AddWithValue("@ogrenciAdi", textBox2.Text);
                sqlEkleKomutu.Parameters.AddWithValue("@not1", textBox3.Text);
                sqlEkleKomutu.Parameters.AddWithValue("@not2", textBox4.Text);
                SqlDataReader sqlDR = sqlEkleKomutu.ExecuteReader();
                if (sqlDR != null)
                {
                    MessageBox.Show("Öğrenci başarılı şekilde eklendi.");
                }
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı esnasında bir hata oluştu\n" + ex.ToString());
            }
            finally{
                connection.Close();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.currentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand sqlGuncelleKomutu = new SqlCommand("update TableOgrenci set ogrenciID=@ogrenciId", connection);
                sqlGuncelleKomutu.Parameters.AddWithValue("@ogrenciID", textBox1.Text);
                sqlGuncelleKomutu.Parameters.AddWithValue("@ogrenciAdi", textBox2.Text);
                sqlGuncelleKomutu.Parameters.AddWithValue("@not1", textBox3.Text);
                sqlGuncelleKomutu.Parameters.AddWithValue("@not2", textBox4.Text);
                SqlDataReader sqlDR = sqlGuncelleKomutu.ExecuteReader();
                if (sqlDR != null)
                {
                    MessageBox.Show("Öğrenci başarılı şekilde eklendi.");
                }
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = string.Empty;
                    }
                }
            }
            }
    }
}