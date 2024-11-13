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
    public partial class anasayfa : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=AZIZ\\SQLEXPRESS;Initial Catalog=ehliyet;Integrated Security=True");

       /* public void verilerigoster(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }*/

        public anasayfa()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kursiyer_islemleri fbr = new kursiyer_islemleri();
            fbr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            odemeler git = new odemeler();
            git.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kursiyer_kayıt frm=new kursiyer_kayıt ();
            //frm.Show();
            //this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //personel_kayit dbg = new personel_kayit();
            //dbg.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            personel_islemleri grb = new personel_islemleri();
            grb.Show();
            this.Hide();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        
    }
}
