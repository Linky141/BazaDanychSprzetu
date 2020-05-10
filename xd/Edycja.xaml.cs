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
using System.Windows.Shapes;

namespace xd
{
    /// <summary>
    /// Logika interakcji dla klasy Dodawanie.xaml
    /// </summary>
    public partial class Edycja : Window
    {
        public Edycja()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void WypelnijCbxKategorie()
        {
            try
            {
                foreach (string val in kategorie)
                {
                    cbx_categories.Items.Add(val);
                }
            }
            catch { MessageBox.Show("ERROR!"); }
        }

        public Edycja(Magazyn mg, List<string> gat)
        {
            InitializeComponent();
            this.magazyn = mg;
            tbx_nazwa.Text = magazyn.Nazwa;
            tbx_model.Text = magazyn.Model;
            tbx_info.Text = magazyn.Info;
            tbx_gdzie_nabyto.Text = magazyn.GdzieNabyto;
            tbx_data.Text = magazyn.Data_zakupu;
            tbx_cena.Text = magazyn.Cena.ToString();
            if (magazyn.Kategoria != "") cbx_categories.SelectedItem = magazyn.Kategoria;
            else cbx_categories.Text = "";

            this.kategorie = gat;
            WypelnijCbxKategorie();

            if (mg.CzyOdNowosci == true)
            {
                rbtn_od_nowosci_tak.IsChecked = true;
                rbtn_od_nowosci_nie.IsChecked = false;
            }
            else
            {
                rbtn_od_nowosci_nie.IsChecked = true;
                rbtn_od_nowosci_tak.IsChecked = false;
            }
            CenterWindowOnScreen();
        }

        Magazyn magazyn = new Magazyn();
        List<string> kategorie = new List<string>();

        bool czydodac = true;
        bool czyodnowosci = false;

        List<string> usterki = new List<string>();
        List<string> wyposarzenie = new List<string>();

        






        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            czydodac = true;
            this.Close();
        }

        private void btn_anuluj_Click(object sender, RoutedEventArgs e)
        {
            czydodac = false;
            this.Close();
        }

        private void rbtn_od_nowosci_tak_Checked(object sender, RoutedEventArgs e)
        {
            czyodnowosci = true;
        }

        private void rbtn_od_nowosci_nie_Checked(object sender, RoutedEventArgs e)
        {
            czyodnowosci = false;
        }

      

        //-------------------------------------------------zwracanie
        public string ZwracanieNazwa
        {
            get { return this.tbx_nazwa.Text; }
        }

        public string ZwracanieInfo
        {
            get { return this.tbx_info.Text; }
        }

        public string ZwracanieCena
        {
            get { return this.tbx_cena.Text; }
        }

        public string ZwracanieData
        {
            get { return this.tbx_data.Text; }
        }

        public string ZwracanieGdzieNabyto
        {
            get { return this.tbx_gdzie_nabyto.Text; }
        }

        public string ZwracanieModel
        {
            get { return this.tbx_model.Text; }
        }

        public bool ZwracanieCzyOdNowosci
        {
            get { return this.czyodnowosci; }
        }


        public bool ZwracanieCzyDodac
        {
            get { return this.czydodac; }
        }

        public string ZwracanieKategoria
        {
            get
            {
                if (cbx_categories.SelectedItem != null) return cbx_categories.SelectedItem.ToString();
                return "";

            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_czysc_kat_Click(object sender, RoutedEventArgs e)
        {
            cbx_categories.Text = "";
        }

        private void ComboBox_SelectionChanged_kat(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
