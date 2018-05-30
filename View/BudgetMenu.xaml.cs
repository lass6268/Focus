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
    /// Interaction logic for BudgetMenu.xaml
    /// </summary>
    public partial class BudgetMenu : Window
    {

        BudgetContrainer budgetContrainer = new BudgetContrainer();
        public BudgetMenu()
        {
            InitializeComponent();
            DataContext = budgetContrainer;
            //BudgetDataGrid.DataContext = budgetContrainer;
            Project_ComboBox.DataContext = ProjektCollection._instance;
            Selected_item_Maxbudget.DataContext = ProjektCollection._instance;
            Selected_item_Minbudget.DataContext = ProjektCollection._instance;


        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            ProjectOverviewMenu projectOverviewMenu = new ProjectOverviewMenu();
            projectOverviewMenu.Show();
            this.Close();
        }

        private void Project_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            budgetContrainer = new BudgetContrainer();

            budgetContrainer.UpdateBudgetList();
            DataContext = budgetContrainer;
           
            
        }

        private void UpdateBudget_Button_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show(budgetContrainer.UpdateDb(budgetContrainer.Budgets));
                
        }

       
       
    }
}
