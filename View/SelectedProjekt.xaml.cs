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
    /// Interaction logic for SelectedProjekt.xaml
    /// </summary>
    public partial class SelectedProjekt : Window
    {
        public SelectedProjekt()
        {
            InitializeComponent();
            
            DataContext = ProjektCollection._instance;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            ProjektCollection._instance.EditProjekt();
            Tryinputs();
           
        }

        private void ArchiveProject_btn_Click(object sender,RoutedEventArgs e)
        {
            string archiveProject =ProjektCollection._instance.ArchiveProject();
            if(MessageBox.Show("Arkiver projekt", "Vil du arkivere dette projekt?", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.No)
            {
                MessageBox.Show("Projektet blev ikke arkiveret");

            }
            else
            {
                MessageBox.Show(archiveProject);

            }

        }

        private void Selected_Return_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Tryinputs()
        {
            bool check = false;

            string s = string.Empty;
            Checks checks = new Checks();

            try
            {
                string projectName = Sel_Name_txtbox.Text;
                int minimum = int.Parse(Sel_Min_txtbox.Text);
                int maximum = int.Parse(Sel_Max_txtbox.Text);
                DateTime startDate = DateTime.Parse(Sel_StartDate_txtbox.Text);
                DateTime finishDate = DateTime.Parse(Sel_FinishDate_txtbox.Text);


                
                if (checks.Makeprojekt(projectName, minimum, maximum, startDate, finishDate, false) == false)
                {
                    throw new Exception(checks.Display);
                    
                }
                s = ProjektCollection._instance.EditProjekt();
                check = true;
            }
            catch (Exception e)
            {

                s = e.Message;
                check = false;
            }
            MessageBox.Show(s);
            return check;

        }
    }
}
