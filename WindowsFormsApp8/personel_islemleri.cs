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
    public partial class personel_islemleri : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public void verileri_goster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public personel_islemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //personel_sil fgr = new personel_sil();
            //fgr.Show();
            //this.Hide();
        }

        private void personel_islemleri_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select gorevler FROM gorev", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    comboBox1.Items.Add(oku[0].ToString());
                }
                oku.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("bir hata oluştu /n" + ex.Message);
            }
            finally
            {
                if (baglanti.State != ConnectionState.Closed)
                {
                    baglanti.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            verileri_goster("select *FROM personel_kayit");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
    !string.IsNullOrWhiteSpace(textBox2.Text) &&
    !string.IsNullOrWhiteSpace(maskedTextBox1.Text) &&
    !string.IsNullOrWhiteSpace(textBox3.Text) &&
    !string.IsNullOrWhiteSpace(maskedTextBox2.Text) &&
    !string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                try
                {
                    baglanti.Open();

                    string al = "INSERT INTO personel_kayit (tc, isim, soyad, telefon, adres, e_posta,gorevi) VALUES (@tc, @isim, @soyad, @telefon, @adres, @e_posta,@gorevi)";

                    SqlCommand kyt = new SqlCommand(al, baglanti);

                    kyt.Parameters.AddWithValue("@tc", maskedTextBox1.Text);
                    kyt.Parameters.AddWithValue("@isim", textBox1.Text);
                    kyt.Parameters.AddWithValue("@soyad", textBox2.Text);
                    kyt.Parameters.AddWithValue("@telefon", maskedTextBox2.Text);
                    kyt.Parameters.AddWithValue("@adres", richTextBox1.Text);
                    kyt.Parameters.AddWithValue("@e_posta", textBox3.Text);
                    kyt.Parameters.AddWithValue("@gorevi",comboBox1.Text);

                    kyt.ExecuteNonQuery();

                    MessageBox.Show("Kaydınız başarı ile gerçekleştirilmiştir");

                    //kursiyer_islemleri drt = new kursiyer_islemleri();
                    //drt.Show();
                    //this.Hide();

                    maskedTextBox1.Text = "";
                    textBox1.Clear();
                    textBox2.Clear();
                    maskedTextBox2.Clear();
                    richTextBox1.Clear();
                    textBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
                finally
                {
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    baglanti.Open();
                    string tbl = "DELETE FROM personel_kayit WHERE tc=@tc";
                    SqlCommand komut = new SqlCommand(tbl, baglanti);
                    komut.Parameters.AddWithValue("@tc", textBox4.Text);
                    komut.ExecuteNonQuery();
                    verileri_goster("SELECT * FROM personel_kayit");
                    MessageBox.Show("Personel silme işleminiz başarı ile gerçekleşmiştir");
                }
                else
                {
                    MessageBox.Show("Lütfen TC kimlik numarasını giriniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
                textBox4.Clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string isim = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string soyad = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string tc = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();
            string tel = dataGridView1.Rows[secili_alan].Cells[3].Value.ToString();
            string e_posta = dataGridView1.Rows[secili_alan].Cells[4].Value.ToString();
            string adres = dataGridView1.Rows[secili_alan].Cells[5].Value.ToString();
            string gorevi = dataGridView1.Rows[secili_alan].Cells[6].Value.ToString();

            maskedTextBox1.Text = tc;
            textBox1.Text = isim;
            textBox2.Text = soyad;
            maskedTextBox2.Text = tel;
            richTextBox1.Text = adres;
            textBox3.Text = e_posta;
            comboBox1.Text = gorevi;




        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update personel_kayit set isim = '" + textBox1.Text + "', soyad = '" + textBox2.Text + "' ,telefon = '" + maskedTextBox2.Text + "' , adres = '" + richTextBox1.Text + "' , gorevi= '" + comboBox1.Text + "'  ,e_posta = '" + textBox3.Text + "' WHERE  tc = '" + maskedTextBox1.Text + "' ", baglanti);
            guncelle.ExecuteNonQuery();
            verileri_goster("select *FROM personel_kayit");
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand ara = new SqlCommand("select *FROM personel_kayit WHERE tc like '%" + textBox5.Text + "%'", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ara.ExecuteNonQuery();
                baglanti.Close();
                textBox5.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("hata" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();        
        }
    }

}
