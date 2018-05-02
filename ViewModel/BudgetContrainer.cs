using System;
using System.Collections.Generic;
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

        public BudgetContrainer()
        {
            if (ProjektCollection._instance.SelectedItem == null)
            {
                Budgets = dbConcection.GetBudgetForProjekt(ProjektCollection._instance.Projekts[0]);
            }
            else
            {


                Budgets = dbConcection.GetBudgetForProjekt(ProjektCollection._instance.SelectedItem);
            }
        }
        public void UpdateBudgetList()
        {
            Budgets = dbConcection.GetBudgetForProjekt(ProjektCollection._instance.SelectedItem);
        }

        public string UpdateDb()
        {
            
            Checks checks = new Checks();
            string s = string.Empty;
            List<Budget> dblist = new List<Budget>();

            foreach (Budget budget in Budgets)
            {
                switch (checks.Checkbudgets(budget))
                {
                    case 0:
                        break;
                    case 1:
                        return "Felj, Databasen blev ikke opdateret da der er en felj i indtastningen";
                    case 2:
                        dblist.Add(budget);
                        break;

                    default:
                        break;
                }
  
            }
            dbConcection.UpdateBudget(dblist);
            s = dbConcection.UpdateBudget(dblist);
            return s;
        }
      
        
    }
}
