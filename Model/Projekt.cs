using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Projekt
    {

        public string Name { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }

        public Projekt(string _Name, int _minBudget, int _maxBudget, DateTime startdate, DateTime _finaldate)
        {
            Name = _Name;
            MinBudget = _minBudget;
            MaxBudget = _maxBudget;
            StartDate = startdate;
            FinalDate = _finaldate;
        }






    }
}
