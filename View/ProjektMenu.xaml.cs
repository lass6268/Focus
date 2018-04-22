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

namespace View
{
    /// <summary>
    /// Interaction logic for ProjektMenu.xaml
    /// </summary>
    public partial class ProjektMenu:Window
    {
        public ProjektMenu()
        {
            InitializeComponent();
        }


        private void Return_btn_Click(object sender,RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


        private void CreateProject_btn_Click(object sender,RoutedEventArgs e)
        {
            OpretProjektMenu opretProjektMenu = new OpretProjektMenu();
            opretProjektMenu.Show();
            this.Close();
        }

        private void Overview_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            projectOverviewMenu.Show();
            this.Close();
        }
    }
}
