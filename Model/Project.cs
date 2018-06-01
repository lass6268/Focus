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
        DbConnection dbConnection = new DbConnection();
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int BudgetObtained { get; set; }
        public int Optainedbudget { get { return dbConnection.GetObtainedBudget(ProjectID); } }
        public Employee Employee { get; set; }


        public Project(int _projektid, string _name, int _min, int _max, DateTime _start, DateTime _finish, Employee _employee)
        {
            ProjectID = _projektid;
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
            Employee = _employee;
        }

        public Project(string _name, int _min, int _max, DateTime _start, DateTime _finish)
        {
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
        }
        public Project(int _projectid, string _name, int _min, int _max, DateTime _start, DateTime _finish)
        {
            ProjectID = _projectid;
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
        }
        public Project(int _projectid, string _name, int _min, int _max, DateTime _start, DateTime _finish, int _budgetObtained)
        {
            ProjectID = _projectid;
            ProjectName = _name;
            MinBudget = _min;
            MaxBudget = _max;
            StartDate = _start;
            FinishDate = _finish;
            BudgetObtained = _budgetObtained;
        }
        public Project(string _name, int id)
        {
            ProjectName = _name;
            ProjectID = id;
            

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
        public class TestClass
        {
            static void Main(string[] args)
            {
            
            }
        }
    }
}
