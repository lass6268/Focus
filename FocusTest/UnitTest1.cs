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
        Employee medarbejder;
        [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();
            checks = new Checks();

            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);
            medarbejder = new Employee();

        }

        
      

        [TestMethod]
        public void TestAddBudget()
        {
            
            Assert.AreEqual(false, dbConcection.AddBudget(100, 0, startdate, finaldate));
            Assert.AreEqual(false, dbConcection.AddBudget(100, 0, startdate, finaldate));

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
            
          /* 
            Assert.AreEqual("Final date is earlier than start date", checks.Makebudget(100, 0, finaldate, medarbejder,_project));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 0, startdate, finaldate, medarbejder));
            Assert.AreEqual("Budget has been made", checks.Makebudget(100, 50, startdate, finaldate, medarbejder));
            Assert.AreEqual("Current Budget must be smaller than total budget", checks.Makebudget(100, 100, startdate, finaldate, medarbejder));*/
        }

      
      

    }
}
