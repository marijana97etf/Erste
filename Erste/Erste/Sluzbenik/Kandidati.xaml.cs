using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Erste.Administrator;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for NaloziSluzbenika.xaml
    /// </summary>
    public partial class Kandidati : UserControl
    {
        public Kandidati()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            KandidatiDialog polaznikDialog = new KandidatiDialog(null);
            polaznikDialog.ShowDialog();

            Load_Data();
        }

        private void Button_Pregledaj(object sender, RoutedEventArgs e)
        {
            polaznik polaznik = DataGrid.SelectedItem as polaznik;
            KandidatiDialog kandidatiDialog = new KandidatiDialog(polaznik);
            kandidatiDialog.ShowDialog();

            Load_Data();
        }

        private void Load_Data()
        {
            
            DataGrid.Items.Clear();
            DataGrid.ItemsSource = null;
            DataGrid.Items.Refresh();
            try
            {
                using (var ersteModel = new ErsteModel())
                {
                    var polaznici = (from polaznik in ersteModel.polaznici.Include("osoba")
                                      join osoba in ersteModel.osobe.Include("polaznik") on polaznik.Id equals osoba.Id
                                      select polaznik).ToList();

                    foreach (var polaznik in polaznici)
                    {
                        if (polaznik.osoba != null)
                        {
                            DataGrid.Items.Add(polaznik);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Exception: " + ex.ToString());
            }
        }
    }
}
