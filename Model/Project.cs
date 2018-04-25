using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Project : IComparable<Project>
    {
        DbConcection dbConection = new DbConcection();
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int Optainedbudget { get { return dbConection.GetObtainedBudget(ProjectID); }  }


        public Project(string _name, int _min, int _max, DateTime _start, DateTime _finish)
        {
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
        }
        public Project(int _projektid,string _name, int _min, int _max, DateTime _start, DateTime _finish)
        {
            ProjectID = _projektid;
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
        }

        

        class TestClass
        {
            static void Main(string[] args)
            {
               
            }
        }

        public int CompareTo(Project other)
        {
            if (other == null)
            {
                return 1;
            }
                
            else
            {
                return this.ProjectID.CompareTo(other.ProjectID);
            }
                
        }
    }
}
