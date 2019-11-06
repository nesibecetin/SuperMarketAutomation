using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veri_Yapilari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string UrunNumarasi;
        string UrunAdi;
        string Modeli;
        string Markasi;
        string SatisFiyati;
        string Maliyeti;
        string Miktari;
        string Aciklama;
        string Kategori;

        LinkedList ll = new LinkedList();
        Tree tr = new Tree();
        HashTable h = new HashTable();
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || TxtUrunNumarasi.Text == "" || TxtMarkasi.Text == "" || TxtModel.Text == "" || TxtSatisFiyati.Text == "" || txtMaliyet.Text == "" || txtStokMiktari.Text == "" || txtAciklama.Text == "" || cmbKategori.Text == "")
                MessageBox.Show("Lütfen Bütün Alanları Eksiksiz Doldurun");

            else
            {

                Urun u = new Urun();
                Urun2 u2 = new Urun2();
                Urun3 u3 = new Urun3();

                u.Ad = TxtAd.Text;
                u.UrunNumarasi = Convert.ToInt32(TxtUrunNumarasi.Text);
                u.Model = TxtModel.Text;
                u.Marka = TxtMarkasi.Text;     
                u.Maliyeti = Convert.ToInt32(txtMaliyet.Text);
                u.Miktari = Convert.ToInt32(txtStokMiktari.Text);
                u.SatisFiyati = Convert.ToInt32(TxtSatisFiyati.Text);
                u.UrunAciklamasi = txtAciklama.Text;

                u2.llUrunNumarasi = Convert.ToInt32(TxtUrunNumarasi.Text);
                u2.Kategori = cmbKategori.Text;
                u3.Ad = TxtAd.Text;
                u3.hashUrunNumarasi = Convert.ToInt32(TxtUrunNumarasi.Text);
                u3.Kategori = cmbKategori.Text;


                int deneme = 0;
                for (int j = 0; j < ll.Size; j++)
                {
                    if (ll.GetElement(j + 1).llVeri.llUrunNumarasi== u3.hashUrunNumarasi)
                    {
                        deneme = 1;
                    }
                }
                if (deneme == 1)
                {
                    MessageBox.Show("Ürün Numarası Aynı Daha Önceki Ürünlerle Aynı Olamaz");
                }
                else
                {

                    ll.Insert(u2);
                    tr.Ekle(u);
                    if (cmbKategori.Text == "Bilgisayar")
                        h.Ekle(1, u3);
                    else if (cmbKategori.Text == "Beyaz Eşya")
                        h.Ekle(2, u3);
                    else if (cmbKategori.Text == "Giyim")
                        h.Ekle(3, u3);
                    else if (cmbKategori.Text == "Kırtasiye & Ofis")
                        h.Ekle(4, u3);
                    else if (cmbKategori.Text == "Yapı Market")
                        h.Ekle(5, u3);
                    else if (cmbKategori.Text == "Bahçe")
                        h.Ekle(6, u3);
                    else if (cmbKategori.Text == "Tekstil")
                        h.Ekle(7, u3);
                    else if (cmbKategori.Text == "Yiyecek")
                        h.Ekle(8, u3);
                    cmbAdListesi.Items.Clear();
                    cmbUrunNumarasi.Items.Clear();

                    for (int i = 0; i < ll.Size; i++)
                    {
                        cmbAdListesi.Items.Add(ll.GetElement(i + 1).llVeri.llUrunNumarasi);
                        cmbUrunNumarasi.Items.Add(ll.GetElement(i + 1).llVeri.llUrunNumarasi);
                        cmbyorum.Items.Add(ll.GetElement(i + 1).llVeri.llUrunNumarasi);
                    }
                    MessageBox.Show("Ürün Başarılı Bir Şekilde Eklendi!");
               

                UrunNumarasi = (u.UrunNumarasi).ToString();
                UrunAdi = (u.Ad).ToString();
                Modeli = (u.Model).ToString();
                Markasi = (u.Marka).ToString();
                SatisFiyati = (u.SatisFiyati).ToString();
                Maliyeti = (u.Maliyeti).ToString();
                Miktari = (u.Miktari).ToString();
                Aciklama = (u.UrunAciklamasi).ToString();
                Kategori = (u2.Kategori).ToString();
                string[] Bilgiler = { UrunNumarasi, UrunAdi, Markasi, Modeli, SatisFiyati,Maliyeti, Miktari, Aciklama, Kategori };
                var satir = new ListViewItem(Bilgiler);
                lWPersonel.Items.Add(satir);

                }
                
            }
        }

        private void TxtUrunNumarasi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void TxtAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void TxtMarkasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
        private void txtMaliyet_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void TxtModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void TxtSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtStokMiktari_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtAciklama_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
     

        private void btnUrunGetir_Click(object sender, EventArgs e)
        {
            if (cmbAdListesi.Text == "")
            {
                MessageBox.Show("Lütfen Ürün Seçiniz");
            }
            else
            {
                int x = Convert.ToInt32(cmbAdListesi.Text);
                int i = 1;
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llUrunNumarasi == x)
                        break;
                    else
                        i++;
                }


                TxtAd.Text = tr.Ara(x).Veri.Ad;
                TxtUrunNumarasi.Text = Convert.ToString(tr.Ara(x).Veri.UrunNumarasi);
                TxtMarkasi.Text = tr.Ara(x).Veri.Marka;
                TxtModel.Text = tr.Ara(x).Veri.Model;
                txtMaliyet.Text = Convert.ToString(tr.Ara(x).Veri.Maliyeti);
                txtStokMiktari.Text = Convert.ToString(tr.Ara(x).Veri.Miktari);
                TxtSatisFiyati.Text = Convert.ToString(tr.Ara(x).Veri.SatisFiyati);
                txtAciklama.Text = tr.Ara(x).Veri.UrunAciklamasi;
                TxtUrunNumarasi.Text = Convert.ToString(ll.GetElement(i).llVeri.llUrunNumarasi);
                cmbKategori.Text = ll.GetElement(i).llVeri.Kategori;

                MessageBox.Show("Ürün Getirildi!");
                   btnGüncelle.Enabled = true;
                   btnSil.Enabled = true;
               
            }
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {


                int i = 1;
                int guncelle = Convert.ToInt32(cmbAdListesi.Text);
                tr.Sil(guncelle);
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llUrunNumarasi == guncelle)
                        break;
                    else
                        i++;
                }
                ll.Delete(i);
                Urun u = new Urun();
                Urun2 u2 = new Urun2();
                u.Ad = TxtAd.Text;
                u.UrunNumarasi = Convert.ToInt32(TxtUrunNumarasi.Text);
                u.Model = TxtModel.Text;
                u.Marka = TxtMarkasi.Text;
                u.Maliyeti = Convert.ToInt32(txtMaliyet.Text);
                u.Miktari = Convert.ToInt32(txtStokMiktari.Text);
                u.SatisFiyati = Convert.ToInt32(TxtSatisFiyati.Text);
                u.UrunAciklamasi = txtAciklama.Text;
                u2.llUrunNumarasi = Convert.ToInt32(TxtUrunNumarasi.Text);
                u2.Kategori = cmbKategori.Text;
               

            
                ll.Insert(u2);
                tr.Ekle(u);
                cmbAdListesi.Items.Clear(); 
                cmbUrunNumarasi.Items.Clear();
                cmbyorum.Items.Clear();
                for (int j = 0; j < ll.Size; j++)
                {
                    cmbAdListesi.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);
                    cmbUrunNumarasi.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);
                    cmbyorum.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);
                }
                MessageBox.Show("Ürün Başarılı Bir Şekilde Güncellendi!");
            }

            catch (Exception)
            {

                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 1;
                int silinen = Convert.ToInt32(cmbAdListesi.Text);
                tr.Sil(silinen);
                for (; ; )
                {
                    if (ll.GetElement(i).llVeri.llUrunNumarasi == silinen)
                        break;
                    else
                        i++;
                }
                ll.Delete(i);
                cmbAdListesi.Items.Clear();
                cmbAdListesi.Text = "";
                cmbUrunNumarasi.Items.Clear();
                cmbyorum.Items.Clear();

                for (int j = 0; j < ll.Size; j++)
                {
                    cmbAdListesi.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);
                    cmbUrunNumarasi.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);
                    cmbyorum.Items.Add(ll.GetElement(j + 1).llVeri.llUrunNumarasi);

                }
                MessageBox.Show("Silme İşlemi Başarılı!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            lBListele.Items.Clear();
            if (cmbListele.Text == "")
            {
                MessageBox.Show("Geçerli Seçenek Seçiniz!");
            }
            else if (cmbListele.Text == "Inorder")
            {
                lBListele.Items.Add(tr.InOrder());
            }
            else if (cmbListele.Text == "Preorder")
            {
                lBListele.Items.Add(tr.PreOrder());
            }
            else if (cmbListele.Text == "Postorder")
            {
                lBListele.Items.Add(tr.PostOrder());
            }
        }

        private void btnAgacDerinliği_Click(object sender, EventArgs e)
        {
            txtAgacDerinligi.Text = Convert.ToString(tr.DerinlikBul());
        }

        private void btnElemanSayısı_Click(object sender, EventArgs e)
        {
            txtElemanSayisi.Text = Convert.ToString(tr.DugumSayisi());
        }

        private void btnUrunBilgisiListele_Click(object sender, EventArgs e)
        {
            if (cmbUrunNumarasi.Text == "")
            {
                MessageBox.Show("Lütfen Geçerli Seçim Yapınız!");
            }
            else
            {
                Urun u = new Urun();
                Urun2 u2 = new Urun2();
                for (int i = 0; i < ll.Size; i++)
                {
                    if (tr.Ara(ll.GetElement(i + 1).llVeri.llUrunNumarasi).Veri.UrunNumarasi == Convert.ToInt32(cmbUrunNumarasi.Text))
                        u = tr.Ara(ll.GetElement(i + 1).llVeri.llUrunNumarasi).Veri;
                    if (ll.GetElement(i + 1).llVeri.llUrunNumarasi == Convert.ToInt32(cmbUrunNumarasi.Text))
                        u2 = ll.GetElement(i + 1).llVeri;
                }

                UrunNumarasi = (u.UrunNumarasi).ToString();
                UrunAdi = (u.Ad).ToString();
                Modeli = (u.Model).ToString();
                Markasi = (u.Marka).ToString();
                SatisFiyati = (u.SatisFiyati).ToString();
                Miktari = (u.Miktari).ToString();
                Aciklama = (u.UrunAciklamasi).ToString();
                Kategori = (u2.Kategori).ToString();
                string[] Bilgiler = { UrunNumarasi, UrunAdi, Markasi, Modeli, SatisFiyati, Miktari, Aciklama, Kategori };
                var satir = new ListViewItem(Bilgiler);
                listView1.Items.Add(satir);
                
            }
        }

        private static void CopySelectedItems(ListView source, ListView target)
        {
            foreach (ListViewItem item in source.SelectedItems)
            {
                target.Items.Add((ListViewItem)item.Clone());
            }
        }
        

        private void btnSepeteEkle_Click_1(object sender, EventArgs e)
        {
            CopySelectedItems(listView1, listView2);

        }

        private void btnKayıtol_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Başarıyla Kayıt Oldunuz.");
            txtBad.Text ="";
            TxtSoyad.Text = "";
            TxtEmail.Text = "";
            txtSifre.Text = "";

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yorum eklendi.");
            txtYorum.Text = "";
        }
    }

}
