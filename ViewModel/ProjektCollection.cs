﻿using System;
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
        
        public List<Project> Projekts { get; private set; }
        public Project SelectedItem { get { return _selectedItem; } set { _selectedItem = value; } }
        private Project _selectedItem { get; set; }
        public static readonly ProjektCollection _instance = new ProjektCollection();
        DbConcection dbConcection = new DbConcection();

        public ProjektCollection()
        {
            List<Project> projects = new List<Project>();
            
            Projekts = dbConcection.OverviewOverProjects();
            Projekts.Sort();
            
        }
        public void FindProjekt(int index)
        {
            SelectedItem = Projekts[index];
        }

       public string EditProjekt()
       {
            DbConcection dbConcection = new DbConcection();
            string connected = dbConcection.UpdateProject(SelectedItem);

            if(connected !=string.Empty )
            {
                return (connected);
            }
            else
            {
                return (SelectedItem.ProjectName + " er nu updateret");
            }

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


    }
}
