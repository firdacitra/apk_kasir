﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AplikasiKasir
{
    public partial class FormMasterBarang : Form
    {

        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;

        void munculSatuan()
        {
            comboBox1.Items.Add("PCS");
            comboBox1.Items.Add("PAKET");
        }

        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            munculSatuan();
            MunculDataBarang();
        }

        void MunculDataBarang()
        {
            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TBL_BARANG", conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_BARANG");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_BARANG";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Refresh();

        }
        public FormMasterBarang()
        {
            InitializeComponent();
        }

        private void FormMasterBarang_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi.");
            }
            else
            {
                SqlConnection conn = konn.GetConn();

                cmd = new SqlCommand("insert into TBL_BARANG values('"+ textBox1.Text +"','" + textBox2.Text +"','" + textBox3.Text +"','" + textBox4.Text +"','" + textBox5.Text +"','" + comboBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Input.");
                KondisiAwal();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi.");
            }
            else
            {
                SqlConnection conn = konn.GetConn();

                cmd = new SqlCommand("Update TBL_BARANG set NamaBarang='" + textBox2.Text + "',HargaBeli='" + textBox3.Text + "',HargaJual='" + textBox4.Text + "',JumlahBarang='" + textBox5.Text + "',SatuanBarang='" + comboBox1.Text + "' where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Input.");
                KondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = konn.GetConn();

                cmd = new SqlCommand("select * from TBL_BARANG where KodeBarang = '" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    textBox4.Text = rd[3].ToString();
                    textBox5.Text = rd[4].ToString();
                    comboBox1.Text = rd[5].ToString();
                }
                else
                {
                    MessageBox.Show("Data Tidak Ada.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan Semua Form Terisi.");
            }
            else
            {
                SqlConnection conn = konn.GetConn();

                cmd = new SqlCommand("Delete TBL_BARANG where KodeBarang='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di hapus.");
                KondisiAwal();
            }
        }
    }
}
