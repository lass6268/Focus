using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Budget
    {
        DbConcection dbConcection = new DbConcection();

        public int TotalBudget { get; set; }
        public int CurrentBudget { get; set; }
        public DateTime BudgetStartDate { get; set; }
        public DateTime BudgetEndDate { get; set; }
        public DateTime BudgetCurrentDate { get; set; }


        public Budget (int _TotalBudget, int _BudgetCurrentDate, DateTime _BudgetStartDate, DateTime _BugdetEndDate)
        {
            TotalBudget = _TotalBudget;
            CurrentBudget = _BudgetCurrentDate;
            BudgetCurrentDate = _BudgetCurrentDate;
        }

        public bool AddBudgetToDatabase()
        {
            bool AddBudget = dbConcection.AddBudget(TotalBudget, CurrentBudget, BudgetCurrentDate);
            return AddBudget;
        }

    }
}
