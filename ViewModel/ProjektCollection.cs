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

        public ProjektCollection()
        {
            List<Project> projects = new List<Project>();
            DbConcection dbConcection = new DbConcection();
            projects = dbConcection.OverviewOverProjects();
            projects.Sort();
            Projekts = projects;
        }
        public void FindProjekt(int index)
        {
            SelectedItem = Projekts[index];
        }

       public string EditProjekt()
       {
            DbConcection dbConcection = new DbConcection();
            bool connected = dbConcection.UpdateProject(SelectedItem);

            if(connected == true )
            {
                return (SelectedItem.ProjectName + " er nu opdateret!");
            }
            else
            {
                return "Der er noget der gik galt, prøv igen";
            }

       }
        public string ArchiveProject()
        {
            DbConcection dbConcection = new DbConcection();
            dbConcection.ArchiveProject(SelectedItem.ProjectID);

            return SelectedItem.ProjectName + " er nu arkiveret";


        }


    }
}
