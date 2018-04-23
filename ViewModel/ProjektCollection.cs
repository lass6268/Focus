using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ProjektCollection
    {
        public ObservableCollection<Project> Projekts { get; private set; }
        public ProjektCollection()
        {
            List<Project> projects = new List<Project>();
            DbConcection dbConcection = new DbConcection();
            projects = dbConcection.OverviewOverProjects();
            projects.Sort();
            ObservableCollection<Project> myCollection = new ObservableCollection<Project>(projects);
            Projekts = myCollection;
        }


    }
}
