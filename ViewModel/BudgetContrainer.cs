using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class BudgetContrainer
    {
        DbConcection dbConcection = new DbConcection();
        public List<Budget> Budgets { get; private set; }
        public int SumMaxBudget { get { return Budgets.Sum(x => x.MaxBudget); } }
        public int SumMinBudget { get { return Budgets.Sum(x => x.MinBudget); } }
        public int SumCurrentBudget { get { return Budgets.Sum(x => x.CurrentBudget); } }
        public Employee SelectedEmpolyee { get { return _selectedEmpolyee; } set { _selectedEmpolyee = value; } }
        private Employee _selectedEmpolyee { get; set; }

        public List<Employee> Employees { get; set; }
        
        public List<Budget> BudgetforEmployee { get; private set; }



        public BudgetContrainer()
        {
            if (ProjektCollection._instance.SelectedItem == null)
            {
                ProjektCollection._instance.SelectedItem = ProjektCollection._instance.Projects[0];

                
            }
            Budgets = dbConcection.GetBudgetForProjekt(ProjektCollection._instance.SelectedItem);

            Employees = dbConcection.GetEmployeesList();
            if (SelectedEmpolyee == null)
            {
               SelectedEmpolyee = Employees[0];
            }
            BudgetforEmployee = dbConcection.GetBudgetForEMP(SelectedEmpolyee);
        }
        public BudgetContrainer(Employee employee)
        {
            Employees = dbConcection.GetEmployeesList();
            BudgetforEmployee = dbConcection.GetBudgetForEMP(employee);

        }

       
        public void UpdateBudgetList()
        {
            Budgets = dbConcection.GetBudgetForProjekt(ProjektCollection._instance.SelectedItem);
        }
        public void UpdateEmpList()
        {
            BudgetforEmployee = dbConcection.GetBudgetForEMP(SelectedEmpolyee);

        }

        public string UpdateDb(List<Budget> _Budgets)
        {
            
            Checks checks = new Checks();
            string returnstring = string.Empty;
            List<Budget> dblist = new List<Budget>();
            if (Currenttotal() > ProjektCollection._instance.SelectedItem.MaxBudget)
            {
                return "Intastet total max budget er søttere end Projektets Max budget";
            }

            else
            {


                foreach (Budget budget in _Budgets)
                {
                    switch (checks.Checkbudgets(budget))
                    {
                        case 0:
                            break;
                        case 1:
                            return "Fejl, Databasen blev ikke opdateret da der er en felj i indtastningen";
                        case 2:
                            dblist.Add(budget);
                            break;

                        default:
                            break;
                    }

                }
                dbConcection.UpdateBudget(dblist);
                returnstring = dbConcection.UpdateBudget(dblist);
                return returnstring;
            }
        }
        int Currenttotal()
        {
            int total = 0;
            foreach (var item in Budgets)
            {
                total += item.MaxBudget;
            }

            return total;
        }


      
        
    }
}
