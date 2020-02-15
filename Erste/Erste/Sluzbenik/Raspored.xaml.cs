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
using Erste.Util;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for Raspored.xaml
    /// </summary>
    public partial class Raspored : UserControl
    {
        public Raspored()
        {
            InitializeComponent();
        }

        public void Refresh() => Load_Data();

        private void Load_Data()
        {
            try
            {
                using (var ersteModel = new ErsteModel())
                {

                    List<ListView> kolone = new List<ListView>();
                    kolone.Add(listViewMonday);
                    kolone.Add(listViewTuesday);
                    kolone.Add(listViewWednesday);
                    kolone.Add(listViewThursday);
                    kolone.Add(listViewFriday);
                    kolone.Add(listViewSaturday);
                    kolone.Add(listViewSunday);

                    (from kurs in ersteModel.kursevi
                     join jezik in ersteModel.jezici on kurs.JezikId equals jezik.Id
                     select kurs).ToList();

                    List<TimetableItem> items = (from termin in ersteModel.termini
                                 join grupa in ersteModel.grupe on termin.GrupaId equals grupa.Id
                                 join kurs in ersteModel.kursevi on grupa.KursId equals kurs.Id
                                 join jezik in ersteModel.jezici on kurs.JezikId equals jezik.Id
                                 select new TimetableItem
                                 {
                                     vrijemeOd = termin.Od,
                                     vrijemeDo = termin.Do,
                                     jezik = jezik.Naziv,
                                     nivo = kurs.Nivo,
                                     dan = termin.Dan
                                 }).ToList();

                    List<List<TimetableItem>> terminiPoDanima = new List<List<TimetableItem>>();
                    for (int i = 0; i < 7; ++i)
                        terminiPoDanima.Add(new List<TimetableItem>());

                    foreach (var item in items)
                    {
                        if ("Ponedjeljak".Equals(item.dan))
                            terminiPoDanima.ElementAt(0).Add(item);
                        else if("Utorak".Equals(item.dan))
                            terminiPoDanima.ElementAt(1).Add(item);
                        else if ("Srijeda".Equals(item.dan))
                            terminiPoDanima.ElementAt(2).Add(item);
                        else if ("Cetvrtak".Equals(item.dan))
                            terminiPoDanima.ElementAt(3).Add(item);
                        else if ("Petak".Equals(item.dan))
                            terminiPoDanima.ElementAt(4).Add(item);
                        else if ("Subota".Equals(item.dan))
                            terminiPoDanima.ElementAt(5).Add(item);
                        else
                            terminiPoDanima.ElementAt(6).Add(item);
                    }

                    for (int i = 0; i < 7; ++i)
                        kolone.ElementAt(i).ItemsSource = terminiPoDanima.ElementAt(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Exception: " + ex.ToString());
            }
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*Activity activity = ((FrameworkElement)e.OriginalSource).DataContext as Activity;
            ActivityDetails.OpenedActivity = activity;

            if (activity != null)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Window activityDetails = new ActivityDetails();
                    activityDetails.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                    activityDetails.Height = 343;
                    activityDetails.MinHeight = 343;
                    activityDetails.Width = 593;
                    activityDetails.MinWidth = 593;

                    (activityDetails as ActivityDetails).titleLabel.Content = activity.Title;
                    (activityDetails as ActivityDetails).startTimeLabel.Content += "    " + activity.TimeFrom.ToShortTimeString() + "h";
                    (activityDetails as ActivityDetails).endTimeLabel.Content += "    " + activity.TimeTo.ToShortTimeString() + "h";
                    (activityDetails as ActivityDetails).descriptionBox.Text = activity.Description;
                    (activityDetails as ActivityDetails).dateLabel.Content += "    " + activity.Date.ToShortDateString();
                    activityDetails.ShowDialog();
                });
            }*/
        }
    }
}
