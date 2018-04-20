using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Budget 
    { 
        public int CurrentBudget { get; set; }
        public int BudgetMin { get; set; }
        public int BudgetMax { get; set; }
        public Employee Employee { get; set; }
        public Project project { get; set; }

        public Budget(int _BudgetMin, int _BudgetMax, Employee _Employee, Project _project)
        {
           
            BudgetMin = _BudgetMin;
            BudgetMax = _BudgetMax;
            Employee = _Employee;
            project = _project;
        }
    }
}
