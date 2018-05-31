using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ProjektCollection
    {
        private int counter = 0;   
        public List<Project> Projects { get; private set; }
        public Project SelectedItem { get { return _selectedItem; } set { _selectedItem = value; } }
        private Project _selectedItem { get; set; }
        public static readonly ProjektCollection _instance = new ProjektCollection();
        DbConnection dbConnection = new DbConnection();
        private int _totalCurrent = 0;
        public int TotalCurrent
        {
            get
            {
                _totalCurrent = 0;
                foreach (var item in Projects)
                {
                    _totalCurrent += item.Optainedbudget;

                }
                return _totalCurrent;
            }
                set {

                foreach (var item in Projects)
                {
                    _totalCurrent += item.Optainedbudget;

                }
            } }

        public int TotalMax { get {
                counter = 0;
                foreach (var item in Projects)
                {
                    counter += item.MaxBudget;
                }
                return counter;
                    } }
        public ProjektCollection()
        {
            List<Project> projects = new List<Project>();
            
            Projects = dbConnection.OverviewOverProjects();
            Projects.Sort();
            
        }

      
        public void FindProjekt(object item)
        {
            SelectedItem = item as Project;
        }

        public string EditProjekt()
       {
            Checks checks = new Checks();
            string connected = string.Empty;
            
           
            
            
            if (checks.Makeprojekt(SelectedItem.ProjectName, SelectedItem.MinBudget, SelectedItem.MinBudget, SelectedItem.StartDate, SelectedItem.FinishDate, false) == true)
            {
                 connected = dbConnection.UpdateProject(SelectedItem);
            }
            
            else
            {
                return (checks.Display);
            }
            return connected;

       }
        public string ArchiveProject()
        {
           dbConnection.ArchiveProject(SelectedItem);
            

            return SelectedItem.ProjectName + " er nu arkiveret";
        }
        public string RecoverArchivedProject()
        {
            
            dbConnection.RecoverArchivedProject(SelectedItem.ProjectID);

            return SelectedItem.ProjectName + " er nu gendannet";
        }

        public void UpdateProjekts()
        {
            Projects = dbConnection.OverviewOverProjects();
            Projects.Sort();

        }

        public void ShowArchivedProjects()
        {
            Projects = dbConnection.GetArchivedProjects();
            Projects.Sort();
        }

        public bool UserFilter(object item, string txtFilter)
        {

            if(String.IsNullOrEmpty(txtFilter))
                return true;
            else
                return ((item as Project).ProjectName.IndexOf(txtFilter,StringComparison.OrdinalIgnoreCase) >= 0);
        }


    }
}
