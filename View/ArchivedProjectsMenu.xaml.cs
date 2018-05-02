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
    /// Interaction logic for ArchivedProjectsMenu.xaml
    /// </summary>
    public partial class ArchivedProjectsMenu : Window
    {
        public ArchivedProjectsMenu()
        {
            InitializeComponent();
            DataContext = ProjektCollection._instance;
            ProjektCollection._instance.ShowArchivedProjects();
        }

        private void Archived_Return_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Back_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();         
        }
    }
}
