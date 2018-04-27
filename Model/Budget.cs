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
        public int CurrentBudget { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        


        public Budget(Employee _Employee, Project _project, int _currentBudget)
        {

            CurrentBudget = _currentBudget;
            Employee = _Employee;
            Project = _project;
        }
    }
}
