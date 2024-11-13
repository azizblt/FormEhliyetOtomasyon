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
    public partial class sifre_yenileme : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public sifre_yenileme()
        {
            InitializeComponent();
        }

        private void sifre_yenileme_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                if (sifre.Text == sifre1.Text)
                {
                    string updateQuery = "UPDATE giris SET password = @password WHERE username = @username";

                    using (SqlCommand guncelle = new SqlCommand(updateQuery, baglanti))
                    {
                       
                        guncelle.Parameters.AddWithValue("@password", sifre.Text);
                        guncelle.Parameters.AddWithValue("@username", adınız.Text);

                        guncelle.ExecuteNonQuery();
                    }

                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Girilen şifreler birbiri ile uyuşmuyor");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sifremiunuttum geri = new sifremiunuttum();
            geri.Show();
            this.Hide();

        }
    }
   
}
