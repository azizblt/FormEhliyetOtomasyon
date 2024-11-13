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
    public partial class odemeler : Form
    {
        SqlConnection baglantı = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public odemeler()
        {
            InitializeComponent();
        }

        private void odemeler_Load(object sender, EventArgs e)
        {
            this.odemelerTableAdapter.Fill(this.ehliyetDataSet.odemeler);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string ad, soyad, tc, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            tc = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox1.Text = ad;
            textBox2.Text = soyad;
            textBox3.Text = tc;
            textBox5.Text = kalan;

        }
        int m;
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();

            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt32(textBox4.Text);
            kalan = Convert.ToInt32(textBox5.Text);


            if (odenen > kalan)
            {
                MessageBox.Show("Ödenen miktar, kalan borcu aşamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantı.Close();
                return;
            }
            yeniborc = kalan - odenen;
            textBox5.Text = yeniborc.ToString();

            SqlCommand komut = new SqlCommand("UPDATE odemeler SET borc=@p1 WHERE tc=@p2", baglantı);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p1", textBox5.Text);
            try
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Borç başarıyla ödendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.odemelerTableAdapter.Fill(this.ehliyetDataSet.odemeler);

                m = Convert.ToInt32(Convert.ToDouble(textBox4.Text) / Convert.ToDouble(textBox5.Text) * 100);
                progressBar1.Value = m;

                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglantı.Close();
            }
            //else
            //{
            //    MessageBox.Show("Geçerli bir sayı giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();

        }
    }
}
