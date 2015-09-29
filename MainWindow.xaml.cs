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
using GEM_C_E.Views;

namespace GEM_C_E
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IApplicationService
    {
        public MainWindow()
        {
            InitializeComponent();
            Configure();
            contentPresenter.Content = new DemarrageTempsView();

        }

        private void Configure()
        {
            ServiceFactory.Instance.Register<IApplicationService, MainWindow>(this);
        }

        public void ChangeView<T>(T view)
        {
            contentPresenter.Content = view as UserControl;
        }
    }
}
