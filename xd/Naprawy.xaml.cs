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
    /// Logika interakcji dla klasy Naprawy.xaml
    /// </summary>
    public partial class Naprawy : Window
    {
        public Naprawy()
        {
            InitializeComponent();
            WypelnijLBX();
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

        public int id=0;

        public List<Serwis> ls { get; set; }

        public List<Serwis> lsX
        {
            set
            {
                this.ls = value;
                WypelnijLBX();
            }
        }

        public void WypelnijLBX()
        {
            try
            {
                lbx_wyswietl.Items.Clear();
                foreach (var val in ls) lbx_wyswietl.Items.Add(val.NazwaNaprawy);
            }
            catch { }
        }

        public void LbxWyswietl_source(Serwis serw)
        {
            lbl_data.Content = serw.DataNaprawy;
            lbl_koszt.Content = $"{serw.KosztNaprawy:C}";
            lbl_nazwa.Content = serw.NazwaNaprawy;
            tblk_info.Text = serw.InfoONaprawie;
        }

        public void LbxWyswietl()
        {
            for (int clk = 0; clk < ls.Count; clk++)
            {
                string nazwa_operacji = "";
                if (lbx_wyswietl.SelectedItems.Count > 0)
                {
                    nazwa_operacji = lbx_wyswietl.SelectedItem.ToString();
                }
                if (ls[clk].NazwaNaprawy == nazwa_operacji) LbxWyswietl_source(ls[clk]);
            }
            id = lbx_wyswietl.SelectedIndex;
        }




        private void btn_sprawdz_Click(object sender, RoutedEventArgs e)
        {
            LbxWyswietl();
            WypelnijLBX();
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            NaprawyDodaj nprd = new NaprawyDodaj();
            nprd.ShowDialog();
            try
            {
                ls.Add(new Serwis() { NazwaNaprawy = nprd.ZwracanieNazwa, KosztNaprawy = Convert.ToDouble(nprd.ZwracanieKoszt), DataNaprawy = nprd.ZwracanieData, InfoONaprawie = nprd.ZwracanieInfo });
                lbx_wyswietl.Items.Clear();
                foreach (var val in ls) lbx_wyswietl.Items.Add(val.NazwaNaprawy);
            }
            catch
            {
                MessageBox.Show("złe dane");
            }
            WypelnijLBX();
        }

        private void btn_usun_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_wyswietl.SelectedIndex != -1)
            {
                ls.RemoveAt(lbx_wyswietl.SelectedIndex);
                lbx_wyswietl.Items.Clear();
                foreach (var val in ls) lbx_wyswietl.Items.Add(val);
            }
            WypelnijLBX();
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NaprawyEdytuj edit = new NaprawyEdytuj(ls[id]);
        
            edit.ShowDialog();
          
                if (edit.ZwracanieCzydodac == true)
                {
                    Double.TryParse(edit.ZwracanieKoszt, out double cena);
                    ls[id].KosztNaprawy = cena;
                    ls[id].DataNaprawy = edit.ZwracanieData;
                    ls[id].InfoONaprawie = edit.ZwracanieInfo;
                    ls[id].NazwaNaprawy = edit.ZwracanieNazwa;
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            WypelnijLBX();
        }
    }
}
