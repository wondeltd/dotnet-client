using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wonde;
using System.Collections;
using System.Collections.Generic;
using Wonde.EndPoints;
namespace Tests
{
    [TestClass]
    public class EndPointsTests
    {
        private Schools school;
        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        [TestInitialize]
        public void initialize()
        {
            var client = new Client(System.Configuration.ConfigurationManager.AppSettings["API_TOKEN"]);
            school = client.school(System.Configuration.ConfigurationManager.AppSettings["SCHOOL_ID"]);
            client = null;
        }

        [TestCleanup]
        public void cleanup()
        {
            school = null;
        }

        

        [TestMethod]
        public void tests_students()
        {
            var result = school.students.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 60, "Students count fails.");
        }

        [TestMethod]
        public void tests_employees()
        {
            var result = school.employees.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Employees count fails.");
        }

        [TestMethod]
        public void tests_contacts()
        {
            var result = school.contacts.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Contacts count fails.");
        }

        [TestMethod]
        public void tests_subjects()
        {
            var result = school.subjects.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Subjects count fails.");
        }

        [TestMethod]
        public void tests_rooms()
        {
            var result = school.rooms.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Rooms count fails.");
        }

        [TestMethod]
        public void tests_groups()
        {
            var result = school.groups.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Groups count fails.");
        }

        [TestMethod]
        public void tests_classes()
        {
            var result = school.classes.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Classes count fails.");
        }

        [TestMethod]
        public void tests_events()
        {
            var result = school.events.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Events count fails.");
        }

        [TestMethod]
        public void tests_medical_events()
        {
            var result = school.medicalEvents.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Medical events count fails.");
        }

        [TestMethod]
        public void tests_medical_conditions()
        {
            var result = school.medicalConditions.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Medical conditions count fails.");
        }

        [TestMethod]
        public void tests_periods()
        {
            var result = school.periods.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Periods count fails.");
        }

        [TestMethod]
        public void tests_lessons()
        {
            var result = school.lessons.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Lessons count fails.");
        }

        [TestMethod]
        public void tests_achievements()
        {
            var result = school.achievements.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Achievements count fails.");
        }

        [TestMethod]
        public void tests_behaviours()
        {
            var result = school.behaviours.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Behaviours count fails.");
        }

        [TestMethod]
        public void tests_attendance_sumaries()
        {
            var result = school.attendanceSumaries.all();
            Assert.IsNotNull(result);
            List<object> items = new List<object>();
            foreach (Dictionary<string, object> row in result)
            {
                items.Add(row);
                Assert.IsNotNull(row);
                Assert.IsInstanceOfType(row, typeof(Dictionary<string, object>));
                Assert.IsTrue(row.Count > 0);
            }
            context.WriteLine("Total count: {0}", items.Count);
            Assert.IsTrue(items.Count > 10, "Attendance Sumaries count fails.");
        }
    }
}
