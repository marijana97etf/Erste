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

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for UpisPolaznikaDialog.xaml
    /// </summary>
    public partial class UpisPolaznikaDialog : Window
    {
        public UpisPolaznikaDialog()
        {
            InitializeComponent();
        }

        private async void btn_PrikaziGrupe_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Jezik.Text) && string.IsNullOrEmpty(textBox_NivoKursa.Text))
            {
                if (Dispatcher != null)
                    await Dispatcher?.InvokeAsync(() =>
                    {
                        NapomenaBox.Visibility = Visibility.Visible;
                        NapomenaBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                        NapomenaBox.Text = "Unesite jezik i nivo kursa za prikaz grupa.";
                    });
                return;
            }

            if (string.IsNullOrEmpty(textBox_Jezik.Text))
            {
                if (Dispatcher != null)
                    await Dispatcher?.InvokeAsync(() =>
                    {
                        NapomenaBox.Visibility = Visibility.Visible;
                        NapomenaBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                        NapomenaBox.Text = "Unesite jezik za prikaz grupa.";
                    });
                return;
            } else if (string.IsNullOrEmpty(textBox_NivoKursa.Text))
            {
                if (Dispatcher != null)
                    await Dispatcher?.InvokeAsync(() =>
                    {
                        NapomenaBox.Visibility = Visibility.Visible;
                        NapomenaBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                        NapomenaBox.Text = "Unesite nivo kursa za prikaz grupa.";
                    });
                return;
            }

            using (var ersteModel = new ErsteModel())
            {
                var grupe = (from g in ersteModel.grupe join k in ersteModel.kursevi on g.KursId equals k.Id
                             join j in ersteModel.jezici on k.JezikId equals j.Id
                             where g.BrojClanova > 3 && k.DatumDo.CompareTo(DateTime.Now)>0
                             && j.Naziv.Equals(textBox_Jezik.Text) && k.Nivo.Equals(textBox_NivoKursa.Text)
                             select g).ToList();
                foreach(var grupa in grupe)
                {
                    GrupeDataGrid.Items.Add(grupa);
                }

            }
        }

        private async void Apply_Btn_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_Ime.Text) || string.IsNullOrEmpty(textBox_Prezime.Text)
                || string.IsNullOrEmpty(textBox_Email.Text) || string.IsNullOrEmpty(textBox_BrojTelefona.Text)
                    || string.IsNullOrEmpty(textBox_Jezik.Text) || string.IsNullOrWhiteSpace(textBox_NivoKursa.Text))
            {
                if (Dispatcher != null)
                    await Dispatcher?.InvokeAsync(() =>
                    {
                        NapomenaBox.Visibility = Visibility.Visible;
                        NapomenaBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                        NapomenaBox.Text = "Sva polja za unos moraju biti popunjena .";
                    });
                return;
            }

            if (!GrupeDataGrid.Items.IsEmpty && GrupeDataGrid.SelectedItems == null || GrupeDataGrid.SelectedItems.Count == 0)
            {
                if (Dispatcher != null)
                    await Dispatcher?.InvokeAsync(() =>
                    {
                        NapomenaBox.Visibility = Visibility.Visible;
                        NapomenaBox.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                        NapomenaBox.Text = "Izaberite grupu iz tabele.";
                    });
                return;
            }

            using (var ersteModel = new ErsteModel())
            {
                osoba o = new osoba();
                o.Ime = textBox_Ime.Text;
                o.Prezime = textBox_Prezime.Text;
                o.BrojTelefona = textBox_BrojTelefona.Text;
                o.Email = textBox_Email.Text;   
                polaznik p = new polaznik();
                p.osoba = o;

                if (!GrupeDataGrid.Items.IsEmpty)
                {
                    grupa g = (grupa)GrupeDataGrid.SelectedItem;
                    p.grupe.Add(g);
                    g.polaznici.Add(p);
                }
                else
                {
                    polaznik_na_cekanju pnc = new polaznik_na_cekanju();
                    pnc.polaznik = p;
                    pnc.Id = p.Id;

                    var kursLista = from k in ersteModel.kursevi
                                    join j in ersteModel.jezici on k.JezikId equals j.Id
                                    where k.Nivo.Equals(textBox_NivoKursa.Text) && j.Naziv.Equals(textBox_Jezik.Text)
                                    select k;
                    kurs kurs = kursLista.First();
                    kurs.polaznici_na_cekanju.Add(pnc);
                    pnc.kursevi.Add(kurs);
                }

                ersteModel.SaveChanges();

            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DataGrid_OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
        
        }
    }
}
