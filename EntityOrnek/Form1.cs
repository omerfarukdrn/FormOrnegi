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
        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnLinqEntity_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                List<TBLOGRENCİ> liste1 = db.TBLOGRENCİ.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked==true)
            {
                List<TBLOGRENCİ> liste2 = db.TBLOGRENCİ.OrderByDescending(p =>p.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked==true)
            {
                List<TBLOGRENCİ> liste3 = db.TBLOGRENCİ.OrderBy(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = liste3; 
            }
            if (radioButton4.Checked == true)
            {
                List<TBLOGRENCİ> liste4 = db.TBLOGRENCİ.OrderByDescending(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = liste4;
            }
            if (radioButton5.Checked==true)
            {
                List<TBLOGRENCİ> liste5 = db.TBLOGRENCİ.Where(p => p.ID == 5).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked==true)
            {
                List<TBLOGRENCİ> liste6 = db.TBLOGRENCİ.Where(p => p.AD.StartsWith ("A")).ToList();
                dataGridView1.DataSource = liste6;
            }
            if (radioButton7.Checked == true)
            {
                List<TBLOGRENCİ> liste7 = db.TBLOGRENCİ.Where(p => p.AD.EndsWith("R")).ToList();
                dataGridView1.DataSource = liste7;
            }
            if (radioButton8.Checked==true)
            {
                bool deger = db.TBLDERSLER.Any();
                MessageBox.Show(deger.ToString(), "Bilgi", MessageBoxButtons.OK,  MessageBoxIcon.Information);
            }
            if (radioButton9.Checked==true)
            {
                int toplam = db.TBLOGRENCİ.Count();
                MessageBox.Show(toplam.ToString(), "Toplam Öğrenci Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (radioButton10.Checked==true)
            {
                var toplam = db.TBLNOTLAR.Sum(p => p.SINAV1);
                MessageBox.Show("Toplam Sınav1 Puanı: " + toplam.ToString());
            }
            if (radioButton11.Checked==true)
            {
                var ortalama = db.TBLNOTLAR.Average(p => p.SINAV1);
                MessageBox.Show("1. Sınavın Ortalaması: "+ ortalama.ToString());
            }
            if (radioButton12.Checked==true)
            {
                var enyuksek = db.TBLNOTLAR.Max(p => p.SINAV1);
                MessageBox.Show("1. Sınavın En Yüksek Notu: " + enyuksek.ToString());
            }
            if (radioButton13.Checked==true)
            {
                var endusuk = db.TBLNOTLAR.Min(p => p.SINAV1);
                MessageBox.Show("1. Sınavın En Düşük Notu: " + endusuk.ToString());

            }
        }

        
    } 
}
