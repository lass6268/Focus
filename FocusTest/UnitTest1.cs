using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;



namespace FocusTest
{
    [TestClass]
    public class UnitTest1
    {
        DbConcection dbConcection;
        DateTime startdate;
        DateTime finaldate;
      [TestInitialize]
        public void TestInitialize()
        {
            dbConcection = new DbConcection();

            startdate = new DateTime(2018, 01, 01);

            finaldate = new DateTime(2018, 05, 01);

        }

        [TestMethod]
        public void TestAddProject()
        {



            Assert.AreEqual(true, dbConcection.AddProject("Danske", 10, 100, startdate, finaldate));
            Assert.AreEqual(false,dbConcection.AddProject("Nordea Odense", 10,100, startdate,finaldate));
            
        }

        [TestMethod]
        public void Testprojektclass()
        {


            Project project = new Project("Nordea Odense", 10, 100, startdate,finaldate);
            Project project1 = new Project("Danske Bank", 10, 100, startdate, finaldate);


            Assert.AreEqual(false, project1.AddProjectToDatabase());
            Assert.AreEqual(false, project.AddProjectToDatabase());

        }

    }
}
