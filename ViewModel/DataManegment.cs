using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class DataManegment
    {
        DbConnection dbConnection = new DbConnection();
        
        public List<Employee> Leaderboard { get { return dbConnection.GetCurrentBudgetForEmployees().OrderByDescending(o => o.TotalCurrent).ToList(); }
        
        }
        public List<Employee> AvgCurrent { get { return dbConnection.GetCurrentBudgetForEmployees().OrderByDescending(o => o.AvgCurrent).ToList(); } }

    }
}
