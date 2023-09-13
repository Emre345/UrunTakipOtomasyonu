using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 urunislemleri = new Form2();
            urunislemleri.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult asd = new DialogResult();
            asd = MessageBox.Show("Programdan Çıkmak İstediğinize Emin misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (asd==DialogResult.Yes) 
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Çıkış Yapılmadı..");
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 tedarikciislemleri = new Form3();
            tedarikciislemleri.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 kategoriislemleri = new Form5();
            kategoriislemleri.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 satisislemleri = new Form4();
            satisislemleri.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Satış_Raporları satis = new Satış_Raporları();
            satis.Show();
            this.Hide();
        }

        
    }
}
