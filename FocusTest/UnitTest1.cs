using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;



namespace FocusTest
{
    [TestClass]
    public class UnitTest1
    {
        Projektcheck projektcheck;
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
        public void Testprojektclass()
        {


            Project project = new Project("Nordea Odense", 10, 100, startdate,finaldate);
            Project project1 = new Project("Danske Bank", 10, 100, startdate, finaldate);


            Assert.AreEqual(false, project1.AddProjectToDatabase());
            Assert.AreEqual(false, project.AddProjectToDatabase());

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

    }
}
