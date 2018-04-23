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
 
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for ProjectOverviewMenu.xaml
    /// </summary>
    public partial class ProjectOverviewMenu : Window
    {
        public ProjectOverviewMenu()
        {
            InitializeComponent();
            DataContext = new ProjektCollection();
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjektMenu projektMenu = new ProjektMenu();
            projektMenu.Show();
            this.Close();
        }

       
        
    }
}
