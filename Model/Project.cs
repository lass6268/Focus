using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Project
    {
        DbConcection dbConcection = new DbConcection();
        public string Name { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }

        public Project(string _name, int _min, int _max, DateTime _start, DateTime _final)
        {
           

            Name = _name;
            Min = _min;
            Max = _max;
            StartDate = _start;
            FinalDate = _final;
        }


        public bool AddProjectToDatabase()
        {
            bool bo = dbConcection.AddProject(Name, Min, Max, StartDate, FinalDate);
            return bo;
        }


        class TestClass
        {
            static void Main(string[] args)
            {
               
            }
        }
    }
}
