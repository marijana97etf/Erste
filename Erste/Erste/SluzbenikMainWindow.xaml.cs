using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Erste
{
    /// <summary>
    /// Interaction logic for SluzbenikMainWindow.xaml
    /// </summary>
    public partial class SluzbenikMainWindow : Window
    {      
        public SluzbenikMainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }  
    }
}
