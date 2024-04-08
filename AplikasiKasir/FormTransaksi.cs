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

namespace AplikasiKasir
{
    public partial class FormTransaksi : Form
    {
        public FormTransaksi()
        {
            InitializeComponent();
        }
        void KondisiAwal()
        {
            LBLNamaBarang.Text = "";
            LBLKembali.Text = "";
            LBLHargaBarang.Text = "";
            LBLTotal.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LBLItem.Text = "";
            LBLTanggal.Text = DateTime.Now.ToString("yyyy-MM-dd");



        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            KondisiAwal();

        }

        
    }
}
