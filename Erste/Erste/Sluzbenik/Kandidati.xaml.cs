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
        private String mode;
        public Kandidati(String mode)
        {
            InitializeComponent();

            this.mode = mode;
        }

        /*public Kandidati(params Button[] buttons) : this()
        {
            buttons[0].Click += (sender, args) =>
            {
                var dataGridSelectedItems = DataGrid.SelectedItems;
                using (var ersteModel = new ErsteModel())
                {
                    foreach (var dataGridSelectedItem in dataGridSelectedItems)
                    {
                        var polaznikRemove = ersteModel.polaznici.Find(((polaznik)dataGridSelectedItem).Id);
                        if (polaznikRemove?.osoba != null)
                        {
                            ersteModel.osobe.Remove(polaznikRemove.osoba);
                            ersteModel.SaveChanges();
                        }
                    }
                }
                Load_Data();
            };
            buttons[1].Click += (sender, args) =>
            {
                MessageBox.Show("Cekanje");
            };
        }*/

        /*private void PregledKandidata_DoubleClick(object sender, RoutedEventArgs e)
        {
            polaznik polaznik = DataGrid.SelectedItem as polaznik;
            KandidatiDialog kandidatiDialog = new KandidatiDialog(polaznik);
            kandidatiDialog.ShowDialog();

            Load_Data();
        }*/

        public void Refresh() => Load_Data();

        private void Load_Data()
        {
            DataGrid.Items.Clear();
            DataGrid.ItemsSource = null;
            DataGrid.Items.Refresh();
            try
            {
                using (var ersteModel = new ErsteModel())
                {
                    if ("svi".Equals(mode))
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
                    else if ("cekanje".Equals(mode))
                    {
                        var polazniciNaCekanju = (from polaznik in ersteModel.polaznici.Include("osoba")
                                                  join osoba in ersteModel.osobe.Include("polaznik") on polaznik.Id equals osoba.Id
                                                  where polaznik.grupe.Count == 0
                                                  select polaznik).ToList();

                        foreach (var polaznik in polazniciNaCekanju)
                        {
                            if (polaznik.osoba != null)
                            {
                                DataGrid.Items.Add(polaznik);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Exception: " + ex.ToString());
            }
        }

        private void DataGrid_OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            polaznik polaznik = DataGrid.SelectedItem as polaznik;
            KandidatiDialog kandidatiDialog = new KandidatiDialog(polaznik);
            kandidatiDialog.ShowDialog();
            Load_Data();
            e.Cancel = true;
        }
    }
}
