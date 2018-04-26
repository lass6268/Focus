using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

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

        

        public class TestClass
        {
            public static void Main(string[] args)
            {
                CultureInfo enGB = new CultureInfo("en-GB");
                string dateString;
                DateTime dateValue;

                dateString = "26/01/2011 00:14:00";
                DateTime.TryParseExact(dateString, "g", enGB, DateTimeStyles.None, out dateValue);
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
