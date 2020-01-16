using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Erste.Sluzbenik;

namespace Erste
{
    /// <summary>
    /// Interaction logic for SluzbenikMainWindow.xaml
    /// </summary>
    public partial class SluzbenikMainWindow : NavigationWindow
    {
        private Kandidati _kandidati;
        public SluzbenikMainWindow()
        {
            InitializeComponent();
        }


        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LogOff_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();
            Close();
        }

        private static int[] _menuIndex = { 0, 0, 0 };
        private object _locker = new object();

        private async void Upis_Click(object sender, RoutedEventArgs e)
        {
            await NapraviAnimaciju(UpisPanel, 0, TimeSpan.FromSeconds(1));
        }

        private async void Raspored_Click(object sender, RoutedEventArgs e)
        {
            await NapraviAnimaciju(RasporedPanel, 1, TimeSpan.FromSeconds(1));
        }

        private async void Pregled_Click(object sender, RoutedEventArgs e)
        {
            if (_kandidati == null)
            {
                GridZaPrikaz.Children.Add(_kandidati = new Kandidati());
            }
            await NapraviAnimaciju(PregledPanel, 2, TimeSpan.FromSeconds(1));
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(0);
        }

        #region Animacija

        private async Task NapraviAnimaciju(StackPanel stackPanel, int index, TimeSpan animationDurance)
        {
            lock (_locker)
            {
                pregledButton.IsEnabled = false;
                upisButton.IsEnabled = false;
                rasporedButton.IsEnabled = false;
                if (_menuIndex[index] % 2 == 0)
                {
                    AnimationTimeline expand = new DoubleAnimation(0, stackPanel.ActualHeight, animationDurance);
                    AnimationTimeline shrink = new DoubleAnimation(label.ActualHeight, label.ActualHeight - stackPanel.ActualHeight,
                        animationDurance);
                    AnimationTimeline timeline = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(1000));

                    Storyboard.SetTarget(expand, stackPanel);
                    Storyboard.SetTargetProperty(expand, new PropertyPath(Rectangle.HeightProperty));

                    Storyboard.SetTarget(shrink, label);
                    Storyboard.SetTargetProperty(shrink, new PropertyPath(Rectangle.HeightProperty));

                    Storyboard.SetTarget(timeline, _kandidati);
                    Storyboard.SetTargetProperty(timeline, new PropertyPath(DataGrid.OpacityProperty));

                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(expand);
                    storyboard.Children.Add(shrink);
                    storyboard.Children.Add(timeline);
                    storyboard.Begin(this);
                }
                else
                {
                    AnimationTimeline timeline = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
                    AnimationTimeline expand = new DoubleAnimation(stackPanel.ActualHeight, 0, animationDurance);
                    AnimationTimeline shrink = new DoubleAnimation(label.ActualHeight, label.ActualHeight + stackPanel.ActualHeight,
                        animationDurance);

                    Storyboard.SetTarget(expand, stackPanel);
                    Storyboard.SetTargetProperty(expand, new PropertyPath(Rectangle.HeightProperty));

                    Storyboard.SetTarget(shrink, label);
                    Storyboard.SetTargetProperty(shrink, new PropertyPath(Rectangle.HeightProperty));

                    Storyboard.SetTarget(timeline, _kandidati);
                    Storyboard.SetTargetProperty(timeline, new PropertyPath(DataGrid.OpacityProperty));

                    Storyboard storyboard = new Storyboard();
                    storyboard.Children.Add(expand);
                    storyboard.Children.Add(shrink);
                    storyboard.Children.Add(timeline);
                    storyboard.Begin(this);
                }

                _menuIndex[index]++;

            }
            await Task.Run(async () =>
            {
                await Task.Delay(animationDurance);
                Dispatcher?.Invoke(() =>
                {
                    pregledButton.IsEnabled = true;
                    upisButton.IsEnabled = true;
                    rasporedButton.IsEnabled = true;
                });
            });
        }

        #endregion

        #region Keep aspect ratio

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            if (PresentationSource.FromVisual(this) is HwndSource source)
            {
                source.AddHook(WinProc);
            }
        }

        private const Int32 WmExitsizemove = 0x0232;
        private bool _firstTime = true;
        private IntPtr WinProc(IntPtr hwnd, Int32 msg, IntPtr wParam, IntPtr lParam, ref Boolean handled)
        {
            IntPtr result = IntPtr.Zero;
            switch (msg)
            {
                case WmExitsizemove:
                {
                    if (_firstTime)
                    {
                        Viewbox.Height = 517;
                        Viewbox.Width = 861;
                        Height = 517;
                        Width = 861;
                        _firstTime = false;
                    }
                    else
                    {
                        Viewbox.Height = double.NaN;
                        Viewbox.Width = double.NaN;
                    }
                    Viewbox.Height = Viewbox.Width * 517.0/861;
                    Height = Width * 517.0 / 861;
                }
                    break;
            }

            return result;
        }

        private void LoginWindow_OnLoadCompleted(object sender, NavigationEventArgs e)
        {
            Viewbox.Height = 517;
            Viewbox.Width = 861;
            Height = 517;
            Width = 861;
        }

        #endregion
    }
}
