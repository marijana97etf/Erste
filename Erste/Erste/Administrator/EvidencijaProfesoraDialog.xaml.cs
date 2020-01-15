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
    /// Interaction logic for EvidencijaProfesoraDialog.xaml
    /// </summary>
    public partial class EvidencijaProfesoraDialog : Window
    {

        private profesor profesor = null;
        private Boolean izmjena = false;
        private const string uredu = "Uredu";
        private const string otkazi = "Otkazi";
        private const string izmjeni = "Izmjeni";
        private const string obrisi = "Obrisi";

        public EvidencijaProfesoraDialog(profesor profesor)
        {
            InitializeComponent();
            this.profesor = profesor;
            textBox_Id.IsEnabled = false;
            if (profesor != null)
            {
                Button_Uredu.Content = izmjeni;
                Button_Otkazi.Content = obrisi;

                textBox_Id.IsEnabled = false;
                textBox_Ime.IsEnabled = false;
                textBox_Prezime.IsEnabled = false;
                textBox_Email.IsEnabled = false;
                textBox_BrojTelefona.IsEnabled = false;

                textBox_Id.Text = profesor.Id.ToString();
                textBox_Ime.Text = profesor.osoba.Ime;
                textBox_Prezime.Text = profesor.osoba.Prezime;
                textBox_Email.Text = profesor.osoba.Email;
                textBox_BrojTelefona.Text = profesor.osoba.BrojTelefona;
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
                if (!String.IsNullOrEmpty(textBox_Ime.Text) &&
                    !String.IsNullOrEmpty(textBox_Prezime.Text) &&
                    !String.IsNullOrEmpty(textBox_Email.Text) &&
                    !String.IsNullOrEmpty(textBox_BrojTelefona.Text))
                {
                    if (profesor != null)
                    {
                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                profesor = ersteModel.profesori.Find(profesor.Id);
                                profesor.osoba.Ime = textBox_Ime.Text;
                                profesor.osoba.Prezime = textBox_Prezime.Text;
                                profesor.osoba.Email = textBox_Email.Text;
                                profesor.osoba.BrojTelefona = textBox_BrojTelefona.Text;
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
                        profesor profesor = new profesor();
                        profesor.osoba = new osoba();
                        profesor.osoba.Ime = textBox_Ime.Text;
                        profesor.osoba.Prezime = textBox_Prezime.Text;
                        profesor.osoba.Email = textBox_Email.Text;
                        profesor.osoba.BrojTelefona = textBox_BrojTelefona.Text;

                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                ersteModel.profesori.Add(profesor);
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
                }
            }
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            if (profesor != null && !izmjena)
            {
                try
                {
                    using (var ersteModel = new ErsteModel())
                    {
                        //Mozda treba setovati da nije aktivan
                        profesor profesor_remove = ersteModel.profesori.Find(profesor.Id);
                        if (profesor_remove.osoba != null)
                        {
                            ersteModel.osobe.Remove(profesor_remove.osoba);
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
