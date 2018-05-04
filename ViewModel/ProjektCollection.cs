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
        private int i = 0;   
        public List<Project> Projekts { get; private set; }
        public Project SelectedItem { get { return _selectedItem; } set { _selectedItem = value; } }
        private Project _selectedItem { get; set; }
        public static readonly ProjektCollection _instance = new ProjektCollection();
        DbConcection dbConcection = new DbConcection();
        private int _totalCurrent = 0;
        public int TotalCurrent
        {
            get
            {
                _totalCurrent = 0;
                foreach (var item in Projekts)
                {
                    _totalCurrent += item.Optainedbudget;

                }
                return _totalCurrent;
            }
                set {

                foreach (var item in Projekts)
                {
                    _totalCurrent += item.Optainedbudget;

                }
            } }

        public int TotalMax { get {
                i = 0;
                foreach (var item in Projekts)
                {
                    i += item.MaxBudget;
                }
                return i;
                    } }
        public ProjektCollection()
        {
            List<Project> projects = new List<Project>();
            
            Projekts = dbConcection.OverviewOverProjects();
            Projekts.Sort();
            
        }

        /*public ArchivedProjektCollection()
        {
            List<Project> archivedProjects = new List<Project>();

            archivedProjects = dbConcection.GetArchivedProjects();
            archivedProjects.Sort();

        }*/
        public void FindProjekt(object item)
        {
            SelectedItem = item as Project;
        }

       public string EditProjekt()
       {
            Checks checks = new Checks();
            string connected = string.Empty;
            
            //checks.Makeprojekt(SelectedItem.ProjectName, SelectedItem.MinBudget, SelectedItem.MinBudget, SelectedItem.StartDate, SelectedItem.FinishDate,false);
            DbConcection dbConcection = new DbConcection();
            
            if (checks.Makeprojekt(SelectedItem.ProjectName, SelectedItem.MinBudget, SelectedItem.MinBudget, SelectedItem.StartDate, SelectedItem.FinishDate, false) == true)
            {
                 connected = dbConcection.UpdateProject(SelectedItem);
            }
            
            else
            {
                return (checks.Display);
            }
            return connected;

       }
        public string ArchiveProject()
        {
            DbConcection dbConcection = new DbConcection();
            dbConcection.ArchiveProject(SelectedItem.ProjectID);

            return SelectedItem.ProjectName + " er nu arkiveret";


        }
        public void UpdateProjekts()
        {
            Projekts = dbConcection.OverviewOverProjects();
            Projekts.Sort();

        }

        public void ShowArchivedProjects()
        {
            Projekts = dbConcection.GetArchivedProjects();
            Projekts.Sort();
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
