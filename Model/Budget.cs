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
        public DateTime BudgetMin { get; set; }
        public DateTime BudgetMax { get; set; }
        public Employee Employee { get; set; }

        public Budget(int _CurrentBudget, DateTime _BudgetMin, DateTime _BudgetMax, Employee _Employee)
        {
            CurrentBudget = _CurrentBudget;
            BudgetMin = _BudgetMin;
            BudgetMax = _BudgetMax;
            Employee = _Employee;
        }
    }
}
