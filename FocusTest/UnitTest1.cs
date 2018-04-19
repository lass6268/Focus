using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;



namespace FocusTest
{
    [TestClass]
    public class UnitTest1
    {
        Projektcheck projektcheck;
        Budgetcheck budgetcheck;
        DbConcection dbConcection;
        DateTime startdate;
        DateTime finaldate;
      [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();
            projektcheck = new Projektcheck();

            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);

        }

        [TestMethod]
        public void TestAddProject()
        {



            Assert.AreEqual(false, dbConcection.AddProject("Danske", 10, 100, startdate, finaldate));
            Assert.AreEqual(false,dbConcection.AddProject("Nordea Odense", 10,100, startdate,finaldate));
            
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


            Assert.AreEqual(false, project1.AddProjectToDatabase());
            Assert.AreEqual(false, project.AddProjectToDatabase());

        }

        [TestMethod]
        public void Testbudgetclass()
        {
            //Startdate og finaldate i DB skal fixes før den funker.

            Budget budget = new Budget(100, 0, startdate, finaldate);
            Budget budget1 = new Budget(100, 0, startdate, finaldate);


            Assert.AreEqual(false, budget1.AddBudgetToDatabase());
            Assert.AreEqual(false, budget1.AddBudgetToDatabase());

        }

        [TestMethod]
        public void Testprojekttest()
        {

            Projektcheck projectcheck = new Projektcheck();
            Assert.AreEqual("Final date is earlier than start date", projektcheck.Makeprojekt("Nordea Odense", 10, 100,  finaldate ,startdate));
            Assert.AreEqual("projekt has been made", projektcheck.Makeprojekt("Nordea Odense", 10, 100,startdate, finaldate));
            Assert.AreEqual("projekt has been made", projektcheck.Makeprojekt("Nordea Odense", 10, 0, startdate, finaldate));
            Assert.AreEqual("Min is Bigger then Max", projektcheck.Makeprojekt("Nordea Odense", 10, 1, startdate, finaldate));
        }

        [TestMethod]
        public void Testbudgettest()
        {
            
            Budgetcheck budgetcheck = new Budgetcheck();
            Assert.AreEqual("Final date is earlier than start date", budgetcheck.Makebudget(100, 0, finaldate, startdate));
            Assert.AreEqual("Budget has been made", budgetcheck.Makebudget(100, 0, startdate, finaldate));
            Assert.AreEqual("Budget has been made", budgetcheck.Makebudget(100, 50, startdate, finaldate));
            Assert.AreEqual("Current Budget must be smaller than total budget", budgetcheck.Makebudget(100, 100, startdate, finaldate));
        }

        [TestMethod]
        public void TestArchiveProject()
        {
            Assert.AreEqual(false,dbConcection.ArchiveProject("Danske",10,100,startdate,finaldate));
        }

    }
}
