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
    public partial class kursiyer_islemleri : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");
        public void verileri_goster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public kursiyer_islemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verileri_goster("select *FROM kursiyer_kayit");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tc1.Text) &&
    !string.IsNullOrWhiteSpace(adınız.Text) &&
    !string.IsNullOrWhiteSpace(soyad1.Text) &&
    !string.IsNullOrWhiteSpace(tel1.Text) &&
    !string.IsNullOrWhiteSpace(dogum1.Text) &&
    !string.IsNullOrWhiteSpace(adres1.Text) &&
    cmb.SelectedItem != null &&
    adli1.SelectedItem != null &&
    saglik1.SelectedItem != null &&
    ogrenim1.SelectedItem != null &&
    ehliyet1.SelectedItem != null)
            {

                try
                {
                    string al = "insert into kursiyer_kayit (tc,isim,soyad,tel,dogum,adres,adli, kan,saglik,ogrenim,ehliyet) values(@tc,@isim,@soyad,@tel,@dogum,@adres,@adli,@kan,@saglik,@ogrenim,@ehliyet)";
                    SqlCommand kyt = new SqlCommand(al, baglanti);
                    kyt.Parameters.AddWithValue("@tc", tc1.Text);
                    kyt.Parameters.AddWithValue("@isim", adınız.Text);
                    kyt.Parameters.AddWithValue("soyad", soyad1.Text);
                    kyt.Parameters.AddWithValue("@tel", tel1.Text);
                    kyt.Parameters.AddWithValue("@dogum", dogum1.Text);
                    kyt.Parameters.AddWithValue("@borc", textBox1.Text);
                    kyt.Parameters.AddWithValue("@adres", adres1.Text);
                    kyt.Parameters.AddWithValue("@kan", cmb.SelectedItem.ToString());
                    kyt.Parameters.AddWithValue("@adli", adli1.SelectedItem.ToString());
                    kyt.Parameters.AddWithValue("@saglik", saglik1.SelectedItem.ToString());
                    kyt.Parameters.AddWithValue("@ogrenim", ogrenim1.SelectedItem.ToString());
                    kyt.Parameters.AddWithValue("@ehliyet", ehliyet1.SelectedItem.ToString());

                    baglanti.Open();
                    kyt.ExecuteNonQuery();
                    MessageBox.Show("Kaydınız başarı ile gerçekleştirilmiştir");
                    //baglanti.Open();
                    string sorgum = "insert into odemeler (isim,soyad,tc,borc)values(@isim,@soyad,@tc,@borc)";
                    SqlCommand komut2 = new SqlCommand(sorgum, baglanti);
                    komut2.Parameters.AddWithValue("@isim", adınız.Text);
                    komut2.Parameters.AddWithValue("@soyad", soyad1.Text);
                    komut2.Parameters.AddWithValue("@tc", tc1.Text);
                    komut2.Parameters.AddWithValue("borc", textBox1.Text);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    tel1.Text = "";
                    adınız.Clear();
                    soyad1.Clear();
                    dogum1.Clear();
                    adres1.Clear();
                    textBox1.Clear();
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
            //baglanti.Open();
            //string sorgum = "insert into odemeler (isim,soyad,tc,borc)values(@isim,@soyad,@tc,@borc)";
            //SqlCommand komut2 = new SqlCommand(sorgum, baglanti);
            //komut2.Parameters.AddWithValue("@isim", adınız.Text);
            //komut2.Parameters.AddWithValue("@soyad", soyad1);
            //komut2.Parameters.AddWithValue("@tc", tc1.Text);
            //komut2.Parameters.AddWithValue("borc", textBox1.Text);
            //komut2.ExecuteNonQuery();
            //baglanti.Close();

        }

        private void kursiyer_islemleri_Load(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select kangrubu FROM kan", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    cmb.Items.Add(oku[0].ToString());
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
            try
            {

                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select name FROM var_yok", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    adli1.Items.Add(oku[0].ToString());
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
            try
            {

                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select name FROM var_yok", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    saglik1.Items.Add(oku[0].ToString());
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
            try
            {

                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select egitim FROM egitim", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    ogrenim1.Items.Add(oku[0].ToString());
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




            try
            {

                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select ehliyet FROM ehliyetler", baglanti);
                SqlDataReader oku = sorgu.ExecuteReader();

                while (oku.Read())
                {
                    ehliyet1.Items.Add(oku[0].ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string tbl = "delete  FROM kursiyer_kayit WHERE  tc=@tc";
                SqlCommand komut = new SqlCommand(tbl, baglanti);
                komut.Parameters.AddWithValue("@tc" ,textBox4.Text);
                komut.ExecuteNonQuery();
                verileri_goster("select *from kursiyer_kayit");
                baglanti.Close();
                MessageBox.Show("kursiyer silme işleminiz başarılı bir şekilde gerçekleşmiştir");

                textBox4.Clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                SqlCommand ara = new SqlCommand("select *FROM kursiyer_kayit WHERE tc like '%" + textBox3.Text + "%'", baglanti);
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                ara.ExecuteNonQuery();
                baglanti.Close();
                textBox3.Clear();
            }

            catch(Exception ex)
            {
                MessageBox.Show("hata" + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;
            string tc = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string isim = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();
            string tel = dataGridView1.Rows[secili_alan].Cells[3].Value.ToString();
            string dogum = dataGridView1.Rows[secili_alan].Cells[4].Value.ToString();
            string adres = dataGridView1.Rows[secili_alan].Cells[5].Value.ToString();
            string kan = dataGridView1.Rows[secili_alan].Cells[6].Value.ToString();
            string adli = dataGridView1.Rows[secili_alan].Cells[7].Value.ToString();
            string saglik = dataGridView1.Rows[secili_alan].Cells[8].Value.ToString();
            string ogrenim = dataGridView1.Rows[secili_alan].Cells[9].Value.ToString();
            string ehliyet = dataGridView1.Rows[secili_alan].Cells[10].Value.ToString();
            string borc = dataGridView1.Rows[secili_alan].Cells[11].Value.ToString();

            tc1.Text = tc;
            adınız.Text =isim;
            soyad1.Text = soyad;
            tel1.Text = tel;
            dogum1.Text = dogum;
            adres1.Text = adres;
            cmb.Text = kan;
            ogrenim1.Text =ogrenim;
            adli1.Text = adli;
            saglik1.Text = saglik; 
            ehliyet1.Text = ehliyet;
            textBox1.Text = borc;


        }

        private void button5_Click(object sender, EventArgs e)
        {
           baglanti.Open();
           SqlCommand guncelle = new SqlCommand("update kursiyer_kayit set isim = '"+adınız.Text+ "', soyad = '" + soyad1.Text + "' ,tel = '" + tel1.Text + "', dogum = '" + dogum1.Text + "' , adres = '" + adres1.Text + "' ,kan = '" + cmb.Text + "' ,adli = '" + adli1.Text + "',saglik = '" + saglik1.Text + "' ,ogrenim = '" + ogrenim1.Text + "' ,ehliyet = '" + ehliyet1.Text + "' ,borc = '" + textBox1.Text + "' WHERE  tc = '" + tc1.Text + "' ", baglanti);
            guncelle.ExecuteNonQuery();
            verileri_goster("select *FROM kursiyer_kayit");
            baglanti.Close();
           
           


        }

        private void button6_Click(object sender, EventArgs e)
        {
            anasayfa git = new anasayfa();
            git.Show();
            this.Hide();

        }
    }
}
