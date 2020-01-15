using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EvidencijaKursaDialog.xaml
    /// </summary>
    public partial class EvidencijaKursaDialog : Window
    {
        ObservableCollection<jezik> comboBoxList = new ObservableCollection<jezik>();

        private kurs kurs = null;
        private Boolean izmjena = false;
        private const string uredu = "Uredu";
        private const string otkazi = "Otkazi";
        private const string izmjeni = "Izmjeni";
        private const string obrisi = "Obrisi";

        public EvidencijaKursaDialog(kurs kurs)
        {
            InitializeComponent();

            try
            {
                using(var ersteModel = new ErsteModel())
                {
                    var jezici = (from jezik in ersteModel.jezici
                                  select jezik).ToList();
                    foreach(var jezik in jezici)
                    {
                        comboBoxList.Add(jezik);
                    }
                    comboBox_Jezik.ItemsSource = comboBoxList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Exception: " + ex.ToString());
            }

            this.kurs = kurs;
            textBox_Id.IsEnabled = false;
            if (kurs != null)
            {
                Button_Uredu.Content = izmjeni;
                Button_Otkazi.Content = obrisi;

                textBox_Id.IsEnabled = false;
                comboBox_Jezik.IsEnabled = false;
                textBox_Nivo.IsEnabled = false;

                textBox_Id.Text = kurs.Id.ToString();
                comboBox_Jezik.SelectedIndex = comboBoxList.IndexOf(kurs.jezik);
                textBox_Nivo.Text = kurs.Nivo;
            }
        }

        private void Button_Uredu_Click(object sender, RoutedEventArgs e)
        {
            if (!izmjena)
            {
                comboBox_Jezik.IsEnabled = true;
                textBox_Nivo.IsEnabled = true;

                Button_Uredu.Content = uredu;
                Button_Otkazi.Content = otkazi;
                izmjena = true;
            }
            else
            {
                if (!String.IsNullOrEmpty(textBox_Nivo.Text) && comboBox_Jezik.SelectedIndex != -1)
                {
                    if (kurs != null)
                    {
                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                kurs = ersteModel.kursevi.Find(kurs.Id);
                                kurs.Nivo = textBox_Nivo.Text;
                                kurs.JezikId = (comboBox_Jezik.SelectedItem as jezik).Id;
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
                        kurs kurs = new kurs();
                        kurs.Nivo = textBox_Nivo.Text;
                        kurs.JezikId = (comboBox_Jezik.SelectedItem as jezik).Id;

                        try
                        {
                            using (var ersteModel = new ErsteModel())
                            {
                                ersteModel.kursevi.Add(kurs);
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
                    if (String.IsNullOrEmpty(textBox_Nivo.Text))
                    {
                        MessageBox.Show("Niste unijeli kurs.");
                    }
                    else if (comboBox_Jezik.SelectedIndex == -1)
                    {
                        MessageBox.Show("Niste izabrali jezik.");
                    }
                }
            }
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            if (kurs != null && !izmjena)
            {
                try
                {
                    using (var ersteModel = new ErsteModel())
                    {
                        //Mozda treba setovati da nije aktivan
                        kurs kurs_remove = ersteModel.kursevi.Find(kurs.Id);
                        ersteModel.kursevi.Remove(kurs_remove);
                        ersteModel.SaveChanges();
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
