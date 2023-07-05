using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KurtAvi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int saldiri = 1;
        int canavarHP = 10;
        int altin = 600;
        int seviye = 1;
        int xp = 0;
        int seviyeAtlat = 500;
        int canavarDeger = 10;

        private void Form1_Load(object sender, EventArgs e)
        {
            lblAltin.Text = altin.ToString();
            lblCanavarHP.Text = canavarHP.ToString();
            lblHasar.Text = saldiri.ToString();
            lblSeviye.Text = seviye.ToString();
            lblHasarKazan.Text = "20 Altın";
            lblOtomatikHasar.Text = "300 Altın";
            lblYariYariya.Text = "100 Altın";

            lblDakika.Text = dakika.ToString();
            lblSalise.Text = salise.ToString();
            lblSaniye.Text = saniye.ToString();
        }

        void CanavariOldur()
        {
            if (canavarHP <= 0)
            {
                altin = altin + 10;
                canavarHP = canavarDeger;
                canavarDeger += 10;
                lblCanavarHP.Text = canavarHP.ToString();
                lblAltin.Text = altin.ToString();
                xp = xp + 100;
                lblSeviyeAtlama.Text = "";
                if (xp == seviyeAtlat)
                {
                    seviye = seviye + 1;
                    seviyeAtlat = seviyeAtlat * 2;
                    canavarHP = canavarHP * 2;
                    canavarDeger = canavarDeger * 2;
                    lblSeviye.Text = seviye.ToString();
                    lblCanavarHP.Text = canavarHP.ToString();
                    lblSeviyeAtlama.Text = "SEVİYE ATLADIN!";
                }
            }
        }

        private void btnSaldir_Click(object sender, EventArgs e)
        {
                canavarHP = canavarHP - saldiri;
                lblCanavarHP.Text = null;
                lblCanavarHP.Text += canavarHP.ToString();
                CanavariOldur();
        }

        private void btnHasar_Click(object sender, EventArgs e)
        {
                 if (altin <= 19)
                 {
                     MessageBox.Show($"Yeterli altınınız bulunmuyor!\n{20 - altin} altına ihtiyacınız var.");
                 }
                 else
                 {
                     altin = altin - 20;
                     lblAltin.Text = altin.ToString();
                     saldiri = saldiri + 1;
                     lblHasar.Text = saldiri.ToString();
            }
        }

        private void btnYarim_Click(object sender, EventArgs e)
        {
            if (altin <= 99)
            {
                MessageBox.Show($"Yeterli altınınız bulunmuyor!\n{100 - altin} altına ihtiyacınız var.");
            }
            else if (saldiri > canavarHP)
            {
                DialogResult result = MessageBox.Show("Saldırı gücünüz canavarın gücünden yüksek.", "Emin misiniz?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    canavarHP = 0;
                    altin = altin - 100;
                    lblAltin.Text = altin.ToString();
                    CanavariOldur();
                }
            }
            else if (saldiri == canavarHP)
            {
                DialogResult result = MessageBox.Show("Saldırı gücünüz canavarın gücüyle eşit.", "Emin misiniz?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    canavarHP = 0;
                    altin = altin - 100;
                    lblAltin.Text = altin.ToString();
                    CanavariOldur();
                }
            }
            else
            {
                altin = altin - 100;
                lblAltin.Text = altin.ToString();
                canavarHP = canavarHP / 2;
                lblCanavarHP.Text = canavarHP.ToString();
                CanavariOldur();
            }
        }
        int salise = 100;
        int saniye = 2;
        int dakika = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            salise--;
            if (salise == 0)
            {
                salise = 100;
                saniye--;
                canavarHP = canavarHP - 50;
                lblCanavarHP.Text = canavarHP.ToString();
                CanavariOldur();
            }
            else if (saniye == 0)
            {
                saniye = 59;
                dakika--;
            }
            else if (dakika < 0)
            {
                timer1.Stop();
                salise = 100;
                saniye = 59;
                dakika = 2;
                MessageBox.Show("Yetenek Süresi Doldu!");
            }
            lblDakika.Text = dakika.ToString();
            lblSalise.Text = salise.ToString();
            lblSaniye.Text = saniye.ToString();
        }

        private void btnOtomatikHasar_Click(object sender, EventArgs e)
        {
            if (altin <= 300)
            {
                MessageBox.Show($"Yeterli altınınız bulunmuyor!\n{300 - altin} altına ihtiyacınız var.");
            }
            else if (timer1.Enabled == true)
            {
                MessageBox.Show("Otomatik Hasar yeteneğini aktif olarak kullanıyorsunuz.");
            }
            else
            {
                altin = altin - 300;
                lblAltin.Text = altin.ToString();
                timer1.Start();
            }
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            lblBilgi.Text = "20 altın karşılığında saldırı gücünüzü +1 puan yükseltir.";
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            lblBilgi.Text = "100 altın karşılığında canavarın canını yarı yarıya indirir. Eğer saldırı gücünüz ile canavarın canı aynı ise canavarı yok eder.";

        }

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            lblBilgi.Text = "300 altın karşılığında tam 3 dakika boyunca saniye başına otomatik olarak +50 saldırı gücü uygular.";

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {
            lblBilgi.Text = "Bilgi için yeteneklerin resimlerine mouse'unuzu götürün.";

        }
    }
}
