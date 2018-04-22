using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class DBcommunicator
    {
        DbConcection dbConcection = new DbConcection();
        public string AddProjectToDatabase(Project project)
        {
            return dbConcection.AddProject(project.ProjectName, project.MinBudget, project.MaxBudget, project.StartDate, project.FinishDate);

        }


        public void ArchiveProjectToDatabase(Project project, Budget budget)
        {
            dbConcection.ArchiveProject(project.ProjectName, project.MinBudget, project.MaxBudget, project.StartDate,project.FinishDate, budget.CurrentBudget);

        }


        public void AddBudgetToDatabase(Budget budget)
        {
           //dbConcection.AddBudget(budget.BudgetTotal, budget.CurrentBudget, budget.BudgetStartdate, budget.BudgetFinishdate);
          
        }

        public List<String> ListOfProjectsToDatabase()
        {
            return dbConcection.OverviewOverProjects();
        }
    }
}
