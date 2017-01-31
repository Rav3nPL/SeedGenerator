using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SeedGenerator
{
    public partial class SeedGenerator : Form
    {
        public SeedGenerator()
        {
            InitializeComponent();
            ddIle.SelectedIndex = 0;
            dodajKarty();
            panel1.Visible = false;
            MessageBox.Show("INSTRUKCJA" + nl + nl + "1. Przygotuj talię 52 kart." + nl + "2. Potasuj ją metodą 'riffle shiffle' co najmniej 7 razy"
                + nl + "3. Wybierz długość mnemonica jaki chcesz uzyskać" + nl + "4. Klikaj kolejne wylosowane karty zgodnie z poleceniami" + nl
              + "5. Potasuj talię ponownie i wylosuj/klikaj drugi raz" + nl + "6. Wygenerowany mnemonic pojawi się w dolnym okienku" + nl
              + "6. Przed rozpoczęciem klikania możesz wpisać 'coś' w pole salt" + nl + nl + "ps. Napiwki mile widziane :)");
        }
        
        //2-9, 10 (Ten), walet, dama, król, as
        string[] karty = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

        // Clubs=trefle, Diamonts=karo, Spades=piki, Hearts=kier
        string[] kolory = { "C", "D", "S", "H" };

        int ileKart = 0;
        int klikniete = 0;
        int talia = 0;
        string nl = Environment.NewLine;

        private void btStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            switch (ddIle.SelectedIndex)
            {
                case 0:             //12 słów = 128 bitów
                    ileKart = 12;   // ilośc potrzebnych kart z jednej talii liczymy: (52!/(52-x)!)^2 > 2^bity
                    break;
                case 1:             //15 = 160 
                    ileKart = 15;
                    break;
                case 2:             //18 = 192 
                    ileKart = 18;
                    break;
                case 3:             //21 = 224 
                    ileKart = 21;
                    break;
                case 4:             //24 = 256 
                    ileKart = 25;
                    break;
            }

            MessageBox.Show("Do tego potrzebuję dwa rozdania po " + ileKart + " kart z talii." + nl + "Klikaj teraz kolejne karty z pierwszej talii.");
            panel1.Visible = true;
        }

        void jeszcze(int ile)
        {
            MessageBox.Show("Potrzebuję kolejne " + ile + " kart." + nl + "Potasuj 'dobrze' i klikaj dalej.");
            //aktywujemy karty do klikania
            foreach (Control c in panel1.Controls)
            {
                c.Enabled = true;
            }
        }

        void dodajKarty()
        {
            for (int i = 0; i < kolory.Length; i++)
            {
                int y = 20 + i * 100;
                for (int j = 0; j < karty.Length; j++)
                {
                    int x = 10 + j * 60;
                    string k = karty[j] + kolory[i];
                    dodajKartę(k, x, y);
                }
            }
        }

        void dodajKartę(string karta, int locX, int locY)
        {
            Button b = new Button();
            b.Name = karta;
            b.Location = new Point(locX, locY);
            b.Size = new Size(60, 100);
            b.Click += new EventHandler(karta_Click);
            Bitmap i = null;
            switch (karta[1].ToString())
            {
                case "C":
                    i = Properties.Resources.Suit_clubs_trefl;
                    break;
                case "D":
                    i = Properties.Resources.Suit_diamonds_karo;
                    break;
                case "S":
                    i = Properties.Resources.Suit_spades_pik;
                    break;
                case "H":
                    i = Properties.Resources.Suit_hearts_kier;
                    break;
            }

            b.BackgroundImage = new Bitmap(i, new Size(b.Size.Width - 10, b.Size.Height - 25));
            b.BackgroundImageLayout = ImageLayout.Center;
            b.Text = karta[0].ToString();
            if (b.Text == "T") { b.Text = "10"; }
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Font = new Font("Arial", 20);
            b.ForeColor = Color.GreenYellow;
            b.Visible = true;
            b.Show();
            panel1.Controls.Add(b);
        }

        void karta_Click(object sender, EventArgs e)
        {
            klikniete++;
            Control c = (Control)sender;
            tbEnt.Text += c.Name;
            c.Enabled = false;
            SHA512 s = SHA512.Create();
            //robimy salt używając tekstu z okienka salt i czasu pracy programu
            tbSalt.Text = Convert.ToBase64String(s.ComputeHash(Encoding.ASCII.GetBytes(tbSalt.Text + (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString())));

            if (klikniete == ileKart)
            {
                klikniete = 0;
                talia++;
                if (talia == 1)
                {
                    jeszcze(ileKart);
                }
                else
                {
                    liczSeed();
                    MessageBox.Show("Gotowe! Mnemonic jest w boxsie :)");
                }
            }
        }

        void liczSeed()
        {
            int[] b = { 128, 160, 192, 224, 256 };
            SHA512 s512 = SHA512.Create();

            //bieżemy sha512 z textu entropii + salt -> mamy super-entropię w bajtach
            byte[] dane = s512.ComputeHash(Encoding.ASCII.GetBytes(tbEnt.Text + tbSalt.Text));
            //potrzebujemy tylko b bitów entropii
            int entLen = b[ddIle.SelectedIndex];
            //obcinamy
            dane = dane.Take(entLen / 8).ToArray();

            //będziemy potrzebowali w formie binarnej
            string seed = string.Join("", dane.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

            SHA256 s256 = SHA256.Create();
            //haszujemy dla sumy kontrolnej
            byte[] cs = s256.ComputeHash(dane);
            //ile bitów do sumy kontrolnej
            int csLen = entLen / 32;

            string csBits = Convert.ToString(cs[0], 2).PadLeft(8, '0');
            csBits = csBits.Substring(0, csLen);

            //dodajemy dane i bity sumy kontolnej
            seed += csBits;
            tbSeed.Text = seed;

            //pobieramy słowa z listy
            List<string> slowa = Properties.Resources.english.Split(Convert.ToChar("\n")).ToList();

            //dzielimy wszystko na paczki po 11 bitów i przypisujemy słowa do każdej paczki
            string mnemonic = "";
            for (int i = 0; i < seed.Length; i += 11)
            {
                int nrSlowa = Convert.ToInt32(seed.Substring(i, 11), 2);
                mnemonic = mnemonic + slowa[nrSlowa] + " ";
            }
            tbMnemonic.Text = mnemonic;//ta-da!
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            Application.Restart(); //serio, nie chciało mi się sprzątać XD
        }
    }
}