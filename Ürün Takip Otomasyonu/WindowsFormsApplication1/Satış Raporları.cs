using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class Satış_Raporları : Form
    {
        public Satış_Raporları()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");

        void gridoldur()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Satis", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "Satis");
            dataGridView1.DataSource = ds.Tables["Satis"];
            baglanti.Close();
        }
        private void markaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 kategori = new Form5();
            kategori.Show();
            this.Hide();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();

        }

        private void tedarikçiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 urun = new Form2();
            urun.Show();
            this.Hide();

        }

        private void kategoriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 tedarikci = new Form3();
            tedarikci.Show();
            this.Hide();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.Show();
            this.Hide();
        }

        private void satışRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 satis = new Form4();
            satis.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Satış_Raporları_Load(object sender, EventArgs e)
        {
            topla();
            fiyat();
            gridoldur();
        }
        void fiyat()
        {
            baglanti.Open();
            OleDbCommand fiyat = new OleDbCommand();
            fiyat.Connection = baglanti;
            fiyat.CommandText = "select sum (toplam_satis)  from Satis";
            int satisf = Convert.ToInt16(fiyat.ExecuteScalar());
            label6.Text = "" + satisf;
            baglanti.Close();
        }
        void topla()
        {

            baglanti.Open();
            OleDbCommand topla = new OleDbCommand();
            topla.Connection = baglanti;
            topla.CommandText = "select sum (satis_miktarı)  from Satis";
            int satis = Convert.ToInt16(topla.ExecuteScalar());
            label5.Text = "" + satis;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLedb.4.0;Data Source= Database1.mdb");
                OleDbDataAdapter dr = new OleDbDataAdapter("select urun_kodu,urun_adi,birim_fiyat,satis_miktarı,toplam_satis from Satis where satis_tarihi like'%" + dateTimePicker1.Text + "%'", baglanti);
                DataSet ds = new DataSet();
                baglanti.Open();
                dr.Fill(ds, "Satis");
                dataGridView1.DataSource = ds.Tables["Satis"];
                baglanti.Close();
            }
            else
            {
                DialogResult bos = new DialogResult();
                bos = MessageBox.Show("Boş yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLedb.4.0;Data Source= Database1.mdb");
                OleDbDataAdapter dr = new OleDbDataAdapter("select urun_kodu,urun_adi,birim_fiyat,satis_miktarı,toplam_satis from Satis where urun_adi like'%" + textBox1.Text + "%'", baglanti);
                DataSet ds = new DataSet();
                baglanti.Open();
                dr.Fill(ds, "Satis");
                dataGridView1.DataSource = ds.Tables["Satis"];
                baglanti.Close();
            }
            else
            {
                DialogResult bos = new DialogResult();
                bos = MessageBox.Show("Lütfen Boş Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }



    }
}
