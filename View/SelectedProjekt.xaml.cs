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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = ProjektCollection._instance.EditProjekt();
            MessageBox.Show(s);
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
       
    }
}
