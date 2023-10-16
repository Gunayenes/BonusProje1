using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-UH0CHU2\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        DataSet1TableAdapters.TBLOGRENCILERTableAdapter ds = new DataSet1TableAdapters.TBLOGRENCILERTableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * From TBLKULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();

        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked==true)
            {
                c = "KIZ";
            }
            if (radioButton2.Checked==true)
            {
                c = "ERKEK";
            }
            ds.OgrenciEkle(txtAd.Text,txtSoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c);
            MessageBox.Show("Öğrenci Eklendi");
        }

        private void txtKulup_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtId.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtId.Text));
        }
        string cinsiyet = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text= dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (cinsiyet == "Kız")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            if (cinsiyet == "Erkek")
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtAd.Text,txtSoyad.Text,byte.Parse(comboBox1.SelectedValue.ToString()),c, int.Parse(txtId.Text));
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
         dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
