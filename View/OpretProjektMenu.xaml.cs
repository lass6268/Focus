using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for OpretProjektMenu.xaml
    /// </summary>
    public partial class OpretProjektMenu:Window
    {
        public OpretProjektMenu()
        {
            InitializeComponent();
        }

        private void FinalCreateProjekt_btn_Click(object sender,RoutedEventArgs e)
        {
            string projectName = Name_txtbox.Text;
            int minimum = int.Parse(Min_txtbox.Text);
            int maximum = int.Parse(Max_txtbox.Text);
            DateTime startDate = DateTime.Parse(StartDate_txtbox.Text);
            DateTime finishDate = DateTime.Parse(FinishDate_txtbox.Text);

            Checks checks = new Checks();
            string s = checks.Makeprojekt(projectName,minimum,maximum,startDate,finishDate);
            MessageBox.Show(s);
          
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            projectOverviewMenu.Show();
            this.Close();
        }
    }
}
