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
    /// Interaction logic for EvidencijaProfesora.xaml
    /// </summary>
    public partial class EvidencijaProfesora : Page
    {
        public EvidencijaProfesora()
        {
            InitializeComponent();
            Load_Data();
        }

        private void Button_Dodaj(object sender, RoutedEventArgs e)
        {
            EvidencijaProfesoraDialog evidencijaProfesoraDialog = new EvidencijaProfesoraDialog(null);
            evidencijaProfesoraDialog.ShowDialog();

            Load_Data();
        }

        private void Button_Pregledaj(object sender, RoutedEventArgs e)
        {
            profesor profesor = DataGrid.SelectedItem as profesor;
            EvidencijaProfesoraDialog evidencijaProfesoraDialog = new EvidencijaProfesoraDialog(profesor);
            evidencijaProfesoraDialog.ShowDialog();

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
                    var profesori = (from profesor in ersteModel.profesori
                                      join osoba in ersteModel.osobe on profesor.Id equals osoba.Id
                                      select profesor).ToList();

                    foreach (var profesor in profesori)
                    {
                        if (profesor.osoba != null)
                        {
                            DataGrid.Items.Add(profesor);
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
