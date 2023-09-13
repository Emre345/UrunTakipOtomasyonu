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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =Database1.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
    
        private void Form4_Load(object sender, EventArgs e)
        {

            griddoldur();
        }

        void griddoldur()
        {

            da = new OleDbDataAdapter("Select*from urunler", con);
            ds = new DataSet();

            da.Fill(ds, "urunler");
            dataGridView1.DataSource = ds.Tables["urunler"];
            con.Close();

        }
        private void ÜrünİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 urun = new Form2();
            urun.Show();
            this.Hide();
        }

        private void TedarikçiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 tedarikci = new Form3();
            tedarikci.Show();
            this.Hide();
        }

        

        private void kategoriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 tedarikciislemleri = new Form3();
            tedarikciislemleri.Show();
            this.Hide();
        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 anamenu = new Form1();
            anamenu.Show();
            this.Hide();
        }

        private void tedarikçiİşlemleriToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 urunislemleri = new Form2();
            urunislemleri.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Enabled = false;
            textBox6.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da = new OleDbDataAdapter("SELECT * from Urunler where urun_kodu like '%" + textBox1.Text + "%'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Urunler");
            dataGridView1.DataSource = ds.Tables["Urunler"];
            con.Close();    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                DialogResult nesne = new DialogResult();
                nesne = MessageBox.Show("Satış Yapılsınmı ?", "Satış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (nesne == DialogResult.Yes)
                {
                    if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                    {
                        con.Open();

                        cmd = new OleDbCommand();

                        cmd.Connection = con;
                        cmd.CommandText = "update Urunler set urun_adet = urun_adet - '" + richTextBox1.Text + "' where urun_kodu = '" + textBox4.Text + "' ";
                        cmd.ExecuteNonQuery();
                        griddoldur();
                        con.Close();
                        richTextBox3.Text = comboBox3.Text + " Adlı markadan " + textBox5.Text + " Adlı ürün " + richTextBox1.Text + " Tanesi " + richTextBox2.Text + " 'den Satılmıştır ";


                    }
                    else
                    {
                        MessageBox.Show("Satılacak ürün seçili değil");
                    }

            }
            
        }
       

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            double birimfiyat = Convert.ToDouble(textBox6.Text) ;
            double satis = Convert.ToDouble(richTextBox1.Text) ;
            double sonuc = birimfiyat * satis;
            richTextBox2.Text = sonuc.ToString();

        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 kategori = new Form5();
            kategori.Show();
            this.Hide();
        }

        private void markaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.Show();
            this.Hide();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satış_Raporları satis = new Satış_Raporları();
            satis.Show();
            this.Hide();

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        
    }
}
