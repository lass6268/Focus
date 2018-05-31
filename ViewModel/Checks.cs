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
        
        DbConnection dbConnection = new DbConnection();
        public string Display { get; set; }
        public bool Makeprojekt(string _name, int _min, int _max, DateTime _start, DateTime _final,bool newproject)
        {
            
            bool ProjectGoneToDB = false;
            int result = DateTime.Compare(_start, _final);
            int result1 = DateTime.Compare(_final, DateTime.Now);
           
            if (result > 0)
            {
                Display =  "Slut dato er tidligere end Start Dato";
                
            }
            
            else if (result1 < 0)
            {
                Display = "Slut dato er overstået";
                
            }
            else if (_name == string.Empty)
            {
                Display = "Projekt Navn er tomt";
                
            }
            else if (_min == 0 && _max == 0)
            {
                Display = "Min- og max budget er begge 0";
              
            }
            else if (_final == DateTime.MaxValue)
            {
                Display = "Venligst sæt Slut Dato";
          
            }

            else if (_min > _max && _max != 0)
            {
                Display = "Minimums Budget er større end Maksimums Budget";
               
            }

            else if(newproject == true)
            {

                Project projekt = new Project(_name, _min, _max, _start, _final);

                Display = dbConnection.AddProject(projekt); 
                ProjectGoneToDB = true;

            }
            else if (newproject == false)
            {
                ProjectGoneToDB = true;
               
            }
            return ProjectGoneToDB;
        }

      public int Checkbudgets(Budget budget)
      {
            if (budget.MinBudget == 0 && budget.MaxBudget == 0)
            {
                return 0;
            }
            else if (budget.MaxBudget == 0)
            {
                return 2;
            }
            else if (budget.MinBudget > budget.MaxBudget)
            {
                return 1;

            }
            else return 2;     
      }
    }
}
