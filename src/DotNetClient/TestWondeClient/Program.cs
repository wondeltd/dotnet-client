using System;
using System.Timers;
using System.Collections.Generic;

namespace TestWondeClient
{
    class Program
    {
        static void Main(string[] args)
        {

            
            var client = new Wonde.Client(System.Configuration.ConfigurationManager.AppSettings["API_TOKEN"]);
            var school = client.school(System.Configuration.ConfigurationManager.AppSettings["SCHOOL_ID"]);

            var students = school.students.all();

            iterate(students);
            if (students.nextPage())
                iterate(students);
            if (students.previousPage())
                iterate(students);
        }

        static void iterate(Wonde.ResultIterator students)
        {
            foreach (object row in students)
            {
                var obj = (Dictionary<string, object>)row;
            }
        }
    }
}
