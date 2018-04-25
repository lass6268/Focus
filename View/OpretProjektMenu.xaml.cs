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
using System.Text.RegularExpressions;


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
            string projectName = string.Empty;
            int minimum = 0;
            int maximum = 0;
            DateTime startDate = DateTime.Now;
            DateTime finishDate = DateTime.MaxValue;

            projectName = Name_txtbox.Text;
            minimum = int.Parse(Min_txtbox.Text);
            maximum = int.Parse(Max_txtbox.Text);
            startDate = DateTime.Parse(StartDate_txtbox.Text);
            finishDate = DateTime.Parse(FinishDate_txtbox.Text);

            Checks checks = new Checks();
            string s = checks.Makeprojekt(projectName,minimum,maximum,startDate,finishDate);
            
            MessageBox.Show(s);
            openotherwindow();
            
            
          
        }

        private void openotherwindow()
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            
            projectOverviewMenu.Show();
            this.Close();
        }

        private void Return_btn_Click(object sender, RoutedEventArgs e)
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();

            projectOverviewMenu.Show();
            this.Close();
        }

        private void NumberValidationTextBox(object sender,TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
    }
}
