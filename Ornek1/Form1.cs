using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ornek1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OkulEntities ef = new OkulEntities();
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            ogrenciBilgileri yeniOgrenci = new ogrenciBilgileri();
            yeniOgrenci.adSoyad = txtadSoyad.Text;
            yeniOgrenci.kayitTarihi = dtkayitTarihi.Value;
            yeniOgrenci.gsmNo = txtgsmNo.Text;

            ef.ogrenciBilgileri.Add(yeniOgrenci);
            ef.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var item in ef.ogrenciBilgileri)
            {
                cmbxId.Items.Add(item.Id);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxId.Text);
            var silinecek = ef.ogrenciBilgileri.Where(x => x.Id == id).FirstOrDefault();
            ef.ogrenciBilgileri.Remove(silinecek);
            ef.SaveChanges();
        }

        private void cmbxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxId.Text);
            var goruntulenecek = ef.ogrenciBilgileri.Where(x => x.Id == id).ToList();

            foreach (var item in goruntulenecek)
            {
                dtkayitTarihi.Value =Convert.ToDateTime(item.kayitTarihi).Date;
                txtadSoyad.Text = item.adSoyad;
                txtgsmNo.Text = item.gsmNo;
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmbxId.Text);
            var update = ef.ogrenciBilgileri.Where(x => x.Id == id).FirstOrDefault();

            update.adSoyad = txtadSoyad.Text;
            update.gsmNo = txtgsmNo.Text;
            update.kayitTarihi = Convert.ToDateTime(dtkayitTarihi.Value).Date;

            ef.SaveChanges();

        }
    }
}
