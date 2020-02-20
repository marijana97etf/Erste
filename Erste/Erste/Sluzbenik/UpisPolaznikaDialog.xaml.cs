using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            loadChb();
        }

        private void loadChb()
        {

            using (var ersteModel = new ErsteModel())
            {
                var jezici = (from j in ersteModel.jezici select j).Select(j => j.Naziv);
                var nivoi = (from k in ersteModel.kursevi select k).GroupBy(k => k.Id).Select(k => k.FirstOrDefault()).Select(k => k.Nivo);

               foreach(string naziv in jezici)
                    chb_Jezik.Items.Add(naziv);
               foreach( string nivo in nivoi)
                    chb_Nivo.Items.Add(nivo);
            }
        }

        private void btn_PrikaziGrupe_Click(object sender, RoutedEventArgs e)
        {
            string odabraniJezik = (string)chb_Jezik.SelectedItem;
            string odabraniNivo = (string)chb_Nivo.SelectedItem;

            if (string.IsNullOrEmpty(odabraniJezik) && string.IsNullOrEmpty(odabraniNivo))
            {
                MessageBox.Show("Odaberite jezik i nivo kursa za prikaz grupa.");
                return;
            }

            if (string.IsNullOrEmpty(odabraniJezik))
            {
                MessageBox.Show("Odaberite jezik za prikaz grupa.");
                return;

            }else if (string.IsNullOrEmpty(odabraniNivo))
            {
                MessageBox.Show("Odaberite nivo kursa za prikaz grupa.");
                return;
            }

            using (var ersteModel = new ErsteModel())
            {

                var kursGrupa = (from g in ersteModel.grupe join k in ersteModel.kursevi on g.KursId equals k.Id
                             join j in ersteModel.jezici on k.JezikId equals j.Id
                             where g.BrojClanova>3 && k.DatumDo.CompareTo(DateTime.Now) > 0
                             && j.Naziv.Equals(odabraniJezik) && k.Nivo.Equals(odabraniNivo)
                             select new GrupaKursZapis {
                                 Grupa = g,
                                 Kurs = k,
                                 Jezik = j 
                             }).ToList();
                foreach(var zapis in kursGrupa)
                {
                    if(!GrupeDataGrid.Items.Contains(zapis))
                        GrupeDataGrid.Items.Add(zapis);
                }

            }
        }

        private  void Apply_Btn_Click(object sender, RoutedEventArgs e)
        {
            string odabraniJezik = (string)chb_Jezik.SelectedItem;
            string odabraniNivo = (string)chb_Nivo.SelectedItem;

            if (string.IsNullOrEmpty(textBox_Ime.Text) || string.IsNullOrEmpty(textBox_Prezime.Text)
                || string.IsNullOrEmpty(textBox_Email.Text) || string.IsNullOrEmpty(textBox_BrojTelefona.Text)
                    || string.IsNullOrEmpty(odabraniJezik) || string.IsNullOrWhiteSpace(odabraniNivo))
            {
                MessageBox.Show("Sva polja za unos moraju biti popunjena .");
                return;
            }

            if (!GrupeDataGrid.Items.IsEmpty && (GrupeDataGrid.SelectedItems == null || GrupeDataGrid.SelectedItems.Count == 0))
            {
                MessageBox.Show("Izaberite grupu iz tabele.");
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
                    GrupaKursZapis zapis = (GrupaKursZapis)GrupeDataGrid.SelectedItem;
                    grupa zapisGrupa = (from g in ersteModel.grupe where g.Id == zapis.Grupa.Id select g).First();
                    p.grupe.Add(zapisGrupa);
                    zapisGrupa.polaznici.Add(p);

                    MessageBox.Show("Uspjeno dodan polaznik.");
                }
                else
                {
                    polaznik_na_cekanju pnc = new polaznik_na_cekanju();
                    pnc.polaznik = p;
                    pnc.Id = p.Id;

                    // RAZMISLI O OVOME, KAKO MAPIRATI POLAZNIKE PO KURSEVIMA RAZLICITIH DATUMA
                    var kursLista = from k in ersteModel.kursevi
                                    join j in ersteModel.jezici on k.JezikId equals j.Id
                                    where k.Nivo.Equals(odabraniNivo) && j.Naziv.Equals(odabraniJezik)
                                        && k.DatumDo.CompareTo(DateTime.Now)>0
                                    orderby k.DatumDo descending
                                    select k;

                    kurs kurs = kursLista.First();
                    IEnumerable<polaznik_na_cekanju> polazniciNaCekanjuZaTrazeniKurs = kursLista.SelectMany(k => k.polaznici_na_cekanju);
                    if (polazniciNaCekanjuZaTrazeniKurs.Count() >= 2)
                    {
                        //nova grupa
                        grupa g = new grupa
                        {
                            KursId = kurs.Id,
                            BrojClanova = 0,
                        };

                        //unos podataka o novoj grupi
                        UpisTerminaGrupe upisTermina = new UpisTerminaGrupe(g);
                        upisTermina.ShowDialog();
                        if (g.Naziv == null)
                        {
                            Task.Run(() => MessageBox.Show("Unesite naziv grupe.") );
                            upisTermina = new UpisTerminaGrupe(g);
                            upisTermina.ShowDialog();
                        }

                        //dobijanje ref na polaznike i polaznika na cekanju
                        List<polaznik> polazniciNoveGrupe = new List<polaznik>();
                        polazniciNoveGrupe.Add(p);
                        foreach (polaznik_na_cekanju p_na_c in polazniciNaCekanjuZaTrazeniKurs)
                        {
                            polazniciNoveGrupe.Add(p_na_c.polaznik);
                        }
                        
                        //brisanje korisnika na cekanju i veza s kursevima
                        foreach (polaznik_na_cekanju p_na_c in polazniciNaCekanjuZaTrazeniKurs)
                        {
                            kurs kurs_za_p_na_c = p_na_c.kursevi.First(k => k.Nivo.Equals(odabraniNivo) &&
                                k.jezik.Naziv.Equals(odabraniJezik));
                            kurs_za_p_na_c.polaznici_na_cekanju.Remove(p_na_c);
                            p_na_c.kursevi.Remove(kurs_za_p_na_c);
                            p_na_c.polaznik.polaznik_na_cekanju = null;
                        }

                        //dodavanje polaznika u grupu
                        foreach (polaznik p_u_g in polazniciNoveGrupe)
                        {
                            p_u_g.grupe.Add(g);
                            g.polaznici.Add(p_u_g);
                        }

                        //dodavanje grupe u tabelu
                        ersteModel.grupe.Add(g);

                        MessageBox.Show("Polaznik uspjesno ubacen u grupu.Polaznici na cekanju za odabrani kurs i nivo su takodje uspjesno ubaceni u grupu.");

                    }
                    else
                    {
                        kurs.polaznici_na_cekanju.Add(pnc);
                        pnc.kursevi.Add(kurs);

                        MessageBox.Show("Polaznik dodat na listu cekanja za odabrani kurs i jezik.");
                    }   
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

    public class GrupaKursZapis {

        public grupa Grupa { get; set; }
        public kurs Kurs { get; set; }
        public jezik Jezik { get; set; }


    }
}
