using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ay_Çiçeği_Pansiyon_Uygulaması_V1
{
    public partial class FrmYeniMusteri : Form
    {
        public FrmYeniMusteri()
        {
            InitializeComponent();
        }

        private void BtnOda101_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "101";
        }

        private void BtnOda102_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "102";
        }

        private void BtnOda103_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "103";
        }

        private void BtnOda104_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "104";
        }

        private void BtnOda105_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "105";
        }

        private void BtnOda106_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "106";
        }

        private void BtnOda107_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "107";
        }

        private void BtnOda108_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "108";
        }

        private void BtnOda109_Click(object sender, EventArgs e)
        {
            TxtOdaNumarasi.Text = "109";
        }

        private void BtnOdaDolu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kırmızı Renkli Butonlar Dolu Odaları Gösterir.");
        }

        private void BtnOdaBos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yeşil Renkli Butonlar Boş Odaları Gösterir.");
        }

        private void DtpCikisTarihi_ValueChanged(object sender, EventArgs e)
        {
            int Ucret;
            DateTime KucukTarih = Convert.ToDateTime(DtpGirisTarihi.Text);
            DateTime BuyukTarih = Convert.ToDateTime(DtpCikisTarihi.Text);

            TimeSpan Sonuc;
            Sonuc = BuyukTarih - KucukTarih;

            label11.Text = Sonuc.TotalDays.ToString();

            Ucret = Convert.ToInt32(label11.Text) * 50;
            TxtUcret.Text = Ucret.ToString();


        }
    }
}
