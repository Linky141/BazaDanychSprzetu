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
    public partial class Dodawanie : Window
    {
        public Dodawanie()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }


        public Dodawanie(List<string> gat)
        {
            InitializeComponent();
            this.kategorie = gat;
            WypelnijCbxKategorie();
            CenterWindowOnScreen();
        }


        private void WypelnijCbxKategorie()
        {
            try
            {
                cbx_categories.Items.Clear();
                foreach (string val in kategorie)
                {
                    cbx_categories.Items.Add(val);
                }
            }
            catch { MessageBox.Show("ERROR!"); }
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


        bool czydodac = true;
        bool czyodnowosci = false;

        List<string> kategorie = new List<string>();
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

        private void btn_usterka_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_nazwa_usterki.Text != "")
            {
                try
                {
                    usterki.Add(tbx_nazwa_usterki.Text);
                    lbx_usterka.Items.Clear();
                    foreach (var val in usterki) lbx_usterka.Items.Add(val);
                    tbx_nazwa_usterki.Text = "";
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void btn_usterka_usun_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_usterka.SelectedIndex != -1)
            {
                usterki.RemoveAt(lbx_usterka.SelectedIndex);
                lbx_usterka.Items.Clear();
                foreach (var val in usterki) lbx_usterka.Items.Add(val);
            }
        }

        private void btn_wyposarzenie_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_nazwa_wyposarzenia.Text != "")
            {
                try
                {
                    wyposarzenie.Add(tbx_nazwa_wyposarzenia.Text);
                    lbx_wyposarzenie.Items.Clear();
                    foreach (var val in wyposarzenie) lbx_wyposarzenie.Items.Add(val);
                    tbx_nazwa_wyposarzenia.Text = "";
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void btn_wyposarzenie_usun_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_wyposarzenie.SelectedIndex != -1)
            {
                wyposarzenie.RemoveAt(lbx_wyposarzenie.SelectedIndex);
                lbx_wyposarzenie.Items.Clear();
                foreach (var val in wyposarzenie) lbx_wyposarzenie.Items.Add(val);
            }
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

        public List<string> ZwracanieUsterki
        {
            get { return this.usterki; }
        }

        public List<string> ZwracanieWyposarzenie
        {
            get { return this.wyposarzenie; }
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
