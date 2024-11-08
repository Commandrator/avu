using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10040TalhaYasar
{
    public partial class TYSoru : MetroFramework.Forms.MetroForm
    {
        Random random = new Random();
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=TY_22071010040;Integrated Security=True");  //Soru sayısı ve doğru soru sayısının kaydı için.
        int soruda   = 0, totalNumberOfCorrectChoices = 0;
        double cevap = 0;
        int randomRadioBox = 0, a= 0, b= 0, c= 0, soru = 0;
        bool pass = false;
        public int zorluk   = 0; // Üst komonentten gelecek veri
        public int ID       = -1;    // Üst komponennten gelen verinin tanımlayıcısıdır.
        public string USERNAME  = String.Empty;
        public string BIRTHDATE = String.Empty;
        public string GENDER    = String.Empty;
        string zorlukText = "";
        private void metroButton1_Click(object sender, EventArgs e)
        {
            soruda += 1;
            CevapSecimi();
        }

        public TYSoru()
        {
            InitializeComponent();
        }

        private void TYSoru_Load(object sender, EventArgs e)
        {
            TYmetroLabelUser.Text = $"Kullanıcı: {USERNAME}\tYaşı: {BIRTHDATE}\tCinsiyeti: {GENDER}";
            TYmetroLabelSoru.Text = $"soru ({soruda + 1}) zorluk: {zorlukText} doğru: {totalNumberOfCorrectChoices}";
            SoruSecimi();
        }
        private void soruSeviye()
        {
            if (zorluk == 0)
                zorlukText = "Kolay";
            else if (zorluk == 1)
                zorlukText = "Orta";
            else if (zorluk == 2)
                zorlukText = "Zor";
            else
                zorlukText = "hata";
        }
        private void TYSoru_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Çıkmak istediğine emin misin?", "Oyundan çık", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                StartGame();
            }
            else if (result == DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = true;
        }
        private void StartGame()
        {
            TYGAME form = new TYGAME()
            {
                ID=ID,
                USERNAME = USERNAME,
                GENDER = GENDER,
                BIRTHDATE = BIRTHDATE
            };
            form.Show();
            Hide();
        }
        private void SoruSecimi()
        {
            soruSeviye();
            if (zorluk == 0)        //Kolay
                metroTextBox1.Text = kolay();
            else if (zorluk == 1)   //Orta
                metroTextBox1.Text = orta();
            else if (zorluk == 2)   //Zor
                metroTextBox1.Text = zor();
            else
                MessageBox.Show("Beklenmeyen bir hata oluştu. \nSeçim menüsüne yönlendirileceksiniz.", "ZORLUK SEÇİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CevapOlustur();
        }
        private string kolay()
        {
            a = random.Next(1, 15);
            b = random.Next(1, 15);
            c = random.Next(1, 15);
            randomRadioBox = random.Next(1, 5);
            soru = random.Next(1, 4);
            if (soru == 1)
            {
                cevap = a * b * 2;
                return $"{a} sayısı ile {b} sayısının çarpımının 2 katı kaçtır?";
            }
            else if (soru == 2)
            {
                cevap = (a - b) / c;
                return $"{a} sayısı ile {b} sayısının farkının {c} ile bölümünden kalan kaçtır?";
            }
            else if (soru == 3)
            {
                cevap = (a + b) * c;
                return metroTextBox1.Text = $"{a} sayısı ile {b} sayısının toplamının {c} katı kaçtır?";
            }
            else if (soru == 4)
            {
                cevap = a / b * c;
                return metroTextBox1.Text = $"{a} sayısı ile {b} sayısının bölümünün {c} katı kaçtır?";
            }
            else
            {
                cevap = 0;
                MessageBox.Show("Beklenmeyen bir hata ile karşılaşıldı. \nSeçim menüsüne yönlendirileceksiniz.", "RASGELE SORU SEÇİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartGame();
                return "";
            }
        }

        private void TYmetroButtonSoruGec_Click(object sender, EventArgs e)
        {
            if (soruda <= 3)
            {
                pass = true;
                CevapSecimi();
            }                
            else
            {
                metroButton1.Text = "Bitir";
                TYmetroButtonSoruGec.Enabled = false;
            }
        }

        private string orta()
        {
            a = random.Next(3, 9);
            b = random.Next(3, 9);
            c = random.Next(3, 9);
            randomRadioBox = random.Next(1, 5);
            soru = random.Next(1, 4);
            if (soru == 1)
            {
                double cevap = Math.Pow(a, b) / c;
                return $"{a} üsstü {b} sayısının {c}'ye bölümü kaçtır?";
            }
            else if (soru == 2)
            {
                cevap = (a + b) * c;
                return $"{a} ve {b} sayısının toplamının {c} katı kaçtır?";
            }
            else if (soru == 3)
            {
                cevap = (a + b) * (a - b);
                return $"{a} sayısı ile {b} sayısının toplamının ve {a} sayısı \nile {b} sayısının farkının çarpımı nedir?";
            }
            else if (soru == 4)
            {
                double cevap = Math.Pow((a + b), 2);
                return $"{a} sayısı ile {b} sayısının toplamının karesi nedir?";
            }
            else
            {
                cevap = 0;
                MessageBox.Show("Beklenmeyen bir hata ile karşılaşıldı. \nSeçim menüsüne yönlendirileceksiniz.", "RASGELE SORU SEÇİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartGame();
                return "";
            }
        }
        private string zor()
        {
            a = random.Next(2, 10);
            b = random.Next(2, 10);
            c = random.Next(2, 10);
            randomRadioBox = random.Next(1, 5);
            soru = random.Next(1, 4);
            if (soru == 1)
            {
                cevap = Math.Pow(a + b, 1 / c);
                return $"{a} ve {b} sayısının toplamının {c} kökü kaçtır?";
            }
            else if (soru == 2)
            {
                cevap = Math.Pow((a - b), c);
                return $"{a} ve {b} sayısının farkının {c} üssü kaçtır?";
            }
            else if (soru == 3)
            {
                cevap = Math.Sqrt((a + b) * (a - b));
                return $"{a} sayısı ile {b} sayısının toplamının ve {a} sayısı ile \n{b} sayısının farkının çarpımı karekökü nedir?";
            }
            else if (soru == 4)
            {
                cevap = Math.Sqrt(c) - Math.Sqrt(Math.Pow((a), 2) + Math.Pow(b, 2));
                return $"{a} sayısının karesi ve {b} sayınının karesi ile toplaıp kökü \nalınınınca c sayıs elde ediliyor. {c} sayısının kökü alınıp c \nçıkartılırsa işemin sonucu ne olur?";
            }
            else
            {
                cevap = 0;
                MessageBox.Show("Beklenmeyen bir hata ile karşılaşıldı. \nSeçim menüsüne yönlendirileceksiniz.", "RASGELE SORU SEÇİM HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartGame();
                return "";
            }
        }
        private void CevapOlustur()
        {
            if (randomRadioBox == 1)
            {
                setRadio(cevap, random.Next(20, 99), random.Next(20, 99), random.Next(20, 99), random.Next(20, 99));
            }
            else if (randomRadioBox == 2)
                setRadio(random.Next(20, 99), cevap, random.Next(20, 99), random.Next(20, 99), random.Next(20, 99));
            else if (randomRadioBox == 3)
                setRadio(random.Next(20, 99), random.Next(20, 99), cevap, random.Next(20, 99), random.Next(20, 99));
            else if (randomRadioBox == 4)
                setRadio(random.Next(20, 99), random.Next(20, 99), random.Next(20, 99), cevap, random.Next(20, 99));
            else if (randomRadioBox == 5)
                setRadio(random.Next(20, 99), random.Next(20, 99), random.Next(20, 99), random.Next(20, 99), cevap);
            else
            {
                metroTextBox1.Text = "";
                cevap = 0;
                MessageBox.Show("Beklenmeyen bir hata ile karşılaşıldı. \nSeçim menüsüne yönlendirileceksiniz.", "CEVAP OLUŞTURMA HATASI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartGame();
            }
        }
        private void CevapSecimi()
        {
            if (TYmetroRadioButtonCevapA.Text       == $"A) {cevap}" && TYmetroRadioButtonCevapA.Checked)
            {
                totalNumberOfCorrectChoices += 1;
            }
            else if (TYmetroRadioButtonCevapB.Text  == $"B) {cevap}" && TYmetroRadioButtonCevapB.Checked)
            {
                totalNumberOfCorrectChoices += 1;
            }
            else if (TYmetroRadioButtonCevapC.Text  == $"C) {cevap}" && TYmetroRadioButtonCevapC.Checked)
            {
                totalNumberOfCorrectChoices += 1;
            }
            else if (TYmetroRadioButtonCevapD.Text  == $"D) {cevap}" && TYmetroRadioButtonCevapD.Checked)
            {
                totalNumberOfCorrectChoices += 1;
            }
            else if (TYmetroRadioButtonCevapE.Text  == $"E) {cevap}" && TYmetroRadioButtonCevapE.Checked)
            {
                totalNumberOfCorrectChoices += 1;
            }
            if (TYmetroRadioButtonCevapA.Checked || TYmetroRadioButtonCevapB.Checked || TYmetroRadioButtonCevapC.Checked || TYmetroRadioButtonCevapD.Checked || TYmetroRadioButtonCevapE.Checked || pass)
            {
                TYmetroRadioButtonCevapA.Checked = false;
                TYmetroRadioButtonCevapB.Checked = false;
                TYmetroRadioButtonCevapC.Checked = false;
                TYmetroRadioButtonCevapD.Checked = false;
                TYmetroRadioButtonCevapE.Checked = false;
                TYmetroLabelPuan.Text = $"PUAN: {(soruda != 0 ? 100 / (soruda): 0) * totalNumberOfCorrectChoices}"; // puanı soru sayısına bölüp doğru soru sayısı ile çarpıyor.
                TYmetroLabelSoru.Text =  $"soru ({(soruda == 4 ? soruda : soruda+1)}) zorluk: {zorlukText} doğru: {totalNumberOfCorrectChoices}";
                if (soruda <= 3)
                {
                    if (soruda == 3)
                    {
                        metroButton1.Text = "Bitir";
                        SoruSecimi();
                    }
                    else
                        SoruSecimi();
                }
                else
                {
                    try
                    {
                        // veri tabanına doğru çözdüğü soru sayısının {totalNumberOfCorrectChoices} kaydı yapılacak.
                        connection.Open();
                        string sorgu = "INSERT INTO TY_GAME (TY_ID, TY_DATE, TY_SCORE, TY_QUESTION) VALUES (@userid, @dateNow, @gameScore, @gameQuestion)";
                        SqlCommand game = new SqlCommand(sorgu, connection);
                        game.Parameters.AddWithValue("@userid", ID);
                        game.Parameters.AddWithValue("@dateNow", DateTime.Now);
                        game.Parameters.AddWithValue("@gameScore", totalNumberOfCorrectChoices);
                        game.Parameters.AddWithValue("@gameQuestion", soruda);
                        game.ExecuteNonQuery(); //ExecuteQuery'den farkı işlem sonucunda bir dönüş olmamasıdır. 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bağlantı esnasında bir hata oluştu.\n\n" + ex.ToString(), "Hata");
                    }
                    finally
                    {
                        MessageBox.Show($"Puanınız 100 üzerinden {100 / soruda * totalNumberOfCorrectChoices}"); // tanımsız olmaması için ternay eklendi
                        StartGame();
                    }
                }
            }
            else
                MessageBox.Show("Seçim yapılmadı, lütfen seöçim yapınız.", "SORU CEVAPLANMADI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void setRadio(double a, double b, double c,double d,double e)
        {
            TYmetroRadioButtonCevapA.Text = $"A) {a}";
            TYmetroRadioButtonCevapB.Text = $"B) {b}";
            TYmetroRadioButtonCevapC.Text = $"C) {c}";
            TYmetroRadioButtonCevapD.Text = $"D) {d}";
            TYmetroRadioButtonCevapE.Text = $"E) {e}";
        }
    }
}