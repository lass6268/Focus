using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Budgetcheck
    {
            public string Makebudget(int _BudgetTotal, int _CurrentBudget, DateTime _BudgetStartdate, DateTime _BudgetFinishdate)
            {


                int result = DateTime.Compare(_BudgetStartdate, _BudgetFinishdate);
                if (result > 0)
                    return "Final date is earlier than start date";


                else if (_CurrentBudget >= _BudgetTotal)
                {
                    return "Current Budget must be smaller than total budget";
                }
                else
                {
                    Budget budget = new Budget( _BudgetTotal, _CurrentBudget, _BudgetStartdate, _BudgetFinishdate);
                    return "Budget has been made";
                }

            }

    }
    
}
