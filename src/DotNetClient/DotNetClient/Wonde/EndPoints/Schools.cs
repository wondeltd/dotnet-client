using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonde.EndPoints
{
    public class Schools : BootstrapEndpoint
    {
        private string id;


        /// <summary>
        /// Object for Achievemnets
        /// </summary>
        public Achievements achievements;

        /// <summary>
        /// Object for Attendance
        /// </summary>
        public Attendance attendance;

        /// <summary>
        /// Object of AttendanceSumaries
        /// </summary>
        public AttendanceSumaries attendanceSumaries;

        /// <summary>
        /// Object of Behaviours
        /// </summary>
        public Behaviours behaviours;

        /// <summary>
        /// Object of Classes
        /// </summary>
        public Classes classes;

        /// <summary>
        /// Object of Contacts
        /// </summary>
        public Contacts contacts;

        /// <summary>
        /// Object of Counts
        /// </summary>
        public Counts counts;

        /// <summary>
        /// Object of Employees
        /// </summary>
        public Employees employees;

        /// <summary>
        /// Object of Groups
        /// </summary>
        public Groups groups;

        /// <summary>
        /// Object of Lessons
        /// </summary>
        public Lessons lessons;

        /// <summary>
        /// Object of LessonAttendance
        /// </summary>
        public LessonAttendance lessonAttendance;

        /// <summary>
        /// Object of MedicalConditions
        /// </summary>
        public MedicalConditions medicalConditions;

        /// <summary>
        /// Object of MedicalEvents
        /// </summary>
        public MedicalEvents medicalEvents;

        /// <summary>
        /// Object of Periods
        /// </summary>
        public Periods periods;

        /// <summary>
        /// Object of Photos
        /// </summary>
        public Photos photos;

        /// <summary>
        /// Object of Rooms
        /// </summary>
        public Rooms rooms;

        /// <summary>
        /// Object of Subjects
        /// </summary>
        public Subjects subjects;

        /// <summary>
        /// Object of Students
        /// </summary>
        public Students students;

        /// <summary>
        /// Object of Assessment
        /// </summary>
        public Assessment assessment;

        /// <summary>
        /// Object of Deletions
        /// </summary>
        public Deletions deletions;

        /// <summary>
        /// Object of Events
        /// </summary>
        public Events events;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="token">Api Token</param>
        /// <param name="url">School id if any</param>
        public Schools(string token, string id = "") : base(token, "schools/")
        {
            _token = token;
            if (id.Trim().Length > 0)
            {
                Uri = Uri + id + "/";
                this.id = id;


                achievements = new Achievements(token, Uri);
                assessment = new Assessment(token, Uri);
                attendance = new Attendance(token, Uri);
                attendanceSumaries = new AttendanceSumaries(token, Uri);
                behaviours = new Behaviours(token, Uri);
                classes = new Classes(token, Uri);
                contacts = new Contacts(token, Uri);
                counts = new Counts(token, Uri);
                deletions = new Deletions(token, Uri);
                employees = new Employees(token, Uri);
                events = new Events(token, Uri);
                groups = new Groups(token, Uri);
                lessons = new Lessons(token, Uri);
                lessonAttendance = new LessonAttendance(token, Uri);
                medicalConditions = new MedicalConditions(token, Uri);
                medicalEvents = new MedicalEvents(token, Uri);
                periods = new Periods(token, Uri);
                photos = new Photos(token, Uri);
                rooms = new Rooms(token, Uri);
                students = new Students(token, Uri);
                subjects = new Subjects(token, Uri);
            }

        }

        /// <summary>
        /// Return all pending schools
        /// </summary>
        /// <param name="includes">Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources</param>
        /// <returns>ResultIterator object to iterate through the results</returns>
        public ResultIterator pending(string[] includes = null, Dictionary<string, string> parameters = null)
        {
            ExtendedUri = "pending/";
            return all(includes, parameters);
        }

        /// <summary>
        /// Search available schools
        /// </summary>
        /// <param name="includes">Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources as KeyValuePair List</param>
        /// <returns>ResultIterator object to iterate through the results</returns>
        public ResultIterator search(string[] includes = null, Dictionary<string, string> parameters = null)
        {
            ExtendedUri = "all/";
            return all(includes, parameters);
        }

        /// <summary>
        /// Override the get method for single school fetch
        /// </summary>
        /// <param name="id">id of the resource</param>
        /// <param name="includes">Objects to include in result as string array. It will be added as parameter</param>
        /// <param name="parameters">Parameters for the resources</param>
        /// <returns>Object data of the single resource</returns>
        public new object get(string id, string[] includes = null, Dictionary<string, string> parameters = null)
        {
            ExtendedUri = "schools/";
            return base.get(id, includes, parameters);
        }

        
    }
}
