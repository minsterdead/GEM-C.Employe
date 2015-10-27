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
        private int idEmploye;
        private ObservableCollection<Projet> _projet = new ObservableCollection<Projet>();
        private ObservableCollection<Employe> _employe = new ObservableCollection<Employe>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ServiceFactory.Instance.Register<IEmployeService, MySqlEmploye>(new MySqlEmploye());
            ServiceFactory.Instance.Register<IProjetService, MySqlProjet>(new MySqlProjet());
            Employes = new ObservableCollection<Employe>(ServiceFactory.Instance.GetService<IEmployeService>().RetrieveAll());
        }

        private void Employe_SeletChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cblstEmploye.SelectedIndex.ToString() != "-1")
            {

                idEmploye = Convert.ToInt32(cblstEmploye.SelectedValue.ToString());

                MySqlEmploye _EmployeService = new MySqlEmploye();

                if (_EmployeService.VerifierDemArr(idEmploye))
                {

                    ChangedPropriete("D", true);

                    Projets = new ObservableCollection<Projet>(ServiceFactory.Instance.GetService<IProjetService>().Retrieve(idEmploye));
                }
                else
                {
                    ChangedPropriete("A", true);

                    List<string> donnees = _EmployeService.RecupeDonnees(idEmploye);

                    txtProjet.Text = donnees[0];
                    float TempsCumul = Convert.ToSingle(donnees[2]);
                    txtHeureCumul.Text = Math.Round(TempsCumul, 2).ToString(); 
                    DateTime debutSession = Convert.ToDateTime(donnees[1]);
                    txtHeureSession.Text = Math.Round((DateTime.Now - debutSession).TotalHours, 2).ToString();
               }
            }
            
        }

        private void Demarrer_Click(object sender, RoutedEventArgs e)
        {
            int idProjet = Convert.ToInt32(cblstEmploye.SelectedValue.ToString());

            MySqlProjet _ProjetService = new MySqlProjet();

            _ProjetService.CreerTemps(idEmploye, idProjet);

            cblstProjet.SelectedIndex = -1;
            cblstEmploye.SelectedIndex = -1;

            ChangedPropriete("D", false);
        }

        private void Arret_Click(object sender, RoutedEventArgs e)
        {
            cblstEmploye.SelectedIndex = -1;

            ChangedPropriete("A", false);

            MySqlEmploye _EmployeService = new MySqlEmploye();

            _EmployeService.UpdateCompteurs(idEmploye);
        }

        //Méthode qui permet d'activer ou de désactiviter la combobox des projet et bouton démarrer et arrêter
        private void ChangedPropriete(string DA, bool VH)
        {
            if (DA == "D") {
                if (VH == true)
                {
                    //
                    lblProjet.Visibility = Visibility.Visible;
                    cblstProjet.Visibility = Visibility.Visible;
                    //
                    btnArret.Visibility = Visibility.Hidden;
                    //
                    lblNomProjet.Visibility = Visibility.Hidden;
                    lblHeureCumul.Visibility = Visibility.Hidden;
                    lblHeureSession.Visibility = Visibility.Hidden;
                    txtProjet.Visibility = Visibility.Hidden;
                    txtHeureCumul.Visibility = Visibility.Hidden;
                    txtHeureSession.Visibility = Visibility.Hidden;
                }
                else
                {
                    //
                    lblProjet.Visibility = Visibility.Hidden;
                    cblstProjet.Visibility = Visibility.Hidden;
                    btnDemarrer.Visibility = Visibility.Hidden;
                    //
                    lblDateDebut.Visibility = Visibility.Hidden;
                    lblDateFin.Visibility = Visibility.Hidden;
                    lblHrCumul.Visibility = Visibility.Hidden;
                    txtDateDebut.Visibility = Visibility.Hidden;
                    txtDateFin.Visibility = Visibility.Hidden;
                    txtHrCumul.Visibility = Visibility.Hidden;
                }
            }
            else if (DA == "A") {
                if (VH == true)
                {
                    //
                    btnArret.Visibility = Visibility.Visible;
                    //
                    lblNomProjet.Visibility = Visibility.Visible;
                    lblHeureCumul.Visibility = Visibility.Visible;
                    lblHeureSession.Visibility = Visibility.Visible;
                    txtProjet.Visibility = Visibility.Visible;
                    txtHeureCumul.Visibility = Visibility.Visible;
                    txtHeureSession.Visibility = Visibility.Visible;
                    //
                    lblProjet.Visibility = Visibility.Hidden;
                    cblstProjet.Visibility = Visibility.Hidden;
                    btnDemarrer.Visibility = Visibility.Hidden;
                    //
                    lblDateDebut.Visibility = Visibility.Hidden;
                    lblDateFin.Visibility = Visibility.Hidden;
                    lblHrCumul.Visibility = Visibility.Hidden;
                    txtDateDebut.Visibility = Visibility.Hidden;
                    txtDateFin.Visibility = Visibility.Hidden;
                    txtHrCumul.Visibility = Visibility.Hidden;
                }
                else
                {
                    //
                    btnArret.Visibility = Visibility.Hidden;
                    //
                    lblNomProjet.Visibility = Visibility.Hidden;
                    lblHeureCumul.Visibility = Visibility.Hidden;
                    lblHeureSession.Visibility = Visibility.Hidden;
                    txtProjet.Visibility = Visibility.Hidden;
                    txtHeureCumul.Visibility = Visibility.Hidden;
                    txtHeureSession.Visibility = Visibility.Hidden;
                }
            }
            
        }

        #region Bindable

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
                RaisePropertyChanging();
                _projet = value;
                RaisePropertyChanged();
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

        private void Projet_SeletChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(Projet projet in Projets)
            {
                if (Convert.ToInt32(cblstProjet.SelectedIndex.ToString()) != -1)
                {
                    if (projet.IdProjet == Convert.ToInt32(cblstProjet.SelectedValue.ToString()))
                    {
                        txtDateDebut.Text = projet.DateDebut.ToString();
                        txtDateFin.Text = projet.DateFin.ToString();

                        btnDemarrer.Visibility = Visibility.Visible;
                        //
                        lblDateDebut.Visibility = Visibility.Visible;
                        lblDateFin.Visibility = Visibility.Visible;
                        lblHrCumul.Visibility = Visibility.Visible;
                        txtDateDebut.Visibility = Visibility.Visible;
                        txtDateFin.Visibility = Visibility.Visible;
                        txtHrCumul.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
