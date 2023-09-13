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
    public partial class Marka : Form
    {
        public Marka()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");

        void gridoldur()
        
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
            OleDbDataAdapter dr = new OleDbDataAdapter("Select * from Marka", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            dr.Fill(ds, "Marka");
            dataGridView1.DataSource = ds.Tables["Marka"];
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
            Form4 satis = new Form4();
            satis.Show();
            this.Hide();
        }

        private void satışRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satış_Raporları satis = new Satış_Raporları();
            satis.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult istek = new DialogResult();
            istek = MessageBox.Show("Güncellensin mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (istek == DialogResult.Yes)
            {
                con.Open();

                OleDbCommand sorgu;
                string adi;
                int id;
                id = Convert.ToInt16(textBox2.Text);
                adi = textBox1.Text;
                sorgu = new OleDbCommand();
                sorgu.Connection = con;
                sorgu.CommandText = "update Marka set marka_adi='" + adi + "' where marka_id=" + id;
                sorgu.ExecuteNonQuery();
                con.Close();

                gridoldur();
            }
            else
            {
                DialogResult uyarı = new DialogResult();
                uyarı = MessageBox.Show("Güncellenmedi.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Marka_Load(object sender, EventArgs e)
        {
            gridoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.OLedb.4.0;Data Source= Database1.mdb");
                OleDbDataAdapter dr = new OleDbDataAdapter("select * from Marka where marka_adi like'%" + textBox1.Text + "%'", baglanti);
                DataSet ds = new DataSet();
                baglanti.Open();
                dr.Fill(ds, "Satis");
                dataGridView1.DataSource = ds.Tables["Satis"];
                baglanti.Close();
            }
            else
            {
                DialogResult bos = new DialogResult();
                bos = MessageBox.Show("Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Silmek İstediğinizden Emin Misiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (silme == DialogResult.Yes)
            {
                if (textBox1.Text != "")
                {
                    OleDbCommand komut = new OleDbCommand();
                    con.Open();
                    komut.Connection = con;
                    komut.CommandText = "delete from Marka where marka_adi + '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                    komut.ExecuteNonQuery();
                    con.Close();
                    gridoldur();
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Silinecek veriyi seçiniz.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult kaydet = new DialogResult();
                kaydet = MessageBox.Show("Eklensin mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kaydet == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "insert into Marka (marka_adi)values('" + textBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    gridoldur();
                    textBox1.Clear();

                }
            }
            else
            {
                DialogResult bos = new DialogResult();
                bos = MessageBox.Show("Bütün Değerleri Eksiksiz Giriniz", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
