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
using System.Security.Cryptography;

namespace Erste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            //za testiranje
            //using (ErsteModel context = new ErsteModel())
            //{
            //    List<administrator> administrators = new List<administrator>();
            //    List<sluzbenik> employees = new List<sluzbenik>();
            //    List<osoba> users = new List<osoba>();

            //    HashGenerator hashGenerator = new HashGenerator();
            //    osoba user = new osoba();
            //    user.Id = 1;
            //    user.Ime = "nikola";
            //    user.Prezime = "nikolic";
            //    user.BrojTelefona = "2345324";
            //    user.Email = "nikola@gmail.com";
            //    users.Add(user);
            //    administrator admin = new administrator();
            //    admin.Id = 1;
            //    admin.KorisnickoIme = "nikola.nikolic";
            //    admin.LozinkaHash = hashGenerator.ComputeHash("lozinka1");
            //    administrators.Add(admin);

            //    osoba user2 = new osoba();
            //    user2.Id = 2;
            //    user2.Ime = "marko";
            //    user2.Prezime = "markovic";
            //    user2.BrojTelefona = "2332131232124";
            //    user2.Email = "marko@gmail.com";
            //    users.Add(user2);
            //    sluzbenik employee = new sluzbenik();
            //    employee.Id = 2;
            //    employee.KorisnickoIme = "marko.markovic";
            //    employee.LozinkaHash = hashGenerator.ComputeHash("lozinka2");
            //    employees.Add(employee);

            //    context.osobe.Add(user);
            //    context.administratori.Add(admin);
            //    context.osobe.Add(user2);
            //    context.sluzbenici.Add(employee);
            //    context.SaveChanges();

            //}
        }


        private void Button_Click(object sender, RoutedEventArgs e)
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
                    window.Show();
                    Close();
                    return;
                }
                
            }

            MessageBox.Show("Korisničko ime ili lozinka su pogrešni.", "Greška");
            return;

        }


        
    }
}
