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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =Database1.mdb");
        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        
        


        private void Form2_Load(object sender, EventArgs e)
        {
            goster();
            satis_sayisi();
            urunsayisi();
            markasayisi();
            kategorisayisi();
            tedarikcisayisi();

        }
       

        void goster()
        {

            da = new OleDbDataAdapter("Select*from Urunler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Urunler");
            dataGridView1.DataSource = ds.Tables["Urunler"];
            con.Close();
        }




        public void satis_sayisi()
        {
            goster();
            con.Open();
            OleDbCommand urunsay = new OleDbCommand();
            urunsay.Connection = con;
            urunsay.CommandText = "Select count(*) from Satis";
            int satissayisi = Convert.ToInt16(urunsay.ExecuteScalar());
            label12.Text = "Toplam Satış Sayısı: " + satissayisi;
            con.Close();
        }
        public void urunsayisi()
        {
            goster();
            con.Open();
            OleDbCommand cmd=new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText="Select count(*) from Urunler";
            int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            label8.Text = "Toplam Ürün Sayısı " + sayi;
            con.Close();

        }
        public void markasayisi()
        {
            goster();
            con.Open();
            OleDbCommand marka = new OleDbCommand();
            marka.Connection = con;
            marka.CommandText = "Select count(*) from Marka";
            int markasayisi = Convert.ToInt16(marka.ExecuteScalar());
            label9.Text = "Toplam Marka Sayısı: " + markasayisi;
            con.Close();

        }
        public void kategorisayisi()
        {
            goster();
            con.Open();
            OleDbCommand kategori = new OleDbCommand();
            kategori.Connection = con;
            kategori.CommandText = "Select count(*) from Tedarikci";
            int kategorisayisi = Convert.ToInt16(kategori.ExecuteScalar());
            label10.Text = "Toplam Tedarikçi Sayısı: " + kategorisayisi;
            con.Close();

        }
        public void tedarikcisayisi()
        {
            goster();
            con.Open();
            OleDbCommand tedarikci = new OleDbCommand();
            tedarikci.Connection = con;
            tedarikci.CommandText = "Select count(*) from Kategori";
            int tedarikcisayisi = Convert.ToInt16(tedarikci.ExecuteScalar());
            label11.Text = "Toplam Kategori Sayısı: " + tedarikcisayisi;
            con.Close();

        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox1.Enabled = true;
            

        }

        private void anaMenüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 anamenu = new Form1();
            anamenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                da = new OleDbDataAdapter("Select * from urunler where urun_kodu Like'" + textBox1.Text + "%'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Urunler");
                con.Close();
                dataGridView1.DataSource = ds.Tables["Urunler"];

            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        

      
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                da = new OleDbDataAdapter("Select * from urunler where urun_adi Like '" + textBox2.Text + "%'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Urunler");
                con.Close();
                dataGridView1.DataSource = ds.Tables["Urunler"];
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult nesne = new DialogResult();
            nesne = MessageBox.Show("Kaydedilsin mi?", "EKLEME", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (nesne == DialogResult.Yes)
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""&&textBox4.Text!= ""&& comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    MessageBox.Show("Başarıyla Kaydedildi...");
                    cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Insert into Urunler(urun_kodu,urun_adi,urun_fiyat,urun_adet,marka,kategori,tedarikci) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    goster();
                }


                else
                {
                    MessageBox.Show("Boş Yer Bırakmayınız...");

                }

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                
                


            }
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                da = new OleDbDataAdapter("Select * from urunler where marka Like '" + comboBox1.Text + "%'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Urunler");
                con.Close();
                dataGridView1.DataSource = ds.Tables["Urunler"];
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text != "")
            {
                da = new OleDbDataAdapter("Select * from urunler where kategori Like '" + comboBox2.Text + "%'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Urunler");
                con.Close();
                dataGridView1.DataSource = ds.Tables["Urunler"];
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                da = new OleDbDataAdapter("Select * from urunler where tedarikci Like '" + comboBox3.Text + "%'", con);
                ds = new DataSet();
                con.Open();
                da.Fill(ds, "Urunler");
                con.Close();
                dataGridView1.DataSource = ds.Tables["Urunler"];
            }
            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult silme = new DialogResult();
            silme = MessageBox.Show("Silinsin mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (silme == DialogResult.Yes)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from Urunler where urun_kodu='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    goster();

                }
                else
                {
                    MessageBox.Show("Silinecek Değer Seçili Değil..");
                }
            }



            else if (silme == DialogResult.No)
            {

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
       
        
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult guncelle = new DialogResult();
            guncelle = MessageBox.Show("Güncellensin Mi?", "GÜNCELLEME", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (guncelle == DialogResult.Yes)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
                {
                    cmd = new OleDbCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "update urunler set urun_adi='" + textBox2.Text + "',urun_fiyat='" + textBox3.Text + "',urun_adet='" + textBox4.Text + "',marka='" + comboBox1.Text + "',kategori='" + comboBox2.Text + "',tedarikci='" + comboBox3.Text + "' where urun_kodu='" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    goster();

                }
                else if (guncelle == DialogResult.No)
                {
                    MessageBox.Show("Güncellenmedi.");
                }
                else
                {
                    MessageBox.Show("Güncellenecek Değer Seçili Değil..");
                }











                textBox1.Enabled = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
       }

        private void label13_Click(object sender, EventArgs e)
        {
           



        }

        private void tedarikçiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 tedarikciislemleri = new Form3();
            tedarikciislemleri.Show();
            this.Hide();
        }

        private void kategoriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 satisislemleri = new Form4();
            satisislemleri.Show();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
      

      
     }
}
