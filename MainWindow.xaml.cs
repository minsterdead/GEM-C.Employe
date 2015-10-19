using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Cstj.MvvmToolkit.Services;
using GEM_C_E.Models.Entities;
using GEM_C_E.Service.Definitions;
using GEM_C_E.Service.MySql;

namespace GEM_C_E
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged, INotifyPropertyChanging
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ServiceFactory.Instance.Register<IEmployeService, MySqlEmploye>(new MySqlEmploye());
            Employes = new ObservableCollection<Employe>(ServiceFactory.Instance.GetService<IEmployeService>().RetrieveAll());
        }

        private void Employe_SeletChanged(object sender, SelectionChangedEventArgs e)
        {
            int idEmploye = Convert.ToInt32(cblstEmploye.SelectedValue.ToString());

            MySqlEmploye _EmployeService = new MySqlEmploye();

            if (_EmployeService.VérifierDemArr(idEmploye)) {

                ChangedPropriete("D", true);

                ServiceFactory.Instance.Register<IProjetService, MySqlProjet>(new MySqlProjet());
                Projets = new ObservableCollection<Projet>(ServiceFactory.Instance.GetService<IProjetService>().Retrieve(idEmploye));
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

        //Méthode qui permet d'activer ou de désactiviter la combobox des projet et bouton démarrer et arrêter
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

        #region Bindable
        private ObservableCollection<Employe> _employe = new ObservableCollection<Employe>();

        public ObservableCollection<Employe> Employes
        {
            get
            {
                return _employe;
            }

            set
            {
                if (_employe == value)
                {
                    return;
                }
                _employe = value;
            }
        }

        private ObservableCollection<Projet> _projet = new ObservableCollection<Projet>();

        public ObservableCollection<Projet> Projets
        {
            get
            {
                return _projet;
            }

            set
            {
                if (_projet == value)
                {
                    return;
                }
                _projet = value;
            }
        }
        #endregion

        #region INotifyPropertyChanged INotifyPropertyChanging
        public event PropertyChangedEventHandler PropertyChanged;

        protected PropertyChangedEventHandler PropertyChangedHandler
        {
            get { return PropertyChanged; }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        protected PropertyChangingEventHandler PropertyChangingHandler
        {
            get { return PropertyChanging; }
        }


        protected virtual void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanging;
            if (handler != null)
            {
                handler(this, new PropertyChangingEventArgs(propertyName));
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
