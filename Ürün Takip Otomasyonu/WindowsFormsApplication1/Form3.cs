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
    public partial class Form3 : Form
    {
        
        

        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
        OleDbDataAdapter da;
        DataSet ds;

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 anamenu = new Form1();
            anamenu.Show();
            this.Hide();
        }

        private void tedarikçiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 urunislemleri = new Form2();
            urunislemleri.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * From tedarikci", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "tedarikci");
            dataGridView1.DataSource = ds.Tables["tedarikci"];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text=dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        void gridoldur()
        {
            OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.Jet.Oledb.4.0;Data Source= Database1.mdb");
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select tedarikci_adi,tedarikci_tel,tedarikci_adres From tedarikci", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "Tedarikci");
            dataGridView1.DataSource = ds.Tables["Tedarikci"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "")
            {
                DialogResult kaydet = new DialogResult();
                kaydet = MessageBox.Show("Eklemek İstediğinizden Emin Misiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kaydet == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand();
                    baglanti.Open();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "insert into Tedarikci (tedarikci_adi,tedarikci_tel,tedarikci_adres)values('" + textBox1.Text + "','" + maskedTextBox1.Text + "','" + richTextBox1.Text + "')";
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                    gridoldur();
                    textBox1.Clear();
                    richTextBox1.Clear();
                    maskedTextBox1.Clear();
                }
            }
            else
            {
                DialogResult bos = new DialogResult();
                bos = MessageBox.Show("Bütün Değerleri Eksiksiz Giriniz", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            DialogResult asd = new DialogResult();
            asd = MessageBox.Show("Silinsin mi?","", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (asd == DialogResult.Yes)
            {
                if (textBox1.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "")
                {
                    OleDbCommand komut = new OleDbCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "delete from Tedarikci where tedarikci_adi= + '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    gridoldur();
                }
                else
            {
                MessageBox.Show("Silinecek veriyi seçiniz.");
            }
            }
            

            else if (asd == DialogResult.No)
            {
                MessageBox.Show("Silinmedi.");
            }
                
      
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                DialogResult istek = new DialogResult();
                istek = MessageBox.Show("Güncellemek istediğinizden emin misiniz ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (istek == DialogResult.Yes)
                {
                    OleDbCommand komut = new OleDbCommand();
                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "update Tedarikci set tedarikci_adi='" + textBox1.Text + "',tedarikci_tel='" + maskedTextBox1.Text + "'where tedarikci_adres='" + richTextBox1.Text + "'";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    gridoldur();
                


            }
          
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Güncellenecek veriyi seçiniz .", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
         
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                da = new OleDbDataAdapter("Select * from Tedarikci where Tedarikci_adi Like '" + textBox1.Text + "%'", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "Tedarikci");
                baglanti.Close();
                dataGridView1.DataSource = ds.Tables["Tedarikci"];
            }
            else
            {
                MessageBox.Show("Boş yer bırakmıyınız");
            }
        }

        private void kategoriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 kategori = new Form5();
            kategori.Show();
            this.Hide();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 satisislemleri = new Form4();
            satisislemleri.Show();
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
