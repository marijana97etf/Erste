using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Erste.Administrator
{
    /// <summary>
    /// Interaction logic for NalogSluzbenikaDialog.xaml
    /// </summary>
    public partial class NalogSluzbenikaDialog : Window
    {

        private sluzbenik sluzbenik = null;
        private Boolean izmjena = false;
        private const string uredu = "Uredu";
        private const string otkazi = "Otkazi";
        private const string izmjeni = "Izmjeni";
        private const string obrisi = "Obrisi";

        public NalogSluzbenikaDialog(sluzbenik sluzbenik)
        {
            InitializeComponent();
            this.sluzbenik = sluzbenik;
            textBox_Id.IsEnabled = false;
            if (sluzbenik != null)
            {
                Button_Uredu.Content = izmjeni;
                Button_Otkazi.Content = obrisi;

                textBox_Id.IsEnabled = false;
                textBox_Ime.IsEnabled = false;
                textBox_Prezime.IsEnabled = false;
                textBox_Email.IsEnabled = false;
                textBox_BrojTelefona.IsEnabled = false;
                textBox_KorisnickoIme.IsEnabled = false;
                textBox_Lozinka.IsEnabled = false;
                textBox_LozinkaProvjera.IsEnabled = false;

                textBox_Id.Text = sluzbenik.Id.ToString();
                textBox_Ime.Text = sluzbenik.osoba.Ime;
                textBox_Prezime.Text = sluzbenik.osoba.Prezime;
                textBox_Email.Text = sluzbenik.osoba.Email;
                textBox_BrojTelefona.Text = sluzbenik.osoba.BrojTelefona;
                textBox_KorisnickoIme.Text = sluzbenik.KorisnickoIme;
                textBox_Lozinka.Password = sluzbenik.LozinkaHash;
                textBox_LozinkaProvjera.Password = sluzbenik.LozinkaHash;
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
                textBox_KorisnickoIme.IsEnabled = true;
                textBox_Lozinka.IsEnabled = true;
                textBox_LozinkaProvjera.IsEnabled = true;

                Button_Uredu.Content = uredu;
                Button_Otkazi.Content = otkazi;
                izmjena = true;
            }
            else
            {
                if (!String.IsNullOrEmpty(textBox_Ime.Text) &&
                    !String.IsNullOrEmpty(textBox_Prezime.Text) &&
                    !String.IsNullOrEmpty(textBox_Email.Text) &&
                    !String.IsNullOrEmpty(textBox_BrojTelefona.Text) &&
                    !String.IsNullOrEmpty(textBox_KorisnickoIme.Text) &&
                    !String.IsNullOrEmpty(textBox_Lozinka.Password) &&
                    textBox_Lozinka.Password.Equals(textBox_LozinkaProvjera.Password))
                {
                    if (sluzbenik != null)
                    {
                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                sluzbenik = ersteModel.sluzbenici.Find(sluzbenik.Id);
                                sluzbenik.osoba.Ime = textBox_Ime.Text;
                                sluzbenik.osoba.Prezime = textBox_Prezime.Text;
                                sluzbenik.osoba.Email = textBox_Email.Text;
                                sluzbenik.osoba.BrojTelefona = textBox_BrojTelefona.Text;
                                sluzbenik.KorisnickoIme = textBox_KorisnickoIme.Text;
                                if (!sluzbenik.LozinkaHash.Equals(textBox_Lozinka.Password))
                                {
                                    HashGenerator hashGenerator = new HashGenerator();
                                    sluzbenik.LozinkaHash = hashGenerator.ComputeHash(textBox_Lozinka.Password);
                                }
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
                        sluzbenik sluzbenik = new sluzbenik();
                        sluzbenik.osoba = new osoba();
                        sluzbenik.osoba.Ime = textBox_Ime.Text;
                        sluzbenik.osoba.Prezime = textBox_Prezime.Text;
                        sluzbenik.osoba.Email = textBox_Email.Text;
                        sluzbenik.osoba.BrojTelefona = textBox_BrojTelefona.Text;
                        sluzbenik.KorisnickoIme = textBox_KorisnickoIme.Text;

                        HashGenerator hashGenerator = new HashGenerator();
                        sluzbenik.LozinkaHash = hashGenerator.ComputeHash(textBox_Lozinka.Password);

                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                ersteModel.sluzbenici.Add(sluzbenik);
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
                    if (String.IsNullOrEmpty(textBox_Ime.Text))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (String.IsNullOrEmpty(textBox_Prezime.Text))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (String.IsNullOrEmpty(textBox_Email.Text))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (String.IsNullOrEmpty(textBox_BrojTelefona.Text))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (String.IsNullOrEmpty(textBox_KorisnickoIme.Text))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (String.IsNullOrEmpty(textBox_Lozinka.Password))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                    else if (textBox_Lozinka.Password.Equals(textBox_LozinkaProvjera.Password))
                    {
                        MessageBox.Show("Lozinke moraju biti iste.");
                    }
                }
            }
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            if (sluzbenik != null && !izmjena)
            {
                try
                {
                    using (var ersteModel = new ErsteModel())
                    {
                        //Mozda treba setovati da nije aktivan
                        sluzbenik sluzbenik_remove = ersteModel.sluzbenici.Find(sluzbenik.Id);
                        if (sluzbenik_remove.osoba != null)
                        {
                            ersteModel.osobe.Remove(sluzbenik_remove.osoba);
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
