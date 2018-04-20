using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Project
    {
       
        public string ProjectName { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }



        public Project(string _name, int _min, int _max, DateTime _start, DateTime _final)
        {
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinalDate = _final;
        }
      


      



        class TestClass
        {
            static void Main(string[] args)
            {
               
            }
        }
    }
}
