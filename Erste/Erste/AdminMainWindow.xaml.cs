using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Erste.Administrator;

namespace Erste
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {      
        public AdminMainWindow()
        {           
            InitializeComponent();
            frame.Navigated += frame_Navigated;
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
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
            frame.Content = new NaloziSluzbenika();
        }

        private void Button_EvidencijaProfesora(object sender, RoutedEventArgs e)
        {
            frame.Content = new EvidencijaProfesora();
        }

        private void Button_EvidencijaKurseva(object sender, RoutedEventArgs e)
        {
            frame.Content = new EvidencijaKurseva();
        }

        void frame_Navigated(object sender, NavigationEventArgs e)
        {
            frame.NavigationService.RemoveBackEntry();
        }
    }
}
