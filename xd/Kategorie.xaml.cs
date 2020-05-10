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
    /// Logika interakcji dla klasy Kategorie.xaml
    /// </summary>
    public partial class Kategorie : Window
    {
        public Kategorie()
        {
            InitializeComponent();
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


        public Kategorie(List<string> gat)
        {
            InitializeComponent();
            this.kategorie = gat;
            WypelnijCbxGat();
            CenterWindowOnScreen();
        }

        List<string> kategorie = new List<string>();

        private void WypelnijCbxGat()
        {
            try
            {
                foreach (string val in kategorie)
                {
                    lbx_gatunki.Items.Add(val);
                }
            }
            catch { MessageBox.Show("ERROR!"); }
        }




        private void btn_dodaj_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_addgatunek.Text != "")
            {
                try
                {
                    kategorie.Add(tbx_addgatunek.Text);
                    lbx_gatunki.Items.Clear();
                    foreach (var val in kategorie) lbx_gatunki.Items.Add(val);
                    tbx_addgatunek.Text = "";
                }
                catch
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void btn_usun_Click(object sender, RoutedEventArgs e)
        {
            if (lbx_gatunki.SelectedIndex != -1)
            {
                kategorie.RemoveAt(lbx_gatunki.SelectedIndex);
                lbx_gatunki.Items.Clear();
                foreach (var val in kategorie) lbx_gatunki.Items.Add(val);
            }
        }




        //-------------------------------------------------zwracanie

        public List<string> Zwracanie
        {
            get { return this.kategorie; }
        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
