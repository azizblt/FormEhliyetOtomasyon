using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class sifremiunuttum : Form
    {
        public int sifirkodu;
        public SmtpClient smtp = new SmtpClient();
        public sifremiunuttum()
        {
            // MessageBox.Show("yapıcı");
            InitializeComponent();
            smtp.Host = "smtp.turkticaret.net";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("azizbolat@siyahkale.com.tr", "986532.Aa");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage eposta = new MailMessage();
                eposta.From = new MailAddress("azizbolat@siyahkale.com.tr", "AZİZ BOLAT");
                eposta.To.Add(textBox1.Text);
                eposta.Subject = "Şifre Sıfırlama";
                Random random = new Random();
                sifirkodu = random.Next(100000, 999999);
                eposta.Body = "Kod: " + sifirkodu;
                smtp.Send(eposta);
                MessageBox.Show("Kod Gönderildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderilirkene bir hata ile karşılaşıldı: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sifirkodu.ToString() == textBox2.Text)
            {
                MessageBox.Show("Onaylama Gerçekleşti ");
                sifre_yenileme git = new sifre_yenileme();
                git.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kod Yanlış");
                
            }
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void sifremiunuttum_Load(object sender, EventArgs e)
        {

        }
    }
    }

