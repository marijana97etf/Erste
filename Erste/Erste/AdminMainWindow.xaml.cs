using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Erste.Administrator;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Erste
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        //private object _locker = new object();
        //private static int[] _menuIndex = { 0, 0, 0 };
        private NaloziSluzbenika naloziSluzbenika;
        private EvidencijaProfesora evidencijaProfesora;
        private EvidencijaKurseva evidencijaKurseva;

        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        private void Button_NaloziSluzbenika(object sender, RoutedEventArgs e)
        {
            GridZaPrikaz.Children.Add(naloziSluzbenika = new NaloziSluzbenika());
            naloziSluzbenika.Refresh();
        }

        private void Button_DodajSluzbenika(object sender, RoutedEventArgs e)
        {
            NalogSluzbenikaDialog nalogSluzbenikaDialog = new NalogSluzbenikaDialog(null);
            nalogSluzbenikaDialog.ShowDialog();
        }

        private void Button_EvidencijaProfesora(object sender, RoutedEventArgs e)
        {
            GridZaPrikaz.Children.Add(evidencijaProfesora = new EvidencijaProfesora());
            evidencijaProfesora.Refresh();
        }

        private void Button_DodajProfesora(object sender, RoutedEventArgs e)
        {
            EvidencijaProfesoraDialog evidencijaProfesoraDialog = new EvidencijaProfesoraDialog(null);
            evidencijaProfesoraDialog.ShowDialog();
        }

        private void Button_EvidencijaKurseva(object sender, RoutedEventArgs e)
        {
            GridZaPrikaz.Children.Add(evidencijaKurseva = new EvidencijaKurseva());
            evidencijaKurseva.Refresh();
        }

        private void Button_DodajKurs(object sender, RoutedEventArgs e)
        {
            EvidencijaKursaDialog evidencijaKursaDialog = new EvidencijaKursaDialog(null);
            evidencijaKursaDialog.ShowDialog();
        }

        /*private async Task NapraviAnimaciju(StackPanel stackPanel, int index, Button button, TimeSpan animationDurance)
        {
            lock (_locker)
            {
                button.IsEnabled = false;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                if (_menuIndex[index] % 2 == 0)
                {
                    SolidColorBrush solidColor = new SolidColorBrush(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A));
                    button.Background = solidColor;
                    RegisterName("SolidColor", solidColor);

                    AnimationTimeline expand = new DoubleAnimation(0, stackPanel.ActualHeight, animationDurance);

                    AnimationTimeline opacity = new DoubleAnimation(0, 1, animationDurance);
                    AnimationTimeline colorChange = new ColorAnimation(Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A), Colors.DarkRed, animationDurance);

                    Storyboard.SetTarget(expand, stackPanel);
                    Storyboard.SetTargetProperty(expand, new PropertyPath(Rectangle.HeightProperty));

                    DataGrid dataGrid;
                    if (index == 0)
                        dataGrid = naloziSluzbenika.DataGrid;
                    else if (index == 1)
                        dataGrid = evidencijaProfesora.DataGrid;
                    else
                        dataGrid = evidencijaKurseva.DataGrid;
                    Storyboard.SetTarget(opacity, dataGrid);
                    Storyboard.SetTargetProperty(opacity, new PropertyPath(OpacityProperty));

                    Storyboard.SetTargetName(colorChange, "SolidColor");
                    Storyboard.SetTargetProperty(colorChange, new PropertyPath(SolidColorBrush.ColorProperty));

                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(expand);

                    if (index == 0)
                        naloziSluzbenika.Refresh();
                    else if (index == 1)
                        evidencijaProfesora.Refresh();
                    else
                        evidencijaKurseva.Refresh();
                    storyboard.Children.Add(opacity);
                    storyboard.Children.Add(colorChange);
                    storyboard.Begin(this);
                }
                else
                {
                    SolidColorBrush solidColor = new SolidColorBrush(Colors.DarkRed);
                    button.Background = solidColor;
                    RegisterName("SolidColor", solidColor);

                    AnimationTimeline expand = new DoubleAnimation(stackPanel.ActualHeight, 0, animationDurance);
                    AnimationTimeline colorChange = new ColorAnimation(Colors.DarkRed, Color.FromArgb(0xFF, 0xEF, 0x3D, 0x4A), animationDurance);
                    AnimationTimeline opacity = new DoubleAnimation(1, 0, animationDurance);

                    Storyboard.SetTarget(expand, stackPanel);
                    Storyboard.SetTargetProperty(expand, new PropertyPath(Rectangle.HeightProperty));

                    Storyboard.SetTargetName(colorChange, "SolidColor");
                    Storyboard.SetTargetProperty(colorChange, new PropertyPath(SolidColorBrush.ColorProperty));

                    DataGrid dataGrid;
                    if (index == 0)
                        dataGrid = naloziSluzbenika.DataGrid;
                    else if (index == 1)
                        dataGrid = evidencijaProfesora.DataGrid;
                    else
                        dataGrid = evidencijaKurseva.DataGrid;
                    Storyboard.SetTarget(opacity, dataGrid);
                    Storyboard.SetTargetProperty(opacity, new PropertyPath(OpacityProperty));

                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(expand);

                    storyboard.Children.Add(opacity);
                    storyboard.Children.Add(colorChange);
                    storyboard.Begin(this);
                }

                UnregisterName("SolidColor");
                _menuIndex[index]++;

            }
            await Task.Run(async () =>
            {
                await Task.Delay(animationDurance);
                Dispatcher?.Invoke(() =>
                {
                    button.IsEnabled = true;
                    button1.IsEnabled = true;
                    button2.IsEnabled = true;
                });
            });
        }*/
    }
}
