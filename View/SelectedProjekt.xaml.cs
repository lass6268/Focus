using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SelectedProjekt.xaml
    /// </summary>
    public partial class SelectedProjekt : Window
    {
        public SelectedProjekt()
        {
            InitializeComponent();
            
            DataContext = ProjektCollection._instance;
            BudgetContrainer budgetContrainer = new BudgetContrainer();
            BudgetListview.DataContext = budgetContrainer;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            //ProjektCollection._instance.EditProjekt();
            
            Tryinputs(Sel_Name_txtbox.Text, Sel_Min_txtbox.Text, Sel_Max_txtbox.Text, Sel_StartDate_txtbox.Text, Sel_FinishDate_txtbox.Text);
           
        }

        private void ArchiveProject_btn_Click(object sender,RoutedEventArgs e)
        {
            string archiveProject = ProjektCollection._instance.ArchiveProject();
            if(MessageBox.Show("Arkiver projekt", "Vil du arkivere dette projekt?", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.No)
            {
                MessageBox.Show("Projektet blev ikke arkiveret");

            }
            else
            {  
                MessageBox.Show(archiveProject);
                ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
                projectOverviewMenu.Show();
                this.Close();
                

            }

        }

        private void Selected_Return_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            projectOverviewMenu.Show();
        }
        //Skal i Viewmodel
        private void Tryinputs(string name,string min, string max,string startdate, string Finishdate)
        {
            

            string s = string.Empty;
            Checks checks = new Checks();

            try
            {
               
                string projectName = name;
                int minimum = int.Parse(min);
                int maximum = int.Parse(max);
                DateTime startDate = DateTime.Parse(startdate);
                DateTime finishDate = DateTime.Parse(Finishdate);
                bool checker = checks.Makeprojekt(projectName, minimum, maximum, startDate, finishDate, false);
                

                if (checker == false)
                {
                    throw new Exception(checks.Display);

                }
                else
                {
                    
                    s = ProjektCollection._instance.EditProjekt();
                   
                }
                }
             catch (Exception e)
            {

                s = e.Message;
                
            }
            MessageBox.Show(s);
            

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-]+");
            e.Handled = regex.IsMatch(e.Text);

        }


    }
}
