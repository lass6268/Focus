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
            {
                return "Slut dato er tidligere end Start Dato";
            }
            result = DateTime.Compare(_final, DateTime.Now);
            if (result < 0)
            {
                return "Slut dato er overstået";
            }
            if (_name == string.Empty)
            {
                return "Projekt Navn er tomt";
            }
            if (_min == 0 && _max == 0)
            {
                return "Min- og max budget er begge 0";
            }
            if (_final == DateTime.MaxValue)
            {
                return "Venligst sæt Slut Dato";
            }

            else if (_min > _max && _max != 0)
            {
                return "Minimums Budget er større end Maksimums Budget";
            }
            else
            {

                Project projekt = new Project(_name, _min, _max, _start, _final);

                String display = dBcommunicator.AddProjectToDatabase(projekt);
                return display;
            }

        }

        public string Makebudget(int _BudgetMin, int _BudgetMax, Employee _Employee, Project _project)
        {

            if (_BudgetMin >= _BudgetMax)
            {
                return "Nuværende Budget skal være mindre end det Totale Budget";
            }
            else
            {
                Budget budget = new Budget(_BudgetMin, _BudgetMax, _Employee,  _project);
                dBcommunicator.AddBudgetToDatabase(budget);
                return "Budget er oprettet!";
            }

        }
    }
}
