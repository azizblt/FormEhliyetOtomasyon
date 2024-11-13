using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class randevu : Form
    {

        private Button atamaButton;
        private Button sonucButton;
        private string connectionString = "Data Source=your_server;Initial Catalog=your_database;Integrated Security=True";
        public randevu()
        {
            InitializeComponent();
        }

        private void randevu_Load(object sender, EventArgs e)
        {

        }
    }
}
