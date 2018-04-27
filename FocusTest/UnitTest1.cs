using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using ViewModel;



namespace FocusTest
{
    [TestClass]
    public class UnitTest1
    {
        Checks checks;
        DbConcection dbConcection;
        DateTime startdate;
        DateTime finaldate;
        Employee medarbejder;
        DBcommunicator dBcommunicator;
        ProjektCollection projektCollection;
        [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();
            checks = new Checks();
            dBcommunicator = new DBcommunicator();
            projektCollection = new ProjektCollection();
            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);
            medarbejder = new Employee();


        }

        
      

        [TestMethod]
        public void TestCreateBudget()
        {
            
            Assert.AreEqual(false, dbConcection.CreateBudget(1, 1, 100));
            Assert.AreEqual(false, dbConcection.CreateBudget(1, 1, 100));

        }
            

      


        [TestMethod]
        public void Testprojekttest()
        {
           
            Assert.AreEqual("Final date is earlier than start date", checks.Makeprojekt("Nordea Odense", 10, 100,  finaldate ,startdate,true));
            Assert.AreEqual("Project navn allerede i brug", checks.Makeprojekt("Nordea Odense", 10, 100,startdate, finaldate,true));
            Assert.AreEqual("Project navn allerede i brug", checks.Makeprojekt("Nordea Odense", 10, 0, startdate, finaldate,true));
            Assert.AreEqual("Min is Bigger then Max", checks.Makeprojekt("Nordea Odense", 10, 1, startdate, finaldate,true));
        }

        [TestMethod]
        public void Testbudgettest()
        {
            
          /* 
            Assert.AreEqual("Final date is earlier than start date", checks.Makebudget(100, 0, finaldate, medarbejder,_project));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 0, startdate, finaldate, medarbejder));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 50, startdate, finaldate, medarbejder));
            Assert.AreEqual("Current Budget must be smaller than total budget", checks.Makebudget(100, 100, startdate, finaldate, medarbejder));*/
        }

        [TestMethod]
        public void TestOverviewOverProjects()
        {

            List<Project> testlist = dBcommunicator.ListOfProjectsToDatabase();
            Assert.AreEqual(20, testlist.Count);
            Assert.AreEqual("Ikea", testlist[0].ProjectName);

            Assert.AreEqual("Ikea", projektCollection.Projekts[0].ProjectName);
        }
        [TestMethod]
        public void TestArchiveProject()
        {
            dbConcection.ArchiveProject(11);
            List<Project> list = dbConcection.GetArchivedProjects();
            Assert.AreEqual(list[0].ProjectID,11);            
        }

        [TestMethod]
        public void TestOverviewOverArchivedProjects()
        {
            List<Project> archivedTestlist = dBcommunicator.ListOfArchivedProjectsToDatabase();
            Assert.AreEqual(4, archivedTestlist.Count);
            Assert.AreEqual("Google2", archivedTestlist[2].ProjectName);
            Assert.AreEqual(0, archivedTestlist[3].Optainedbudget);
            
        }

        

    }
}
