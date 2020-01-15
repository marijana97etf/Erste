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
    /// Interaction logic for EvidencijaKurseva.xaml
    /// </summary>
    public partial class EvidencijaKurseva : Page
    {
        public EvidencijaKurseva()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            EvidencijaKursaDialog evidencijaKursaDialog = new EvidencijaKursaDialog(null);
            evidencijaKursaDialog.ShowDialog();

            Load_Data();
        }

        private void Button_Pregledaj(object sender, RoutedEventArgs e)
        {
            kurs kurs = DataGrid.SelectedItem as kurs;
            EvidencijaKursaDialog evidencijaKursaDialog = new EvidencijaKursaDialog(kurs);
            evidencijaKursaDialog.ShowDialog();

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
                    var kursevi = (from kurs in ersteModel.kursevi
                                   join jezik in ersteModel.jezici on kurs.JezikId equals jezik.Id
                                   select kurs).ToList();

                    foreach (var kurs in kursevi)
                    {
                        if (kurs.jezik != null)
                        {
                            DataGrid.Items.Add(kurs);
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
