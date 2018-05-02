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
    /// Interaction logic for BudgetMenu.xaml
    /// </summary>
    public partial class BudgetMenu : Window
    {
        public BudgetMenu()
        {
            InitializeComponent();
            BudgetContrainer budgetContrainer = new BudgetContrainer();
            BudgetDataGrid.DataContext = budgetContrainer;
            Project_ComboBox.DataContext = ProjektCollection._instance;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            projectOverviewMenu.Show();
            this.Close();
        }

        private void Project_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BudgetContrainer budgetContrainer = new BudgetContrainer();

            budgetContrainer.UpdateBudgetList();
            BudgetDataGrid.DataContext = budgetContrainer;
            
        }
    }
}
