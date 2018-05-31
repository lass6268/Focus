using System;
using System.Collections.Generic;
using System.Linq;
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
        ProjektCollection projektCollection;
        DataManegment dataManegment;
        BudgetContrainer budgetContrainer;
        [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();
            checks = new Checks();
           
            projektCollection = new ProjektCollection();
            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);
            medarbejder = new Employee("Erik",2);
            dataManegment = new DataManegment();
            budgetContrainer = new BudgetContrainer();

        }

       
        [TestMethod]
        public void TestBudgetListforProjekt()
        {
            
            Project project8 = new Project(167,"Virksomhed",1,1000,startdate,finaldate);
            List<Budget> budgets = dbConcection.GetBudgetForProjekt(project8);
            Assert.AreEqual(12, budgets.Count);
            Assert.AreEqual(0,budgets[1].CurrentBudget);

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

            DateTime date = DateTime.Parse("01 - 01 - 2018 00:00:00");
            List<Project> testlist = dbConcection.OverviewOverProjects();
            Assert.AreEqual(10, testlist.Count);
            Assert.AreEqual(date, testlist[8].StartDate);

            Assert.AreEqual(date, ProjektCollection._instance.Projects[9].StartDate);
            Assert.AreEqual(1, ProjektCollection._instance.Projects[9].StartDate.Day);
            ProjektCollection._instance.SelectedItem = ProjektCollection._instance.Projects[9];
            Assert.AreEqual(date, ProjektCollection._instance.SelectedItem.StartDate);
            Assert.AreEqual(1, ProjektCollection._instance.SelectedItem.StartDate.Day);
            Assert.AreEqual(1, ProjektCollection._instance.SelectedItem.StartDate.Month);
                       

           
         }
        //[TestMethod]
        //public void TestArchiveProject()
        //{
        //    dbConcection.ArchiveProject();
        //    List<Project> list = dbConcection.GetArchivedProjects();
        //    Assert.AreEqual(list[0].ProjectID,11);
        //}

        [TestMethod]
        public void TestOverviewOverArchivedProjects()
        {

            List<Project> archivedTestlist = dbConcection.GetArchivedProjects();
                
            Assert.AreEqual(1, archivedTestlist.Count);
            Assert.AreEqual("Mælk", archivedTestlist[0].ProjectName);
            Assert.AreEqual(10, archivedTestlist[0].MinBudget);
        }

        [TestMethod]
        public void Totalcurrent()
        {

            Assert.AreEqual(ProjektCollection._instance.TotalCurrent, 351);
            Assert.AreEqual(ProjektCollection._instance.TotalMax, 717);
        }

        [TestMethod]
        public void BudgetList()
        {
            Project project8 = new Project(8, "Virksomhed", 1, 1000, startdate, finaldate);
            Assert.AreEqual(12,dbConcection.GetBudgetForProjekt(project8).Count);

        }
        [TestMethod]

        public void TestSumafMax()
        {
            BudgetContrainer budgetContrainer = new BudgetContrainer();
            Assert.AreEqual(budgetContrainer.SumMaxBudget,12);

        }

        [TestMethod]
        public void GetEmployeeListTest()
        {

            Employee employee = new Employee("Karl", 4);
            Assert.AreEqual(dbConcection.GetEmployeesList().Count,12);
        }

        [TestMethod]
        public void GetTotalCurrentBudgetForEmployeesTest()
        {

            Employee employee = new Employee("Karl",4);
            List<Employee> list = dbConcection.GetCurrentBudgetForEmployees();
            Assert.AreEqual(list[1].TotalCurrent,5);
            Assert.AreEqual(list[1].ID,2);

            list = list.OrderByDescending(o => o.TotalCurrent).ToList();
            Assert.AreEqual(list[1].ID,5);
            Assert.AreEqual(list[0].TotalCurrent >= list[1].TotalCurrent,true);
        }
        [TestMethod]
        public void LeaderboardTest()
        {

            Assert.AreEqual(dataManegment.Leaderboard[0].TotalCurrent >= dataManegment.Leaderboard[1].TotalCurrent,true);
            Assert.AreEqual(dataManegment.Leaderboard[1].TotalCurrent >= dataManegment.Leaderboard[2].TotalCurrent,true);


        }
        [TestMethod]
        public void AverageCurrentBudgetTest()
        {
            Assert.AreEqual(dataManegment.AvgCurrent[0].AvgCurrent >= dataManegment.AvgCurrent[1].AvgCurrent,true);
            Assert.AreEqual(dataManegment.AvgCurrent[1].AvgCurrent >= dataManegment.AvgCurrent[2].AvgCurrent,true);
        }
        [TestMethod]
        public void emparray()
        {
            
            Assert.AreEqual(budgetContrainer.Employees[0].Name,"TEST");
            Assert.AreEqual(budgetContrainer.BudgetforEmployee[0].Project.ProjectName, "Virksomhed1");

            
        }
        [TestMethod]
        public void EmpList()
        {

            Assert.AreEqual(1, budgetContrainer.Employees[0].ID);
            Assert.AreEqual(1, budgetContrainer.SelectedEmpolyee.ID);


        }
    }
}
