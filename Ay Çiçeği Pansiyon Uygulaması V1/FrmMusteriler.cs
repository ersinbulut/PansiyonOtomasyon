using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Ay_Çiçeği_Pansiyon_Uygulaması_V1
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LENOVO-ERSIN;Initial Catalog=AycicegiPansiyon;Integrated Security=True;TrustServerCertificate=True");

        private void verilerigoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["MusteriID"].ToString();
                ekle.SubItems.Add(oku["Adi"].ToString());
                ekle.SubItems.Add(oku["Soyadi"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["TC"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["GirisTarihi"].ToString());
                ekle.SubItems.Add(oku["CikisTarihi"].ToString());

                listView1.Items.Add(ekle);
            }

            // Close the connection after finishing the loop
            baglanti.Close();
        }

        private void btnVerileriGoster_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }
        int id = 0;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            TxtAdi.Text = listView1.SelectedItems[0].SubItems[1].Text;
            TxtSoyadi.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            MskTxtTelefon.Text = listView1.SelectedItems[0].SubItems[4].Text;
            TxtMail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            TxtTcKimlikNo.Text = listView1.SelectedItems[0].SubItems[6].Text;
            TxtOdaNumarasi.Text = listView1.SelectedItems[0].SubItems[7].Text;
            TxtUcret.Text = listView1.SelectedItems[0].SubItems[8].Text;
            DtpGirisTarihi.Text = listView1.SelectedItems[0].SubItems[9].Text;
            DtpCikisTarihi.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update MusteriEkle set Adi=@Adi, Soyadi=@Soyadi, Cinsiyet=@Cinsiyet, Telefon=@Telefon, Mail=@Mail, TC=@TC, OdaNo=@OdaNo, Ucret=@Ucret, GirisTarihi=@GirisTarihi, CikisTarihi=@CikisTarihi where MusteriID=@MusteriID", baglanti);

            // Parametreleri tanımla
            komut.Parameters.AddWithValue("@Adi", TxtAdi.Text);
            komut.Parameters.AddWithValue("@Soyadi", TxtSoyadi.Text);
            komut.Parameters.AddWithValue("@Cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@Telefon", MskTxtTelefon.Text);
            komut.Parameters.AddWithValue("@Mail", TxtMail.Text);
            komut.Parameters.AddWithValue("@TC", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@OdaNo", TxtOdaNumarasi.Text);
            komut.Parameters.AddWithValue("@Ucret", TxtUcret.Text);
            komut.Parameters.AddWithValue("@GirisTarihi", DtpGirisTarihi.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@CikisTarihi", DtpCikisTarihi.Value.ToString("yyyy-MM-dd"));
            komut.Parameters.AddWithValue("@MusteriID", id);

            komut.ExecuteNonQuery();
            baglanti.Close();

            // Verileri yeniden göster
            verilerigoster();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from MusteriEkle where MusteriID=(" + id+")",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigoster();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtAdi.Clear();
            TxtSoyadi.Clear();
            MskTxtTelefon.Clear();
            TxtMail.Clear();
            TxtTcKimlikNo.Clear();
            TxtOdaNumarasi.Clear();
            TxtUcret.Clear();
            DtpGirisTarihi.Text = "";
            DtpCikisTarihi.Text = "";
        }
    }
}
