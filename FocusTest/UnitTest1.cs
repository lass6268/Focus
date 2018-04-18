using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;



namespace FocusTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddProject()
        {
            Model.DbConcection dbConcection = new DbConcection();
            DateTime startdate = new DateTime(2018 - 01 - 01);
            DateTime finaldate = new DateTime(2018 - 05 - 01);
            Assert.AreEqual(true,dbConcection.AddProject("Nordea Odense", 10,100, startdate,finaldate));
            
        }
    }
}
