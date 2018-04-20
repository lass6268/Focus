using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Budget
    {
        

        public int BudgetTotal { get; set; }
        public int CurrentBudget { get; set; }
        public DateTime BudgetStartdate { get; set; }
        public DateTime BudgetFinishdate { get; set; }
        public Employee Employee { get; set; }

        public Budget(int _BudgetTotal,int _CurrentBudget, DateTime _BudgetStartdate, DateTime _BudgetFinishdate, Employee medarbejder)
        {
            BudgetTotal = _BudgetTotal;
            CurrentBudget = _CurrentBudget;
            BudgetStartdate = _BudgetStartdate;
            BudgetStartdate = _BudgetFinishdate;
            Employee = medarbejder;
        }
     

    }
}
