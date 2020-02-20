using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Erste.Sluzbenik
{
    /// <summary>
    /// Interaction logic for PregledGrupe.xaml
    /// </summary>
    public partial class PregledGrupe : Window
    {
        private grupa grupa;
        private bool flag = false;

        public PregledGrupe()
        {
            InitializeComponent();
        }

        public PregledGrupe(grupa grupa) : this()
        {
            this.grupa = grupa;
            Init();
            flag = true;
        }

        private void Init()
        {
            using (ErsteModel ersteModel = new ErsteModel())
            {
                BrojClanovaBox.Text = $"{ersteModel.polaznici.Count(e => e.grupe.Any(g => g.Id == grupa.Id))}";
                kurs kurs = ersteModel.kursevi.Find(grupa.Id);
                if (!(kurs is null))
                {
                    NazivGrupeCombo.ItemsSource = null;
                    NazivGrupeCombo.Items.Clear();
                    foreach (var naziv in ersteModel.grupe.Select(e => e.Naziv).ToList())
                    {
                        NazivGrupeCombo.Items.Add(naziv);
                    }
                    NazivGrupeCombo.Text = $"{grupa.Naziv}";
                    NivoKursa.Text = $"{kurs.Nivo}";
                    jezik jezik = ersteModel.jezici.Find(kurs.JezikId);
                    if (!(jezik is null))
                        jezikKursa.Text = $"{jezik.Naziv}";
                }
                PopuniTermine(ersteModel);
                PopuniPolaznike(ersteModel);
                PopuniProfesore(ersteModel);
            }
        }

        private void PopuniProfesore(ErsteModel ersteModel)
        {
            var list = ersteModel.profesori
                .Where(e => e.grupe.Any(g => g.Id == grupa.Id))
                .ToList();
            list.Sort((a, b) =>
            {
                int res;
                if ((res = string.Compare(a.osoba.Ime, b.osoba.Ime, StringComparison.Ordinal)) != 0) return res;
                return string.Compare(a.osoba.Prezime, b.osoba.Prezime, StringComparison.Ordinal);
            });
            ProfesoriTable.Items.Clear();
            ProfesoriTable.ItemsSource = null;
            foreach (var profesor in list)
            {
                if (profesor.osoba != null)
                {
                    ProfesoriTable.Items.Add(profesor);
                }
            }
        }

        private void PopuniPolaznike(ErsteModel ersteModel)
        {
            var list = ersteModel.polaznici
                .Where(e => e.grupe.Any(g => g.Id == grupa.Id))
                .ToList();
            list.Sort((a, b) =>
            {
                int res;
                if ((res = string.Compare(a.osoba.Ime, b.osoba.Ime, StringComparison.Ordinal)) != 0) return res;
                return string.Compare(a.osoba.Prezime, b.osoba.Prezime, StringComparison.Ordinal);
            });

            PolazniciTable.Items.Clear();
            PolazniciTable.ItemsSource = null;
            foreach (var polaznik in list)
            {
                if (polaznik.osoba != null)
                {
                    PolazniciTable.Items.Add(polaznik);
                }
            }
        }

        private void PopuniTermine(ErsteModel ersteModel)
        {
            var list = ersteModel.termini
                .Where(e => e.GrupaId == grupa.Id)
                .ToList();

            list.Sort((a, b) =>
            {
                int first = GetRedniBroj(a.Dan);
                int second = GetRedniBroj(b.Dan);
                int res;

                if ((res = first.CompareTo(second)) != 0) return res;

                if (a.Od < b.Od)
                {
                    return -1;
                }

                return 1;
            });
            TerminiTable.Items.Clear();
            TerminiTable.ItemsSource = null;
            foreach (var termin in list)
            {
                TerminiTable.Items.Add(termin);
            }
        }

        private int GetRedniBroj(string dan)
        {
            switch (dan)
            {
                case "Ponedjeljak":
                    return 1;
                case "Utorak":
                    return 2;
                case "Srijeda":
                    return 3;
                case "Cetvrtak":
                case "Četvrtak":
                    return 4;
                case "Petak":
                    return 5;
                case "Subota":
                    return 6;
                default:
                    return 7;
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PromjenaGrupe_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (flag)
            {
                using (ErsteModel ersteModel = new ErsteModel())
                {
                    string text = (e.AddedItems[0] as ComboBoxItem)?.Content as string;
                    grupa = ersteModel.grupe.First(g => g.Naziv == text);
                }
                Init();
            }
        }
    }
}
