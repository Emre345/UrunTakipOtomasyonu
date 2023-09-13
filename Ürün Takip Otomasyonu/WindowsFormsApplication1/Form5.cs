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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");

        void gridoldur()
        {
            OleDbConnection baglanti= new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
            OleDbDataAdapter dr = new OleDbDataAdapter("Select * from Kategori", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            dr.Fill(ds, "Kategori");
            dataGridView1.DataSource = ds.Tables["Kategori"];
            baglanti.Close();
            
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

        private void markaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.Show();
            this.Hide();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 satis = new Form4();
            satis.Show();
            this.Hide();
        }

        private void satışRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satış_Raporları satisr = new Satış_Raporları();
            satisr.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 ana = new Form1();
            ana.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            gridoldur();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source= Database1.mdb");
                OleDbDataAdapter dr = new OleDbDataAdapter("Select * from Kategori where kategori_adi like'%" + textBox1.Text + "%'", baglanti);
                DataSet ds = new DataSet();
                baglanti.Open();
                dr.Fill(ds, "Satis");
                dataGridView1.DataSource = ds.Tables["Satis"];
                baglanti.Close();
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult ekle = new DialogResult();
                ekle = MessageBox.Show("Eklensin Mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ekle == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Kategori (kategori_adi)values('" + textBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gridoldur();
                    textBox1.Clear();

                }
            }
            else
            {
                DialogResult degeryok = new DialogResult();
                degeryok= MessageBox.Show("Boş Değer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult istek = new DialogResult();
            istek = MessageBox.Show("Güncellensin mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (istek == DialogResult.Yes)
            {
                con.Open();

                OleDbCommand sorgu;
                string kategori;
                int id;
                id = Convert.ToInt16(textBox2.Text);
                kategori = textBox1.Text;
                sorgu = new OleDbCommand();
                sorgu.Connection = con;
                sorgu.CommandText = "update Kategori set kategori_adi='" + kategori + "' where kategori_id=" + id;
                sorgu.ExecuteNonQuery();
                con.Close();

                gridoldur();
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Güncellenmedi ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult silme = new DialogResult();
            silme= MessageBox.Show("Kayıtlı Veriyi Silmek İstediğinizden Emin Misiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (silme == DialogResult.Yes)
            {
                OleDbCommand komut = new OleDbCommand();
                con.Open();
                komut.Connection = con;
                komut.CommandText = "delete from Kategori where kategori_adi= + '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                komut.ExecuteNonQuery();
                con.Close();
                gridoldur();
                textBox1.Clear();

            }
        }

       
    }
}
