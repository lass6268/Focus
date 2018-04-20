using System;
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
        Medarbejder medarbejder;
        [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();
            checks = new Checks();

            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);
            medarbejder = new Medarbejder();

        }

        [TestMethod]
        public void TestAddProject()
        {



           // Assert.AreEqual(false, dbConcection.AddProject("Danske", 10, 100, startdate, finaldate));
           // Assert.AreEqual(false,dbConcection.AddProject("Nordea Odense", 10,100, startdate,finaldate));
            
        }

        [TestMethod]
        public void TestAddBudget()
        {
            
            Assert.AreEqual(false, dbConcection.AddBudget(100, 0, startdate, finaldate));
            Assert.AreEqual(false, dbConcection.AddBudget(100, 0, startdate, finaldate));

        }

        [TestMethod]
        public void Testprojektclass()
        {


            Project project = new Project("Nordea Odense", 10, 100, startdate,finaldate);
            Project project1 = new Project("Danske Bank", 10, 100, startdate, finaldate);


           // Assert.AreEqual(false, project1.AddProjectToDatabase());
           // Assert.AreEqual(false, project.AddProjectToDatabase());

        }

        [TestMethod]
        public void Testbudgetclass()
        {
            //Startdate og finaldate i DB skal fixes før den funker.

            Budget budget = new Budget(100, 0, startdate, finaldate,medarbejder);
            Budget budget1 = new Budget(100, 0, startdate, finaldate,medarbejder);


            //Assert.AreEqual(false, budget1.AddBudgetToDatabase());
            //Assert.AreEqual(false, budget1.AddBudgetToDatabase());

        }

        [TestMethod]
        public void Testprojekttest()
        {

            
            Assert.AreEqual("Final date is earlier than start date", checks.Makeprojekt("Nordea Odense", 10, 100,  finaldate ,startdate));
            Assert.AreEqual("projekt has been made", checks.Makeprojekt("Nordea Odense", 10, 100,startdate, finaldate));
            Assert.AreEqual("projekt has been made", checks.Makeprojekt("Nordea Odense", 10, 0, startdate, finaldate));
            Assert.AreEqual("Min is Bigger then Max", checks.Makeprojekt("Nordea Odense", 10, 1, startdate, finaldate));
        }

        [TestMethod]
        public void Testbudgettest()
        {
            
           
            Assert.AreEqual("Final date is earlier than start date", checks.Makebudget(100, 0, finaldate, startdate, medarbejder));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 0, startdate, finaldate, medarbejder));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 50, startdate, finaldate, medarbejder));
            Assert.AreEqual("Current Budget must be smaller than total budget", checks.Makebudget(100, 100, startdate, finaldate, medarbejder));
        }

        [TestMethod]
        public void TestArchiveProject()
        {
           // Assert.AreEqual(false,dbConcection.ArchiveProject("Danske",10,100,startdate,finaldate));
        }

    }
}
