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
        private int _CurrentBudget;
        public int CurrentBudget { get { return _CurrentBudget; } set {
                try
                {
                    _CurrentBudget = value;
                }
                catch (Exception)
                {
                    _CurrentBudget = 0;
                   
                }
                
            }  }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        private int _MinBudget;
        public int MinBudget
        {
            get { return _MinBudget; }
            set
            {
                try
                {
                    _MinBudget = value;
                }
                catch (Exception)
                {
                    _MinBudget = 0;

                }

            }
        }
        private int _MaxBudget;
        public int MaxBudget
        {
            get { return _MaxBudget; }
            set
            {
                try
                {
                    _MaxBudget = value;
                }
                catch (Exception)
                {
                    _MaxBudget = 0;

                }

            }
        }



        public Budget(Employee _Employee, Project _project, int _currentBudget,int _minbudget,int _maxbudget)
        {

            CurrentBudget = _currentBudget;
            Employee = _Employee;
            Project = _project;
            MinBudget = _minbudget;
            MaxBudget = _maxbudget;

        }
       
    }
}
