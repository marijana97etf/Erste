using Erste.Util;
using System;
using System.Collections.Generic;
using System.IO;
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
using Erste.Model;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for PregledTermina.xaml
    /// </summary>
    public partial class PregledTermina : Window
    {
        private TimetableItem item;

        public PregledTermina()
        {
            InitializeComponent();
        }

        public PregledTermina(TimetableItem item) : this()
        {
            this.item = item;
            Init();
        }

        private void Init()
        {
            DanCombo.Text = item.dan;
            TimePickerOd.Value = new DateTime(2020, 01, 01, 0,0,0) + item.vrijemeOd;
            TimePickerDo.Value = new DateTime(2020, 01, 01,0,0,0) + item.vrijemeDo;
            try
            {
                using (ErsteModel ersteModel = new ErsteModel())
                {
                    foreach (var grupaId in ersteModel.grupe.Select(e => e.Id).ToList())
                    {
                        GrupaCombo.Items.Add(grupaId);
                    }
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("Greška");
            }
            if (item.GrupaId.HasValue) GrupaCombo.Text = $"{item.GrupaId}";
        }

        private async void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            //using (ErsteModel ersteModel = new ErsteModel())
            //{
            //    termin termin = await ersteModel.termini.FindAsync(item.termin.Id);
            //    if (termin != null)
            //    {
            //        termin.Dan = DanCombo.Text;
            //        termin.GrupaId = ersteModel.grupe.Where(e => e.)
            //    }
            //}
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DodavanjeGrupe_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void PregledGrupe_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            int idGrupe = 0;
            grupa grupa;
            if (Dispatcher != null)
                await Dispatcher.InvokeAsync(() =>
                {
                    idGrupe = int.Parse(GrupaCombo.SelectedItem.ToString());
                });
            using (ErsteModel ersteModel = new ErsteModel())
            {
                grupa = await ersteModel.grupe.FindAsync(idGrupe);
            }

            if (grupa != null && Dispatcher != null)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    PregledGrupe pregledGrupe = new PregledGrupe(grupa);
                    pregledGrupe.ShowDialog();
                });
            }
            else
            {
                if (Dispatcher != null)
                    await Dispatcher.InvokeAsync(() =>
                    {
                        MessageBox.Show("Odaberite grupu, pa je onda pregledajte.");
                    });
            }
        }
    }
}
