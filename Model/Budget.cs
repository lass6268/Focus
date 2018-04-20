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

        public int BudgetTotal { get; set; }
        public int CurrentBudget { get; set; }
        public DateTime BudgetStartdate { get; set; }
        public DateTime BudgetFinishdate { get; set; }
        public Medarbejder Medarbejder { get; set; }

        public Budget(int _BudgetTotal,int _CurrentBudget, DateTime _BudgetStartdate, DateTime _BudgetFinishdate, Medarbejder medarbejder)
        {
            BudgetTotal = _BudgetTotal;
            CurrentBudget = _CurrentBudget;
            BudgetStartdate = _BudgetStartdate;
            BudgetStartdate = _BudgetFinishdate;
            Medarbejder = medarbejder;
        }
        public bool AddBudgetToDatabase()
        {
            bool BudgetAdd = dbConcection.AddBudget(BudgetTotal, CurrentBudget, BudgetStartdate, BudgetFinishdate);
            return BudgetAdd;
        }

    }
}
