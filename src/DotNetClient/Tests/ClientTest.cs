using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void testCreateClient()
        {
            var client = new Wonde.Client(System.Configuration.ConfigurationManager.AppSettings["API_TOKEN"]);
            var school = client.school(System.Configuration.ConfigurationManager.AppSettings["SCHOOL_ID"]);
            Assert.IsInstanceOfType(school, typeof(Wonde.EndPoints.Schools), "Object assertion fails.");
        }

        [TestMethod]
        public void tests_schools()
        {
            var client = new Wonde.Client(System.Configuration.ConfigurationManager.AppSettings["API_TOKEN"]);
            
            foreach (Dictionary<string, object> row in client.schools.all())
            {
                Assert.IsInstanceOfType(row["name"], typeof(string));
            }
        }
    }
}
