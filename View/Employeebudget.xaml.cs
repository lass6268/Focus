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
    /// Interaction logic for Employeebudget.xaml
    /// </summary>
    public partial class Employeebudget : Window
    {
        BudgetContrainer budgetContrainer = new BudgetContrainer();
        BudgetContrainer budgetContrainer1;


        public Employeebudget()
        {
            
            InitializeComponent();
            DataContext = budgetContrainer;
            Emp_ComboBox.DataContext = budgetContrainer;
            budgetContrainer1 = new BudgetContrainer(budgetContrainer.SelectedEmpolyee);
        }

        private void Emp_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            budgetContrainer1 = new BudgetContrainer(budgetContrainer.SelectedEmpolyee);

            budgetContrainer.UpdateEmpList();
            DataContext = budgetContrainer1;
        }

        private void UpdateBudget_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(budgetContrainer.UpdateDb(budgetContrainer1.BudgetforEmployee));
        }
    }
}
