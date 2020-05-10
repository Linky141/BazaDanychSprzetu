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
    /// Logika interakcji dla klasy NaprawyDodaj.xaml
    /// </summary>
    public partial class NaprawyEdytuj : Window
    {
        public NaprawyEdytuj()
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

        public NaprawyEdytuj(Serwis serw)
        {
            InitializeComponent();
            this.serwis = serw;
            tbx_nazwa.Text = serwis.NazwaNaprawy;
            tbx_info.Text = serwis.InfoONaprawie;
            tbx_data.Text = serwis.DataNaprawy;
            tbx_koszt.Text = serwis.KosztNaprawy.ToString();
            CenterWindowOnScreen();
        }

        Serwis serwis = new Serwis();


        bool czydodac = false;

        public bool ZwracanieCzydodac
        {
            get { return this.czydodac; }
        }

        public string ZwracanieNazwa
        {
            get { return this.tbx_nazwa.Text; }
        }
        public string ZwracanieData
        {
            get { return this.tbx_data.Text; }
        }
        public string ZwracanieKoszt
        {
            get { return this.tbx_koszt.Text; }
        }
        public string ZwracanieInfo
        {
            get { return this.tbx_info.Text; }
        }

        private void Button_Dodaj_click(object sender, RoutedEventArgs e)
        {
            czydodac = true;
            this.Close();
        }

        private void btn_anuluj_Click(object sender, RoutedEventArgs e)
        {
            czydodac = false;
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
