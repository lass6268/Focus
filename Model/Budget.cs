using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Budget 
    {
        DbConcection dbConcection = new DbConcection();
        public int CurrentBudget { get; set; }
        public int BudgetMin { get; set; }
        public int BudgetMax { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public int Optainedbudget { get; set; }


        public Budget(int _BudgetMin, int _BudgetMax, Employee _Employee, Project _project)
        {
           
            BudgetMin = _BudgetMin;
            BudgetMax = _BudgetMax;
            Employee = _Employee;
            Project = _project;
        }
    }
}
