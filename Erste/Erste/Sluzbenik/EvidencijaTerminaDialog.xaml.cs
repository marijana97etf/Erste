using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Erste.Model;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for EvidencijaTerminaDialog.xaml
    /// </summary>
    public partial class EvidencijaTerminaDialog : Window
    {
        private readonly Action refresh;

        public EvidencijaTerminaDialog()
        {
            InitializeComponent();
        }

        public EvidencijaTerminaDialog(Action refresh) : this()
        {
            this.refresh = refresh;
        }

        private async void Button1Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan @od = new TimeSpan();
                TimeSpan @do = new TimeSpan();
                string dan = "";
                if (Dispatcher != null)
                    await Dispatcher.InvokeAsync(() =>
                    {
                        if (TimePickerOd.Value == null || TimePickerDo.Value == null || DanCombo.SelectedValue == null) return;
                        dan = DanCombo.Text;
                        @od = TimePickerOd.Value.Value.TimeOfDay;
                        @do = TimePickerDo.Value.Value.TimeOfDay;
                    });

                using (ErsteModel ersteModel = new ErsteModel())
                {
                    ersteModel.termini.Add(new termin()
                    {
                        Dan = dan,
                        Od = @od,
                        Do = @do,
                        grupa = null,
                        GrupaId = null
                    });
                    await ersteModel.SaveChangesAsync();
                }
                MessageBox.Show("Uspješno ste dodali novi termin.");
            }
            catch (IOException ioException)
            {
                MessageBox.Show(ioException.StackTrace);
            }

            refresh();
            if (Dispatcher != null)
                await Dispatcher.InvokeAsync(Close);
        }

        private void Button_Otkazi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
