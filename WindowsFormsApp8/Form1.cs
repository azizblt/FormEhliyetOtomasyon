using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public Form1() => InitializeComponent();

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("çıkmak istedigine eminmisin", "çıkış işlemi", MessageBoxButtons.YesNo);

            if (onay == DialogResult.Yes) 
            {
                Application.Exit();
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            string ad = textBox1.Text;
            string TC_no = textBox2.Text;

            SqlCommand command = new SqlCommand("Select *FROM giris", baglantı);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                if (ad == reader["username"].ToString().TrimEnd() && TC_no == reader["password"].ToString().TrimEnd())
                {
                    anasayfa frm = new anasayfa();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş başarısız! Lütfen TC No ve Şifrenizi kontrol edin.", "Program");
                    Form1 git = new Form1();
                    git.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Giriş başarısız! Veritabanında hiç kayıt bulunamadı.", "Program");
                Form1 git = new Form1();
                git.Show();
                this.Hide();
            }

            baglantı.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            //anasayfa frm = new anasayfa();
           // frm.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            sifremiunuttum db = new sifremiunuttum();

           
            db.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            string Sifre = textBox1.Text;
            string TC_no = textBox2.Text;

            SqlCommand command = new SqlCommand("Select *FROM personel_kayit", baglantı);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                if (Sifre == reader["isim"].ToString().TrimEnd() && TC_no == reader["tc"].ToString().TrimEnd())
                {
                    anasayfa frm = new anasayfa();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Giriş başarısız! Lütfen TC No ve Şifrenizi kontrol edin.", "Program");
                    Form1 git = new Form1();
                    git.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Giriş başarısız! Veritabanında hiç kayıt bulunamadı.", "Program");
                Form1 git = new Form1();
                git.Show();
                this.Hide();
            }

            baglantı.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
