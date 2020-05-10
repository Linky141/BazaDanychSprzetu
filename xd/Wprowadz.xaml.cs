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
    /// Logika interakcji dla klasy Wprowadz.xaml
    /// </summary>
    public partial class Wprowadz : Window
    {
        public Wprowadz()
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

        public bool anuluj = false;

        public string ZwracanieWprowadz
        {
            get { return this.tbx_wprowadz.Text; }
        }

        public bool ZwracanieCzyAnulowac
        {
            get { return this.anuluj; }
        }

        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            anuluj = false;
            this.Close();

        }

        private void btn_anuluj_Click(object sender, RoutedEventArgs e)
        {
            anuluj = true;
            this.Close();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
