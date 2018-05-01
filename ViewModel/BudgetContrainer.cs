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
      
        
    }
}
