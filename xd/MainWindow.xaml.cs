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
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;

namespace xd
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {


        //------------------------------------------------------------------------------------
        //Konfiguracja wstępna
        //------------------------------------------------------------------------------------

        //inicjalizacja funkcji po starcie programu
        public MainWindow()
        {
            InitializeComponent();
            LbxRefresh();
            Wczytaj();
            CenterWindowOnScreen();
            AddDisk();
        }

        private bool blokada_kat = false;
        private bool blokada_filtr = false;

        //centrowanie okna na ekranie
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        public List<string> kategorie = new List<string>();
        public List<Magazyn> magazyn = new List<Magazyn>();
        public int id_magazyn = 0;
        public const string lokalizacja_bazy = @":\DataBase";
        public const string baza_w_lokalizacji = @":\DataBase\DataBase_urzadzenia.xml";
        public const string baza_kategorie_w_lokalizacji = @":\DataBase\DataBase_urzadzenia_kategorie.xml";
        public string litera_dysku = "C";


        //------------------------------------------------------------------------------------
        //Funkcje główne
        //------------------------------------------------------------------------------------

        //sprawdzenie jaki jest największy ID w magazynie
        private int CheckLastID(List<Magazyn> mag)
        {
            int wynik = 0;                                                                                              //tworzenie zmiennej, która będzie przechowywała szukane ID

            foreach (var val in magazyn) if (val.ID > wynik) wynik = val.ID;                                            //przeszukiwanie wszystkich elementów w celu znalezienia najwięsszego ID
            
            return wynik;                                                                                               //zwracanie odnalezionego ID
        }

        //wyczyszczenie list oraz wczytanie od nowa
        void WczytajLokalizacje()
        {
            litera_dysku = cbx_disklist.SelectedItem.ToString();                                                        //przypisanie pod literę dysku wybranej wartości z ComboBoxa
            magazyn = null;                                                                                             //wyczyszczenie listy magazyn
            kategorie = null;                                                                                           //wyczyszczenie listy kategorie
            Wczytaj();                                                                                                  //wywołanie funkcji wczytaj
            WypelnijCbxKategorie();                                                                                     //wywołanie funkcji wypełnienia kategorii
            LbxRefresh();                                                                                               //odświeżenie listboxa
        }

        //Serializacja do pliku
        void Zapisz()
        {
                try
                {
                    FileStream str = new FileStream(litera_dysku + baza_w_lokalizacji, FileMode.Create);                    //otwarcie nowego strumienia plików w określonej lokalizacji dla bazy danych
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Magazyn>));                                    //otwarcie serializera do określonego typu i strumienia dla bazy danych
                    FileStream gstr = new FileStream(litera_dysku + baza_kategorie_w_lokalizacji, FileMode.Create);         //otwarcie nowego strumienia plików w określonej lokalizacji dla kategorii
                    XmlSerializer gserializer = new XmlSerializer(typeof(List<string>));                                    //otwarcie serializera do określonego typu i strumienia dla kategorii


                    serializer.Serialize(str, magazyn);                                                                     //wykonanie serializacji bazy danych
                    gserializer.Serialize(gstr, kategorie);                                                                 //wykonanie serializacji kategorii

                    str.Close();                                                                                            //zamknięcie strumienia bazy danych
                    gstr.Close();                                                                                           //zamknięcie strumienia kategorii
                }
                catch                                                                                                       //jeżeli wystąpił błąd
                {
                    MessageBox.Show("Nie można zapisać bazy na dysku!");                                                    //wyświetl komunikat
                    cbx_disklist.SelectedItem = 'C';                                                                        //ustaw wybrany dysk na C (poprzez zmiane wybranego elementu w ComboBoxie)
                    WczytajLokalizacje();                                                                                   //odświerza wszystko
                }
        }

        //deserializacja plików
        void Wczytaj()
        {
            //baza danych
            if (File.Exists(litera_dysku + baza_w_lokalizacji))                                                         //jeśli istnieje wybrany plik i jego lokalizacja
            {
                try
                {
                    FileStream str = new FileStream(litera_dysku + baza_w_lokalizacji, FileMode.Open);                  //otwarcie nowego strumienia plików w określonej lokalizacji dla bazy danych
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Magazyn>));                                //otwarcie serializera do określonego typu i strumienia dla bazy danych

                    List<Magazyn> zakup_temp = (List<Magazyn>)serializer.Deserialize(str);                              //wykonanie deserializacji z pliku do tymczasowej listy
                    str.Close();                                                                                        //zamknięcie strumienia

                    magazyn = zakup_temp;                                                                               //przepisanie tymczasowej listy do listy głównej

                    LbxRefresh();                                                                                       //odświerzenie listy zawartości
                }
                catch                                                                                                   //jeśli wystąpi błąd
                {
                    MessageBox.Show("Nie można wczytać bazy z dysku!");                                                 //wyświetl komunikat
                    cbx_disklist.SelectedItem = 'C';                                                                    //ustaw wybrany dysk na C (poprzez zmiane wybranego elementu w ComboBoxie)
                    WczytajLokalizacje();                                                                               //odświerza wszystko
                }
            }
            else                                                                                                        //jeśli wybrany plik lub lokalizacja nie istnieje
            {
                try
                {
                    System.IO.Directory.CreateDirectory(litera_dysku + lokalizacja_bazy);                               //tworzy odpowiedni katalog
                }
                catch
                {
                    MessageBox.Show("Proszę wybrać literę dysku");                                                      //wyświetl komunikat
                    cbx_disklist.SelectedItem = 'C';                                                                    //ustaw wybrany dysk na C (poprzez zmiane wybranego elementu w ComboBoxie)
                    WczytajLokalizacje();                                                                               //odświerza wszystko
                }

            }

            //kategirie
            if (File.Exists(litera_dysku + baza_kategorie_w_lokalizacji))                                               //jeśli istnieje wybrany plik i jego lokalizacja
            {
                try
                {
                    FileStream str = new FileStream(litera_dysku + baza_kategorie_w_lokalizacji, FileMode.Open);        //otwarcie nowego strumienia plików w określonej lokalizacji dla bazy danych
                    XmlSerializer ggserializer = new XmlSerializer(typeof(List<string>));                               //otwarcie serializera do określonego typu i strumienia dla bazy danych

                    List<string> gat_temp = (List<string>)ggserializer.Deserialize(str);                                //wykonanie deserializacji z pliku do tymczasowej listy
                    str.Close();                                                                                        //zamknięcie strumienia

                    kategorie = gat_temp;                                                                               //przepisanie tymczasowej listy do listy głównej
                }
                catch
                {
                    MessageBox.Show("Nie można wczytać bazy z dysku!");                                                 //wyświetl komunikat
                    cbx_disklist.SelectedItem = 'C';                                                                    //ustaw wybrany dysk na C (poprzez zmiane wybranego elementu w ComboBoxie)
                    WczytajLokalizacje();                                                                               //odświerza wszystko
                }
            }
            else                                                                                                        //jeśli wybrany plik lub lokalizacja nie istnieje
            {
                try
                {
                    System.IO.Directory.CreateDirectory(litera_dysku + lokalizacja_bazy);                               //tworzy odpowiedni katalog
                }
                catch
                {
                    MessageBox.Show("Proszę podać literę dysku");                                                       //wyświetl komunikat
                    cbx_disklist.SelectedItem = 'C';                                                                    //ustaw wybrany dysk na C (poprzez zmiane wybranego elementu w ComboBoxie)
                    WczytajLokalizacje();                                                                               //odświerza wszystko
                }
            }
            Zapisz();                                                                                                   //zapisuje wszystkie zmiany
        }

        //wczytywanie wszystkich liter dysków i dodawanie do ComboBox-a
        private void AddDisk()
        {
            try
            {
                string[] drives = System.IO.Directory.GetLogicalDrives();                                               //tworzy tablice stringów azwierającą listey dysków (c:\)

                foreach (string str in drives)                                                                          //dla wszystkich elementów tablicy stringów(tyle ile jest napędów) 
                {
                    char disk = str[0];                                                                                 //tworzy chara i przypisuje do niego samą literę dysku
                    cbx_disklist.Items.Add(disk);                                                                       //dodaje litere dysku do ComboBoxa
                }
                cbx_disklist.SelectedItem = 'C';                                                                        //wybiera w ComboBoxie domyślny dysk C
            }
            catch { }
        }

        //odświerzanie zawartości listboxa zawartością bazy
        public void LbxRefresh()
        {
            try
            {
                magazyn.Sort();                                                                                         //wykonanie sortowania elementów w magazynie( poprzez porównywanie nazw(CompareTo))
                lbx_zawartosc.Items.Clear();                                                                            //czyszczenie zawartości listboxa
                foreach (var val in magazyn) lbx_zawartosc.Items.Add(val);                                              //dodawanie do listboxa wszystkich posortowanych elementów z listy
                if (blokada_filtr == true) Filtruj();                                                                   //jeśli filtrowanie jest włączone to wywołuje funkcję filtruj
            }
            catch
            { MessageBox.Show("error"); }
        }

        //wypełnienie kontrolek zawartością wybranego elementu listy
        public void LbxWyswietl_source(Magazyn magazyna)
        {
            lbl_id.Content = "";

            lbl_nazwa.Content = magazyna.Nazwa;
            lbl_model.Content = magazyna.Model;
            lbl_cena.Content = $"{magazyna.Cena:C}";
            lbl_data.Content = magazyna.Data_zakupu;
            lbl_gdzienabyto.Content = magazyna.GdzieNabyto;
            lbl_kategoria.Content = "Kategoria: " + magazyna.Kategoria;
            if (magazyna.CzyOdNowosci == true) lbl_odnowosci.Content = "Tak";                                           //jeśli jest od nowości wtedy napisz tak, a jak nie jest to napisz nie
            else lbl_odnowosci.Content = "Nie";

            tblk_info.Text = magazyna.Info;
            try                                                                                                         //wypełnienie zawartością usterek i wyposażenia
            {
                lbx_usterki.Items.Clear();                                                                              
                foreach (var val in magazyna.Usterka) lbx_usterki.Items.Add(val);

                lbx_wyposarzenie.Items.Clear();
                foreach (var val in magazyna.Wyposarzenie) lbx_wyposarzenie.Items.Add(val);

                if (lbx_zawartosc.SelectedIndex != -1) id_magazyn = magazyna.ID;                                        //jeśli w listoboxie z zawartością jest coś wybrane to przypisuje do ID wartość ID z obecnie wybranego elementu
            }
            catch { MessageBox.Show("Błąd podczas wyświetlania"); }
        }

        //przeszukiwanie listy magazynu w poszukiwaniu elementu, który ma takie samo ID jak id_magazyn
        private Magazyn PreModyfikacja(List<Magazyn> mag)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie nowej tymczasowej zmiennej typu magazyn i zerowanie jej
            var filtr_premodyfikacja = magazyn.
               Where(val => val.ID == id_magazyn).
               Select(val => val);                                                                                      //filtrowanie elementu, który ma takie samo id jak zmienna id_magazyn
            
            foreach (var val in filtr_premodyfikacja) temp_magazyn = val;                                               //przypisanie do tymczasowej zmiennej przefiltrowany element
            return temp_magazyn;                                                                                        //zwracanie przefiltrowanego elementu
        }

        //czyści wszystkie pola
        private void CzyszczenieWszystkichPol()
        {
            lbl_id.Content = "";
            lbl_nazwa.Content = "";
            lbl_model.Content = "";
            lbl_cena.Content = "";
            lbl_data.Content = "";
            lbl_gdzienabyto.Content = "";
            lbl_kategoria.Content = "";
            lbl_odnowosci.Content = "";
            tblk_info.Text = "";
            try
            {
                lbx_usterki.Items.Clear();
                lbx_wyposarzenie.Items.Clear();
            }
            catch { MessageBox.Show("Błąd podczas czyszczenia wszystkich pól"); }
        }

        //wyświetla zawartość wybranego elementu
        public void LbxWyswietl()
        {
            try
            {
                if(lbx_zawartosc.SelectedItem != null)                                                                  //jaśli jest wybrany jakiś element
                {
                    LbxWyswietl_source((Magazyn)lbx_zawartosc.SelectedItem);                                            //wtedy wyświetl jego zawartość
                }
            }
            catch
            {
                MessageBox.Show("Proszę wybrać element z listy.");
            }
        }

        //filtrowanie i wypełnianie listboxa z elementami bazy przefiltrowanymi elementami listy
        private void Filtruj()
        {

            string nazwa = tbx_filtruj.Text;                                                                            //tworzenie zmiennej do filtrowania po nazwie
            string categ = "";                                                                                          //tworzenie zmiennej do filtrowania po kategorii

            try
            {
                categ = cbx_categories.SelectedItem.ToString();                                                        //przypisanie do zmiennej kategorii zawartości z ComboBoxa
            }
            catch { }


            if (categ != "")                                                                                            //jeśli wybrano sortowanie wedle jakiejś kategorii
            {
                if (nazwa != "")                                                                                        //jeśli wybrano sortowanie po kategorii i nazwie
                {
                    blokada_kat = true;                                                                                 //ustawia blokade kategorii na true
                    blokada_filtr = true;                                                                               //ustawia blokade filtru na true
                    var filtr1a = magazyn.
                    Where(val => val.Kategoria == categ).
                    Where(val => val.Nazwa.ToUpper().Contains(nazwa.ToUpper())).
                    Select(val => val);                                                                                 //filtruje liste po kategorii i nazwie

                    lbx_zawartosc.Items.Clear();                                                                        //czyści listboxa z elementami bazy danych
                    foreach (var val in filtr1a) lbx_zawartosc.Items.Add(val);                                          //wypełnia listboxa elementami przefiltrowanymi

                }
                else                                                                                                    //jeśli wybrano filtrowanie po samej kategorii
                {
                    blokada_kat = true;                                                                                 //ustawia blokade kategorii na true                                                                                 
                    blokada_filtr = true;                                                                               //ustawia blokade filtru na true
                    var filtr1a = magazyn.
                    Where(val => val.Kategoria == categ).
                    Select(val => val);                                                                                 //wykonuje filtrowanie po samej kategorii

                    lbx_zawartosc.Items.Clear();                                                                        //czyści listboxa z elementami bazy danych
                    foreach (var val in filtr1a) lbx_zawartosc.Items.Add(val);                                          //wypełnia listboxa elementami przefiltrowanymi
                }
            }
            else                                                                                                        //jeśli wybrano filtrowanie bez kategorii
            {
                if (nazwa != "")                                                                                        //jeśli wybrano filtrowanie tylko po nazwie
                {
                    blokada_filtr = true;                                                                               //włącza blokadę filtru
                    var filtr1a = magazyn.
                    Where(val => val.Nazwa.ToUpper().Contains(nazwa.ToUpper())).
                    Select(val => val);                                                                                 //filtruje tylko po nazwie

                    lbx_zawartosc.Items.Clear();                                                                        //czyści listboxa z elementami bazy danych
                    foreach (var val in filtr1a) lbx_zawartosc.Items.Add(val);                                          //wypełnia listboxa elementami przefiltrowanymi
                }
                else
                {
                    blokada_filtr = false;                                                                              //ustawia blokade filtru na false
                    LbxRefresh();                                                                                       //odświerza listboxa bez filtrowania( pokazuje wszystko co jest w liście)
                }
            }

        }

        //wypełnianie comboboxa z kategoriami
        private void WypelnijCbxKategorie()
        {
            try
            {
                cbx_categories.Items.Clear();                                                                           //czyszczenie Comboboxa z elementów
                foreach (string val in kategorie)                                                                       //dodawanie kolejnych elementów z listy kategorii
                {
                    cbx_categories.Items.Add(val);
                }
            }
            catch { MessageBox.Show("ERROR!"); }
        }



        //------------------------------------------------------------------------------------
        //Funkcje zdalne
        //------------------------------------------------------------------------------------


        //wcisnięcie przycisku dodawania nowego elementu
        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodawanie dod = new Dodawanie(kategorie);                                                                   //tworzenie nowego okna dodawania
            dod.ShowDialog();                                                                                           //otwieranie okna dodawania
            Wczytaj();                                                                                                  //wczytywanie zawartości z pliku(deserializacja)

            int ostatnie_ID = CheckLastID(magazyn) + 1;                                                                 //tworzenie ostatniego ID (poprzez sprawdzenie jakie jest największe ID w magazynie i dodanie do niego 1)

            try
            {
                if (dod.ZwracanieCzyDodac == true)                                                                      //jeśli wybrano zapisz, wetdy zwróci true i wykona dodawanie nowego elementu
                {
                    magazyn.Add(new Magazyn()
                    {
                        Nazwa = dod.ZwracanieNazwa,
                        Cena = Convert.ToDouble(dod.ZwracanieCena),
                        CzyOdNowosci = dod.ZwracanieCzyOdNowosci,
                        Data_zakupu = dod.ZwracanieData,
                        GdzieNabyto = dod.ZwracanieGdzieNabyto,
                        Info = dod.ZwracanieInfo,
                        Model = dod.ZwracanieModel,
                        Usterka = dod.ZwracanieUsterki,
                        Wyposarzenie = dod.ZwracanieWyposarzenie,
                        Naprawy = new List<Serwis>(),
                        Kategoria = dod.ZwracanieKategoria,
                        ID = ostatnie_ID
                    });
                }
            }
            catch
            {
                MessageBox.Show("Błąd podczas dodawania");
            }
            LbxRefresh();                                                                                               //odświerzanie listboxa
            Zapisz();                                                                                                   //serializacja
        }

        //po wciśnięciu przycisku filtrowania
        private void btn_filtruj_Click(object sender, RoutedEventArgs e)
        {
            Filtruj();                                                                                                  //wykona filtrowanie
        }

        //po wciśnięciu przycisku kasowania elementu z bazy
        private void btn_usun_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzy nową tymczasową zmienną typu magazyn
            try
            {
                temp_magazyn = PreModyfikacja(magazyn);                                                                 //do tymczasowej zmiennej przypisuje zmienną o takim samym ID jak ID obecnie wybranego elementu

                magazyn.Remove(temp_magazyn);                                                                           //z listy magazyn kasuje wybrany element
                lbx_zawartosc.Items.Clear();                                                                            //czyszczenie listboxa
                LbxRefresh();                                                                                           //wypełnianie listboxa
            }
            catch { MessageBox.Show("Błąd podczas kasowania"); }
            Zapisz();                                                                                                   //wykonywanie serializacji
            CzyszczenieWszystkichPol();                                                                                 //czyszczenie wszystkich pól po usuniętym obiekcie
        }                                   

        //wciśnięcie przycisku dodawania usterki
        private void btn_usterki_plus_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie tymczasowej zmiennej typu magazyn 
            int temp_id = 0;                                                                                            //tworzenie tymczasowej zmiennej ID
            temp_magazyn = PreModyfikacja(magazyn);                                                                     //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID

            Wprowadz wp = new Wprowadz();                                                                               //tworzenie nowego okna wprowadzania
            wp.ShowDialog();                                                                                            //otwieranie nowego okna wprowadzania
            if (wp.ZwracanieCzyAnulowac == false)                                                                       //jeśli wybrano zatwierdź wtedy
            {
                try
                {
                    temp_magazyn.Usterka.Add(wp.ZwracanieWprowadz);                                                     //dodaje do listy usterek w tymczasowej zmiennej nowego stringa z nazwą zwróconą w oknie wprowadzania
                    lbx_usterki.Items.Clear();                                                                          //czyszzcenie zawartości listboxa z usterkami
                    foreach (var val in temp_magazyn.Usterka) lbx_usterki.Items.Add(val);                               //wypełnianie listboxa z usterkami

                    for (int clk = 0; clk < 1000000; clk++)                                                             //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                    {
                        if (temp_magazyn == magazyn[clk])
                        {
                            temp_id = clk;
                            break;
                        }
                    }

                    magazyn[temp_id] = temp_magazyn;                                                                    //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym
                }
                catch
                {
                    MessageBox.Show("Błąd podczas dodawania usterki");
                }
            }
            Zapisz();                                                                                                   //serializacja
        }

        //wciśnięcie przycisku kasowania usterki
        private void btn_usterki_minus_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie tymczasowej zmiennej typu magazyn
            int temp_id = 0;                                                                                            //tworzenie tymczasowej zmiennej do ID
            temp_magazyn = PreModyfikacja(magazyn);                                                                     //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID

            if (lbx_usterki.SelectedIndex != -1)                                                                        //jeśli wybrano jakąś usterkę 
                {
                    temp_magazyn.Usterka.RemoveAt(lbx_usterki.SelectedIndex);                                           //kasowanie wybranej usterki z listy usterek w tymczasowym elemencie
                    lbx_usterki.Items.Clear();                                                                          //czyszzcenie zawartości listboxa z usterkami                                                                 
                    foreach (var val in temp_magazyn.Usterka) lbx_usterki.Items.Add(val);                               //wypełnianie listboxa z usterkami

                for (int clk = 0; clk < 1000000; clk++)                                                                 //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                {
                    if (temp_magazyn == magazyn[clk])
                    {
                        temp_id = clk;
                        break;
                    }
                }

                magazyn[temp_id] = temp_magazyn;                                                                        //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym
            }
            Zapisz();                                                                                                   //serializacja
        }

        //wciśnięcie przycisku dodawania wyposażenia
        private void btn_wyposarzenie_plus_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie tymczasowej zmiennej typu magazyn 
            int temp_id = 0;                                                                                            //tworzenie tymczasowej zmiennej do ID
            temp_magazyn = PreModyfikacja(magazyn);                                                                     //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID

            Wprowadz wp = new Wprowadz();
            wp.ShowDialog();
            if (wp.ZwracanieCzyAnulowac == false)
            {
                try
                {
                    temp_magazyn.Wyposarzenie.Add(wp.ZwracanieWprowadz);                                                //dodaje do listy wyposażenia w tymczasowej zmiennej nowego stringa z nazwą zwróconą w oknie wprowadzania
                    lbx_wyposarzenie.Items.Clear();                                                                     //czyszzcenie zawartości listboxa z wyposażeniem
                    foreach (var val in temp_magazyn.Wyposarzenie) lbx_wyposarzenie.Items.Add(val);                     //wypełnianie listboxa z wyposażeniem

                    for (int clk = 0; clk < 1000000; clk++)                                                             //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                    {
                        if (temp_magazyn == magazyn[clk])
                        {
                            temp_id = clk;
                            break;
                        }
                    }

                    magazyn[temp_id] = temp_magazyn;                                                                    //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym
                }
                catch
                {
                    MessageBox.Show("Błąd podczas dodawania wyposażenia");
                }
            }
            Zapisz();                                                                                                   //serializacja
        }

        //wciśnięcie przycisku kasowania wyposażenia
        private void btn_wyposarzenie_minus_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie tymczasowej zmiennej typu magazyn 
            int temp_id = 0;                                                                                            //tworzenie tymczasowej zmiennej do ID
            temp_magazyn = PreModyfikacja(magazyn);                                                                     //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID

            if (lbx_wyposarzenie.SelectedIndex != -1)                                                                   //jeśli wybrano jakąś wyposażenie 
            {
                temp_magazyn.Wyposarzenie.RemoveAt(lbx_wyposarzenie.SelectedIndex);                                     //kasowanie wybranego wyposażenia z listy wyposażenia w tymczasowym elemencie
                lbx_wyposarzenie.Items.Clear();                                                                         //czyszzcenie zawartości listboxa z wyposażeniem

                foreach (var val in temp_magazyn.Wyposarzenie) lbx_wyposarzenie.Items.Add(val);                         //wypełnianie listboxa z wyposażeniem


                for (int clk = 0; clk < 1000000; clk++)                                                                 //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                {
                    if (temp_magazyn == magazyn[clk])
                    {
                        temp_id = clk;
                        break;
                    }
                }

                magazyn[temp_id] = temp_magazyn;                                                                        //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym

                Zapisz();                                                                                               //serializacja
            }
        }

        //otwieranie okna z serwisowaniem sprzętu
        private void btn_serwis_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie nowej tymczasowej zmiennej typu magazyn
            int temp_id = 0;                                                                                            //tworzenie nowej tymczasowej zmiennej do przechowywania ID
            try
            {
                temp_magazyn = PreModyfikacja(magazyn);                                                                 //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID
                Naprawy nap = new Naprawy();                                                                            //tworzenie nowego okna napraw
                nap.lsX = temp_magazyn.Naprawy;                                                                         //wywołanie funkcji, przez którą zostają do okna przekazane wartości
                nap.ShowDialog();                                                                                       //otwieranie okna
                temp_magazyn.Naprawy = nap.ls;                                                                          //zwracanie napraw i przypisanie pod naprawy w tymczasowej zmiennej

                 for (int clk = 0; clk < 1000000; clk++)                                                                //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                {
                    if (temp_magazyn == magazyn[clk])
                    {
                        temp_id = clk;
                        break;
                    }
                }

            magazyn[temp_id] = temp_magazyn;                                                                            //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym
                Zapisz();                                                                                               //serializacja
            }
            catch { MessageBox.Show("Błąd podczas operacji na naprawach"); }
        }

        //edycja wybranego elementu z listy
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Magazyn temp_magazyn = null;                                                                                //tworzenie nowej tymczasowej zmiennej typu magazyn
            try
            {
            temp_magazyn = PreModyfikacja(magazyn);                                                                     //przypisanie do zmiennej magazyn element listy magazyn o takim samym ID jak wybrane ID

                int temp_id = 0;                                                                                        //tworzenie nowej tymczasowej zmiennj do ID
         
            Edycja edit = new Edycja(temp_magazyn, kategorie);                                                          //tworzenie okna edycji wraz z wysłaniem do niego przez konstruktor listy kategorii i tymczasowej zmiennej magazyn 

                edit.ShowDialog();                                                                                      //pokazanie okna edycji



            if (edit.ZwracanieCzyDodac == true)                                                                         //jeśli zatwierdzono dodanie wtedy nadpisuje wartości w zmiennej tymczasowej wartościami zwróconymi z okna
                {
                    Double.TryParse(edit.ZwracanieCena, out double cena);
                    temp_magazyn.Cena = cena;
                    temp_magazyn.CzyOdNowosci = edit.ZwracanieCzyOdNowosci;
                    temp_magazyn.GdzieNabyto = edit.ZwracanieGdzieNabyto;
                    temp_magazyn.Model = edit.ZwracanieModel;
                    temp_magazyn.Data_zakupu = edit.ZwracanieData;
                    temp_magazyn.Nazwa = edit.ZwracanieNazwa;
                    temp_magazyn.Info = edit.ZwracanieInfo;
                    temp_magazyn.Kategoria = edit.ZwracanieKategoria;

                for (int clk = 0; clk<1000000; clk++)                                                                   //wyszukiwanie który z kolei jest to element w textboxie i przypisanie jego numerka do zmiennej tempID oraz wyskoczenie z pętli for
                    {
                    if(temp_magazyn == magazyn[clk])
                    {
                        temp_id = clk;
                        break;
                    }
                }

                magazyn[temp_id] = temp_magazyn;                                                                        //edycja elementu w liście o wybranym ID poprzez nadpisanie go edytowanym elementem tymczasowym
                }
             }
             catch
            {
                MessageBox.Show("Błąd podczas zapisu edytowanego obiektu");
            }
            CzyszczenieWszystkichPol();                                                                                 //czyszczenie wszystkich pól z zawartości
            LbxRefresh();                                                                                               //odświerzanie listboxa z elementami bazy danych
            Zapisz();                                                                                                   //serializacja

        }                                                                          

        //wciśnięcie konkretnego przycisku podczas wprowadzania tekstu do filtrowania (enter)
        private void tbx_filtruj_KeyDown(object sender, KeyEventArgs e)
        {
            string ekey = e.Key.ToString();                                                                             //tworzy stringa z obecnie wciśniętego klawisza podczas wprowadzania do textboxa
            if (ekey == "Return")                                                                                       //Jeżeli wczśnięty klawisz to enter (Return) wtedy wykonuje wciśnięcie przycisku filtrowania
            {
                btn_filtruj_Click(sender, e);
            }
        }

        //po wybraniu nowej litery dysku odświerzenie zawartości
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WczytajLokalizacje();                                                                                       //po zmianie elementu w ComboBoxie następuje odświerzenie zawartości z nowej ścieżki
        }

        //wciśnięcie przycisku dodawania lub kasowania kategorii
        private void btn_kat_addorremove_Click(object sender, RoutedEventArgs e)
        {
            Kategorie kat = new Kategorie(kategorie);                                                                   //tworzenie okna modyfikacji kategorii przesyłając w konstruktorze obecną listę kategorii
            kat.ShowDialog();                                                                                           //otwieranie okna modyfikacji kategorii

            kategorie = kat.Zwracanie;                                                                                  //nadpisanie listy kategorii listą zwróconą
            WypelnijCbxKategorie();                                                                                     //wypełnienie comboboxa kategoriami
            Zapisz();                                                                                                   //serializacja
        }

        //wybranie jakiejś kategorii powoduja automatyczne filtrowanie
        private void ComboBox_SelectionChanged_kat(object sender, SelectionChangedEventArgs e)
        {
            Filtruj();                                                                                                  //wykonanie filtrowania
        }

        //po wciśnięciu przycisku czyszczenia kategorii
        private void btn_kat_clear_Click(object sender, RoutedEventArgs e)
        {
            cbx_categories.Text = "";                                                                                   //czyszczenei zawartości comboboxa z kategoriami
            LbxRefresh();                                                                                               //odświerzanie listboxa zawierającego elementy bazy danych
        }

        //po wybraniu jakiegoś elementu z listboxa zawierającego elementy bazy danych
        private void lbx_zawartosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            LbxWyswietl();                                                                                              //wyświetla zawartość wybranego elementu
            lbx_zawartosc.Items.Clear();                                                                                //czyści listboxa
            LbxRefresh();                                                                                               //odświerza zawartość listboxa
        }
    }
}
