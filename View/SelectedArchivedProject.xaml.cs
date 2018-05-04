using System;
using System.Collections;
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
    /// Interaction logic for SelectedArchivedProject.xaml
    /// </summary>
    public partial class SelectedArchivedProject : Window
    {
        public SelectedArchivedProject()
        {
            InitializeComponent();

            DataContext = ProjektCollection._instance;
            BudgetContrainer budgetContrainer = new BudgetContrainer();

        }

        private void Selected_Return_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Recover_btn_Click(object sender, RoutedEventArgs e)
        {
            string recoverArchivedProject = ProjektCollection._instance.RecoverArchivedProject();
            if (MessageBox.Show("Arkiver projekt", "Vil du gendanne dette projekt?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Projektet blev ikke gendannet");

            }
            else
            {
                MessageBox.Show(recoverArchivedProject);

                this.Close();

            }
        }
    }
}
