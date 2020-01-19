using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using System.Security.Cryptography;
using System.Windows.Automation.Peers;
using System.Windows.Interop;
using System.Windows.Automation.Provider;

namespace Erste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : NavigationWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            usernameBox.Focus();

            //za testiranje
            //using (ErsteModel context = new ErsteModel())
            //{
            //    List<administrator> administrators = new List<administrator>();
            //    List<sluzbenik> employees = new List<sluzbenik>();
            //    List<osoba> users = new List<osoba>();

            //    HashGenerator hashGenerator = new HashGenerator();
            //    osoba user = new osoba
            //    {
            //        Id = 1,
            //        Ime = "admin",
            //        Prezime = "admin",
            //        BrojTelefona = "2345324",
            //        Email = "admin@gmail.com"
            //    };
            //    users.Add(user);
            //    administrator admin = new administrator
            //    {
            //        Id = 1,
            //        KorisnickoIme = "admin",
            //        LozinkaHash = hashGenerator.ComputeHash("admin")
            //    };
            //    administrators.Add(admin);

            //    osoba user2 = new osoba
            //    {
            //        Id = 2,
            //        Ime = "sluzbenik",
            //        Prezime = "sluzbenik",
            //        BrojTelefona = "2332131232124",
            //        Email = "marko@gmail.com"
            //    };
            //    users.Add(user2);
            //    sluzbenik employee = new sluzbenik
            //    {
            //        Id = 2,
            //        KorisnickoIme = "sluzbenik",
            //        LozinkaHash = hashGenerator.ComputeHash("sluzbenik")
            //    };
            //    employees.Add(employee);

            //    context.osobe.AddOrUpdate(user);
            //    context.administratori.AddOrUpdate(admin);
            //    context.osobe.AddOrUpdate(user2);
            //    context.sluzbenici.AddOrUpdate(employee);
            //    context.SaveChanges();

            //}
        }

        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameBox.Text, password = passwordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Polja za korisničko ime i lozinku moraju biti popunjena.","Greška");
                return;
            }

            HashGenerator hashGenerator= new HashGenerator();
            string hash = hashGenerator.ComputeHash(password);

            //slanje podataka na server i login
            using (ErsteModel context = new ErsteModel())
            {
                var administators = (from a in context.administratori where a.KorisnickoIme.Equals(username) select a).ToList();
                if (administators.Count!=0 && hash.Equals(administators[0].LozinkaHash))
                {
                    AdminMainWindow window = new AdminMainWindow();
                    window.Show();
                    Close();
                    return;
                }

                var employees = (from a in context.sluzbenici where a.KorisnickoIme.Equals(username) select a).ToList();
                if (employees.Count!=0 && hash.Equals(employees[0].LozinkaHash))
                {
                    SluzbenikMainWindow window = new SluzbenikMainWindow();
                    window.Owner = null;
                    window.Show();
                    Hide();
                    return;
                }
                
            }

            MessageBox.Show("Korisničko ime ili lozinka su pogrešni.", "Greška");
            return;

        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Prijava_Click(sender, e);
        }
    }
}
