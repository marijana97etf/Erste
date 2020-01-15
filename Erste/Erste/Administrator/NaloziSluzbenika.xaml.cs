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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Erste.Administrator
{
    /// <summary>
    /// Interaction logic for NaloziSluzbenika.xaml
    /// </summary>
    public partial class NaloziSluzbenika : Page
    {
        public NaloziSluzbenika()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            NalogSluzbenikaDialog nalogSluzbenikaDialog = new NalogSluzbenikaDialog(null);
            nalogSluzbenikaDialog.ShowDialog();

            Load_Data();
        }

        private void Button_Pregledaj(object sender, RoutedEventArgs e)
        {
            sluzbenik sluzbenik = DataGrid.SelectedItem as sluzbenik;
            NalogSluzbenikaDialog nalogSluzbenikaDialog = new NalogSluzbenikaDialog(sluzbenik);
            nalogSluzbenikaDialog.ShowDialog();

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
                    var sluzbenici = (from sluzbenik in ersteModel.sluzbenici.Include("osoba")
                                      join osoba in ersteModel.osobe.Include("sluzbenik") on sluzbenik.Id equals osoba.Id
                                      select sluzbenik).ToList();

                    foreach(var sluzbenik in sluzbenici)
                    {
                        if (sluzbenik.osoba != null)
                        {
                            DataGrid.Items.Add(sluzbenik);
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
