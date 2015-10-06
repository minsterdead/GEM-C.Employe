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

namespace GEM_C_E
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Employe_SeletChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblstEmploye.SelectedIndex.ToString() == "1") {
                ChangedPropriete("D", true);
            }
            else {
                ChangedPropriete("A", true);
            }
        }

        private void Demarrer_Click(object sender, RoutedEventArgs e)
        {
            ChangedPropriete("D", false);
        }

        private void Arret_Click(object sender, RoutedEventArgs e)
        {
            ChangedPropriete("A", false);
        }

        private void ChangedPropriete(string DA, bool VH)
        {
            if (DA == "D") {
                if (VH == true)
                {
                    lblProjet.Visibility = Visibility.Visible;
                    cblstProjet.Visibility = Visibility.Visible;
                    btnDemarrer.Visibility = Visibility.Visible;
                    btnArret.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblProjet.Visibility = Visibility.Hidden;
                    cblstProjet.Visibility = Visibility.Hidden;
                    btnDemarrer.Visibility = Visibility.Hidden;
                }
            }
            else if (DA == "A") {
                if (VH == true)
                {
                    lblProjet.Visibility = Visibility.Hidden;
                    cblstProjet.Visibility = Visibility.Hidden;
                    btnDemarrer.Visibility = Visibility.Hidden;
                    btnArret.Visibility = Visibility.Visible;
                }
                else
                {
                    btnArret.Visibility = Visibility.Hidden;
                }
            }
            
        }
    }
}
