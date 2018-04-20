using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class Checks
    {
        DBcommunicator dBcommunicator = new DBcommunicator();
        public string Makeprojekt(string _name, int _min, int _max, DateTime _start, DateTime _final)
        {


            int result = DateTime.Compare(_start, _final);
            if (result > 0)
                return "Final date is earlier than start date";


            else if (_min > _max && _max != 0)
            {
                return "Min is Bigger then Max";
            }
            else
            {
                
                Project projekt = new Project(_name, _min, _max, _start, _final);

                dBcommunicator.AddProjectToDatabase(projekt);
                return "projekt has been made";
            }

        }

        public string Makebudget(int _BudgetMin, int _BudgetMax, Employee _Employee, Project _project)
        {

            if (_BudgetMin >= _BudgetMax)
            {
                return "Current Budget must be smaller than total budget";
            }
            else
            {
                Budget budget = new Budget(_BudgetMin, _BudgetMax, _Employee,  _project);
                dBcommunicator.AddBudgetToDatabase(budget);
                return "Budget has been made";
            }

        }



    }
}
