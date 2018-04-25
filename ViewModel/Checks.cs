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
        public bool ProjektGoneToDB { get; set; }
        public string Makeprojekt(string _name, int _min, int _max, DateTime _start, DateTime _final)
        {
            string display = string.Empty;
            ProjektGoneToDB = false;
            int result1 = DateTime.Compare(_final, DateTime.Now);
            int result = DateTime.Compare(_start, _final);
            if (result > 0)
            {
                display =  "Slut dato er tidligere end Start Dato";
                
            }
            
            else if (result1 < 0)
            {
                display = "Slut dato er overstået";
                
            }
            else if (_name == string.Empty)
            {
                display = "Projekt Navn er tomt";
                
            }
            else if (_min == 0 && _max == 0)
            {
                display = "Min- og max budget er begge 0";
              
            }
            else if (_final == DateTime.MaxValue)
            {
                display = "Venligst sæt Slut Dato";
          
            }

            else if (_min > _max && _max != 0)
            {
                display = "Minimums Budget er større end Maksimums Budget";
               
            }
            else
            {

                Project projekt = new Project(_name, _min, _max, _start, _final);

                display =  dBcommunicator.AddProjectToDatabase(projekt);
                ProjektGoneToDB = true;

            }
                return display;
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
