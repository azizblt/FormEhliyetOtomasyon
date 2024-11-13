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
using System.Data.Sql;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "insert into giris ( username, password, gmail)values(@p1, @p2, @p3)";
            SqlCommand komut = new SqlCommand(sorgu, baglantı);
            komut.Parameters.AddWithValue("@p1", textBox1.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p3", textBox2.Text);
            
            baglantı.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız başarıyla oluşturuldu");

            Form1 abd = new Form1();
            abd.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
