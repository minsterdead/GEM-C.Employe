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
using GEM_C_E.Service;

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
            Configure();

        }

        private void Configure()
        {
            ServiceFactory.Instance.Register<IApplicationService, MainWindow>(this);
        }

        private void Employe_SeletChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblstEmploye.SelectedIndex.ToString() == "1") {
                lblProjet.Visibility = Visibility.Visible;
                cblstProjet.Visibility = Visibility.Visible;
                btnDemarrer.Visibility = Visibility.Visible;
                btnArret.Visibility = Visibility.Hidden;
            }
            else {
                lblProjet.Visibility = Visibility.Hidden;
                cblstProjet.Visibility = Visibility.Hidden;
                btnDemarrer.Visibility = Visibility.Hidden;
                btnArret.Visibility = Visibility.Visible;
            }
        }

        private void Demarrer_Click(object sender, RoutedEventArgs e)
        {
            lblProjet.Visibility = Visibility.Hidden;
            cblstProjet.Visibility = Visibility.Hidden;
            btnDemarrer.Visibility = Visibility.Hidden;
        }

        private void Arret_Click(object sender, RoutedEventArgs e)
        {
            btnArret.Visibility = Visibility.Hidden;
        }
    }
}
