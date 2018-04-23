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
        ProjektCollection projektCollection = new ProjektCollection();

        public string AddProjectToDatabase(Project project)
        {
            return dbConcection.AddProject(project.ProjectName, project.MinBudget, project.MaxBudget, project.StartDate, project.FinishDate);

        }

        //public void EditProject()
        //{
        //    projektCollection.Projekts
        //}


       


        public void AddBudgetToDatabase(Budget budget)
        {
           //dbConcection.AddBudget(budget.BudgetTotal, budget.CurrentBudget, budget.BudgetStartdate, budget.BudgetFinishdate);
          
        }

        public List<Project> ListOfProjectsToDatabase()
        {
            
            List<Project> projects = new List<Project>();
            projects= dbConcection.OverviewOverProjects();
            projects.Sort();
            return projects;
        }
    }
}
