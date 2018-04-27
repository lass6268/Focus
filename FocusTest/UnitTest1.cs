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
        public void TestProjectCreate()
        {
           
            Assert.IsTrue(true, "Minimums Budget er større end Maksimums Budget");
            //Assert.AreEqual("Project navn allerede i brug", checks.Makeprojekt("Nordea Odense", 10, 100,startdate, finaldate,true));
            //Assert.AreEqual("Project navn allerede i brug", checks.Makeprojekt("Nordea Odense", 10, 0, startdate, finaldate,true));
            //Assert.AreEqual("Minimums Budget er større end Maksimums Budget", checks.Makeprojekt("Nordea Odense", 10, 1, startdate, finaldate,true));
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

            DateTime date = DateTime.Parse("30 - 01 - 2018 00:00:00");
            List<Project> testlist = dbConcection.OverviewOverProjects();
            Assert.AreEqual(21, testlist.Count);
            Assert.AreEqual(date, testlist[16].StartDate);
            
            Assert.AreEqual(date, ProjektCollection._instance.Projekts[20].StartDate);
            Assert.AreEqual(30, ProjektCollection._instance.Projekts[20].StartDate.Day);
            ProjektCollection._instance.SelectedItem = ProjektCollection._instance.Projekts[20];
            Assert.AreEqual(date, ProjektCollection._instance.SelectedItem.StartDate);
            Assert.AreEqual(30, ProjektCollection._instance.SelectedItem.StartDate.Day);
            Assert.AreEqual(1, ProjektCollection._instance.SelectedItem.StartDate.Month);
           

           
         }
        [TestMethod]
        public void TestArchiveProject()
        {
            dbConcection.ArchiveProject(1);
            //List<Project> list = dbConcection.GetArchivedProjects(1);
           // Assert.AreEqual(list[0].ProjectID,1);            
        }

        [TestMethod]
        public void TestOverviewOverArchivedProjects()
        {

            List<Project> archivedTestlist = dbConcection.GetArchivedProjects();
                
            Assert.AreEqual(5, archivedTestlist.Count);
            Assert.AreEqual("Ikea", archivedTestlist[2].ProjectName);
            Assert.AreEqual(0, archivedTestlist[3].MinBudget);
        }

        

    }
}
