using System;
using System.Windows;
using Erste.Model;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for NalogSluzbenikaDialog.xaml
    /// </summary>
    public partial class KandidatiDialog : Window
    {

        private polaznik polaznik = null;
        private bool izmjena = false;
        private const string uredu = "Uredu";
        private const string otkazi = "Otkaži";
        private const string izmjeni = "Izmijeni";
        private const string obrisi = "Obriši";

        public KandidatiDialog(polaznik polaznik)
        {
            InitializeComponent();
            this.polaznik = polaznik;

            if (polaznik != null)
            {
                Button_Uredu.Content = izmjeni;
                Button_Otkazi.Content = obrisi;

                textBox_Ime.IsEnabled = false;
                textBox_Prezime.IsEnabled = false;
                textBox_Email.IsEnabled = false;
                textBox_BrojTelefona.IsEnabled = false;

                textBox_Ime.Text = polaznik.osoba.Ime;
                textBox_Prezime.Text = polaznik.osoba.Prezime;
                textBox_Email.Text = polaznik.osoba.Email;
                textBox_BrojTelefona.Text = polaznik.osoba.BrojTelefona;
            }
        }

        private void Button_Uredu_Click(object sender, RoutedEventArgs e)
        {
            if (!izmjena)
            {
                textBox_Ime.IsEnabled = true;
                textBox_Prezime.IsEnabled = true;
                textBox_Email.IsEnabled = true;
                textBox_BrojTelefona.IsEnabled = true;

                Button_Uredu.Content = uredu;
                Button_Otkazi.Content = otkazi;
                izmjena = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox_Ime.Text) &&
                    !string.IsNullOrEmpty(textBox_Prezime.Text) &&
                    !string.IsNullOrEmpty(textBox_Email.Text) &&
                    !string.IsNullOrEmpty(textBox_BrojTelefona.Text))
                {
                    if (polaznik != null)
                    {
                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                polaznik = ersteModel.polaznici.Find(polaznik.Id) ?? new polaznik();
                                polaznik.osoba.Ime = textBox_Ime.Text;
                                polaznik.osoba.Prezime = textBox_Prezime.Text;
                                polaznik.osoba.Email = textBox_Email.Text;
                                polaznik.osoba.BrojTelefona = textBox_BrojTelefona.Text;

                                // dodati još šta ima polaznik
                                ersteModel.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("MySQL Exception: " + ex.ToString());
                        }
                    }
                    else
                    {
                        polaznik polaznik = new polaznik();
                        polaznik.osoba = new osoba();
                        polaznik.osoba.Ime = textBox_Ime.Text;
                        polaznik.osoba.Prezime = textBox_Prezime.Text;
                        polaznik.osoba.Email = textBox_Email.Text;
                        polaznik.osoba.BrojTelefona = textBox_BrojTelefona.Text;

                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                ersteModel.polaznici.Add(polaznik);
                                ersteModel.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("MySQL Exception: " + ex.ToString());
                        }
                    }
                    Close();
                }
                else
                {
                    if (string.IsNullOrEmpty(textBox_Ime.Text) || string.IsNullOrEmpty(textBox_Prezime.Text)
                        || string.IsNullOrEmpty(textBox_Email.Text) || string.IsNullOrEmpty(textBox_BrojTelefona.Text))
                    {
                        MessageBox.Show("Sva polja moraju biti popunjena.");
                    }
                }
            }
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            if (polaznik != null && !izmjena)
            {
                try
                {
                    using (var ersteModel = new ErsteModel())
                    {
                        //Mozda treba setovati da nije aktivan
                        polaznik polaznikRemove = ersteModel.polaznici.Find(polaznik.Id);
                        if (polaznikRemove?.osoba != null)
                        {
                            ersteModel.osobe.Remove(polaznikRemove.osoba);
                            ersteModel.SaveChanges();
                        }
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("MySQL Exception: " + ex.ToString());
                }
            }
            else
            {
                Close();
            }
        }
    }
}
