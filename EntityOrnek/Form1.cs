using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityOrnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OgrenciFormİslemiEntities db = new OgrenciFormİslemiEntities();


        private void button2_Click(object sender, EventArgs e)
        {
            TBLOGRENCİ t = new TBLOGRENCİ();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            db.TBLOGRENCİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Listeye Eklendi");
            TBLDERSLER d = new TBLDERSLER();
            d.DERSAD = TxtDersAd.Text;
            db.TBLDERSLER.Add(d);
            db.SaveChanges();
            MessageBox.Show("Ders Listeye Eklendi");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BtnOgrenciListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }

        private void BtnNotListesi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLNOTLAR.ToList();
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[8].Visible=false;
        }

        private void BtnDersListesi_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLDERSLER.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtOgrenciID.Text);
            var x = db.TBLOGRENCİ.Find(id);
            db.TBLOGRENCİ.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Sistemden Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TxtOgrenciID.Text);
            var x = db.TBLOGRENCİ.Find(id);
            x.AD = TxtAd.Text;
            x.SOYAD = TxtSoyad.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Bilgileri Başarıyla Güncellendi");
        }
    }
}
