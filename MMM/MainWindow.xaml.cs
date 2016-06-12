using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace MMM

{

    public partial class MainWindow : Window
    {
        public ObservableCollection<Populacja> PopulacjaList { get; set; }

        public Settings settings;

        private Obliczenia obliczenia = new Obliczenia();


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            PopulacjaList = new ObservableCollection<Populacja>();
            this.WilkiComboBox.ItemsSource = Enum.GetValues(typeof(ŻarłocznościWilków));
            this.WilkiComboBox.SelectedIndex = 0;

            this.LisyComboBox.ItemsSource = Enum.GetValues(typeof(ŻarłocznościLisów));
            this.LisyComboBox.SelectedIndex = 0;

            this.settings = new Settings();
            this.ParyPłodneTextBox.DataContext = settings;
            this.ParyNiePłodneTextBox.DataContext = settings;
            this.WilkiTextBox.DataContext = settings;
            this.LisyTextBox.DataContext = settings;
            this.LiczbaMiesiecyTextBox.DataContext = settings;

        }

        private void MinusParyPłodneButton_Click(object sender, RoutedEventArgs e)
        {
            settings.ParyPłodne--;
        }

        private void PlusParyPłodneButton_CLick(object sender, RoutedEventArgs e)
        {
            settings.ParyPłodne++;
        }

        private void MinusParyNiePłodneButton_Click(object sender, RoutedEventArgs e)
        {
            settings.ParyNiePłodne--;
        }

        private void PlusParyNiePłodneButton_CLick(object sender, RoutedEventArgs e)
        {
            settings.ParyNiePłodne++;
        }

        private void MinusWilkiButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Wilki--;
        }

        private void PlusWilkiButton_CLick(object sender, RoutedEventArgs e)
        {
            settings.Wilki++;
        }

        private void MinusLisyButton_Click(object sender, RoutedEventArgs e)
        {
            settings.Lisy--;
        }

        private void PlusLisyButton_CLick(object sender, RoutedEventArgs e)
        {
            settings.Lisy++;
        }

        private void MinusLiczbaMiesiecyButton_Click(object sender, RoutedEventArgs e)
        {
            settings.LiczbaMiesiecy--;
        }

        private void PlusLiczbaMiesiecyButton_CLick(object sender, RoutedEventArgs e)
        {
            settings.LiczbaMiesiecy++;
        }

        public void Symuluj_Click(object sender, RoutedEventArgs e)
        {

            int paryPłodne = int.Parse(this.ParyPłodneTextBox.Text);
            int paryNiePłodne = int.Parse(this.ParyNiePłodneTextBox.Text);
            int wilki = int.Parse(this.WilkiTextBox.Text);
            int lisy = int.Parse(this.LisyTextBox.Text);

            ŻarłocznościWilków żarłocznośćWilków = (ŻarłocznościWilków)Enum.Parse(typeof(ŻarłocznościWilków), this.WilkiComboBox.Text);
            int zarW = (int)żarłocznośćWilków;
            ŻarłocznościLisów żarłocznośćLisów = (ŻarłocznościLisów)Enum.Parse(typeof(ŻarłocznościLisów), this.LisyComboBox.Text);
            int zarL = (int)żarłocznośćLisów;
            int liczbaMiesiecy = int.Parse(this.LiczbaMiesiecyTextBox.Text);

            obliczenia.licz(paryPłodne, paryNiePłodne, wilki, lisy, liczbaMiesiecy, zarW, zarL);

            long plodneKonc = obliczenia.zwrocPlodneKonc();
            long niePlodneKonc = obliczenia.zwrocNieplodneKonc();
            long sumaKonc = obliczenia.zwrocSume();


            Populacja populacja = new Populacja(paryPłodne, paryNiePłodne, wilki, żarłocznośćWilków, lisy, żarłocznośćLisów, liczbaMiesiecy, plodneKonc, niePlodneKonc, sumaKonc);

            if (paryPłodne < 0 || paryNiePłodne < 0 || wilki < 0 || lisy < 0 || liczbaMiesiecy < 0)
            {
                MessageBox.Show("Wprowadzono ujemne parametry", "Błąd");
            }
            else
            {
                PopulacjaList.Add(populacja);
            }

        }

        private void UsuńButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.PopulacjaList.RemoveAt(this.ListView1.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Zaznacz populację którą chcesz usunąć", "Czyszczenie Listy");
            }

        }

        private void ZapiszButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Symulacje";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML document (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filePath = dlg.FileName;

                ListToXmlFile(filePath);
            }


        }

        private void ListToXmlFile(string filePath)
        {
            using (var sw = new StreamWriter(filePath))
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<Populacja>));
                serializer.Serialize(sw, PopulacjaList);
            }
        }

        private void WczytajButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML document (.xml)|*.xml";

            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";
            if (result == true)
            {
                filename = dlg.FileName;

            }
            if (File.Exists(filename))
            {
                XmlFileToList(filename);
            }
            else
            {
                MessageBox.Show("Brak pliku");
            }
        }

        private void XmlFileToList(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(ObservableCollection<Populacja>));
                ObservableCollection<Populacja> tmpList = (ObservableCollection<Populacja>)deserializer.Deserialize(sr);
                foreach (var item in tmpList)
                {
                    PopulacjaList.Add(item);
                }

            }
        }

        private void WyczyscListe_Click(object sender, RoutedEventArgs e)
        {
            PopulacjaList.Clear();
        }
    }
}
