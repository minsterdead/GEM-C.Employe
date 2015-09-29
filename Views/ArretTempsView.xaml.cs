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

namespace GEM_C_E.Views
{
    /// <summary>
    /// Logique d'interaction pour ArretTempsView.xaml
    /// </summary>
    public partial class ArretTempsView : UserControl
    {
        public ArretTempsView()
        {
            InitializeComponent();
        }

        private void Arret_Click(object sender, RoutedEventArgs e)
        {
            IApplicationService applicationService = ServiceFactory.Instance.GetService<IApplicationService>();
            applicationService.ChangeView<DemarrageTempsView>(new DemarrageTempsView());
        }
    }
}
