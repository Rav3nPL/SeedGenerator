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
            ddIle.SelectedIndex = 4;
            panel1.Visible = false;
            DodajKarty();
            Icon = Properties.Resources.the_crow;
            MessageBox.Show("INSTRUKCJA\n\n" +
                "1. Przygotuj talię 52 kart.\n" +
                "2. Potasuj ją metodą 'riffle shiffle' co najmniej 7 razy\n" +
                "3. Wybierz długość mnemonica jaki chcesz uzyskać\n" +
                "4. Klikaj kolejne wylosowane karty zgodnie z poleceniami\n" +
                "5. Potasuj talię ponownie i wylosuj/klikaj drugi raz\n" +
                "6. Wygenerowany mnemonic pojawi się w dolnym okienku\n" +
                "7. Przed rozpoczęciem klikania możesz wpisać 'coś' w pole salt\n\n" +
                "ps. Napiwki mile widziane :)");
        }

        //2-9, 10 (Ten), walet, dama, król, as
        readonly string[] karty = { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };

        // Clubs=trefle, Diamonts=karo, Spades=piki, Hearts=kier
        readonly string[] kolory = { "C", "D", "S", "H" };

        readonly Dictionary<char, Image> bitmapy = new Dictionary<char, Image>() {
            { 'C', Properties.Resources.Suit_clubs_trefl},
            { 'D', Properties.Resources.Suit_diamonds_karo},
            { 'S', Properties.Resources.Suit_spades_pik},
            { 'H', Properties.Resources.Suit_hearts_kier}
        };

        int ileKart = 0;
        int klikniete = 0;
        int talia = 0;

        private void BtStart_Click(object sender, EventArgs e)
        {
            btStart.Enabled = false;
            ddIle.Enabled = false;
            ileKart = Convert.ToInt32(ddIle.GetItemText(ddIle.SelectedItem));
            if (ileKart == 24) { ileKart++; } // dopiero (52!/(52-25)!)^2 > 2^256

            MessageBox.Show("Do tego potrzebuję dwa rozdania po " + ileKart + " kart z talii.\n" +
                "Klikaj teraz kolejne karty z pierwszej talii.");
            panel1.Visible = true;
        }

        private void Jeszcze(int ile)
        {
            MessageBox.Show("Potrzebuję kolejne " + ile + " kart.\n" +
                "Potasuj 'dobrze' i klikaj dalej.");
            //aktywujemy karty do klikania
            foreach (Control c in panel1.Controls)
            {
                c.Enabled = true;
            }
        }

        private void DodajKarty()
        {
            for (int i = 0; i < kolory.Length; i++)
            {
                int y = 20 + i * 100;
                for (int j = 0; j < karty.Length; j++)
                {
                    int x = 10 + j * 60;
                    string k = karty[j] + kolory[i];
                    DodajKartę(k, x, y);
                }
            }
        }

        private void DodajKartę(string karta, int locX, int locY)
        {
            Button b = new Button
            {
                Name = karta,
                Location = new Point(locX, locY),
                Size = new Size(60, 100)
            };
            b.Click += new EventHandler(Karta_Click);

            b.BackgroundImage = new Bitmap(bitmapy[karta[1]], new Size(b.Size.Width - 10, b.Size.Height - 25));

            b.BackgroundImageLayout = ImageLayout.Center;
            b.Text = karta[0].ToString();
            if (b.Text == "T") { b.Text = "10"; }
            b.TextAlign = ContentAlignment.MiddleCenter;
            b.Font = new Font("Arial", 20);
            b.ForeColor = Color.GreenYellow;
            panel1.Controls.Add(b);
        }

        private void Karta_Click(object sender, EventArgs e)
        {
            klikniete++;
            Control c = (Control)sender;
            tbEnt.Text += c.Name;
            c.Enabled = false;
            using (SHA512 s = SHA512.Create())
            {
                //robimy salt używając tekstu z okienka salt i czasu pracy programu
                tbSalt.Text = Convert.ToBase64String(s.ComputeHash(Encoding.ASCII.GetBytes(tbSalt.Text + (DateTime.Now - Process.GetCurrentProcess().StartTime).ToString())));
            }

            if (klikniete == ileKart)
            {
                klikniete = 0;
                talia++;
                if (talia == 1)
                {
                    Jeszcze(ileKart);
                }
                else
                {
                    LiczSeed();
                    MessageBox.Show("Gotowe! Mnemonic jest w boxsie :)\n" +
                        "Kliknij box żeby skopiować mnemonic do schowka");
                }
            }
        }

        void LiczSeed()
        {
            int[] b = { 128, 160, 192, 224, 256 };
            using (SHA512 s512 = SHA512.Create())
            using (SHA256 s256 = SHA256.Create())
            {
                //bieżemy sha512 z textu entropii + salt -> mamy super-entropię w bajtach
                byte[] dane = s512.ComputeHash(Encoding.ASCII.GetBytes(tbEnt.Text + tbSalt.Text));

                //potrzebujemy tylko b bitów entropii
                int entLen = b[ddIle.SelectedIndex];
                //obcinamy
                dane = dane.Take(entLen / 8).ToArray();

                //będziemy potrzebowali w formie binarnej
                string seed = string.Join("", dane.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
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
                    mnemonic += slowa[nrSlowa].Trim() + " ";
                }
                tbMnemonic.Text = mnemonic;//ta-da!
            }
        }

        private void BtRestart_Click(object sender, EventArgs e)
        {
            Application.Restart(); //serio, nie chciało mi się sprzątać XD
        }

        private void CopyOn_Click(object sender, EventArgs e)
        {
            TextBox caller = (TextBox)sender;
            Clipboard.SetText(caller.Text);
            MessageBox.Show("Skopiowane do schowka");
        }
    }
}
