using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    class DBcommunicator
    {
        DbConcection dbConcection = new DbConcection();
        public void AddProjectToDatabase(Project project)
        {
            dbConcection.AddProject(project.ProjectName, project.MinBudget, project.MaxBudget, project.StartDate, project.FinishDate);

        }


        public void ArchiveProjectToDatabase(Project project)
        {
            dbConcection.ArchiveProject(project.ProjectName, project.MinBudget, project.MaxBudget, project.StartDate,project.FinishDate);

        }


        public void AddBudgetToDatabase(Budget budget)
        {
           //dbConcection.AddBudget(budget.BudgetTotal, budget.CurrentBudget, budget.BudgetStartdate, budget.BudgetFinishdate);
          
        }

    }
}
