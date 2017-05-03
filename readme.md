# Wonde .NET Client
Documentation https://wonde.com/docs/api/1.0/

## Installation

Target .Net Framework 4.6.1

Using Nuget:

```Nuget Package Manager Console
Not yet added to Nuget.org
```

## Endpoints

### Client
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");
```
VB.Net
```VB
Dim client as New Wonde.Client("TOKEN_GOES_HERE")
```


### Schools
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

// Loop through the schools your account has access to
foreach (Dictionary<string, object> school in client.schools.all()) {
    // Display school name
    Console.WriteLine("School's name is {0}, school["name"]);
}

```
VB.Net
```VB
Dim client as New Wonde.Client("TOKEN_GOES_HERE")

' Loop through the schools your account has access to
For Each school as Dictionary(of String, Object) in client.schools.all()
	' Display school name
	Console.WriteLine("School's name is {0}, school("name"))
Next school

```

### Single School
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

// Get single school
var school = client.schools.get("SCHOOL_ID_GOES_HERE");
```
VB.Net
```VB
Dim client as New Wonde.Client("TOKEN_GOES_HERE")

' Get single school
Dim school As Variant
school = client.schools.get("SCHOOL_ID_GOES_HERE")
```

### Pending Schools
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

foreach (Dictionary<string, object> school in client.schools.pending()) {
    // Display school name
    Console.WriteLine("Pending School name {0}", school["name"]);
}
```
VB.Net
```VB
Dim client as New Wonde.Client("TOKEN_GOES_HERE")

For Each school as Dictionary(of String, Object) in client.schools.pending()
    ' Display school name
    Console.WriteLine("Pending School name {0}", school("name"))
Next school
```

### Search Schools
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

// Search for schools with a postcode starting CB21
var param = new Dictionary<string, string>();
param.Add("postcode", "CB21");
foreach (Dictionary<string, object> school in client.schools.search(null, param)) {
    // Display school name
    Console.WriteLine("School searched is {0}", school["name"]);
}

// Search for schools with the establishment number = 6006
param.Clear();
param.Add("establishment_number", "6006");
foreach (Dictionary<string, object> school in client.schools.search(null, param)) {
    // Display school name
    Console.WriteLine("School searched is {0}", school["name"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

'Search for schools with a postcode starting CB21
Dim params = New Dictionary(Of String, String)
param.Add("postcode", "CB21")
For Each school As Dictionary(Of String, Object) In client.schools.search(Nothing, param)
	'Display school name
	Console.WriteLine("School searched is {0}", school("name"))
Next school

'Search for schools with the establishment number = 6006
param.Clear()
params.Add("establishment_number", "6006")
For Each school As Dictionary(Of String, Object) In client.schools.search(Nothing, param)
	'Display school name
	Console.WriteLine("School searched is {0}", school("name"))
Next school
```

### Request Access

Provide the school ID to request access to a school's data.

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");
client.requestAccess("A0000000000");
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")
client.requestAccess("A0000000000")
```

### Revoke Access

Provide the school ID to access already approve or pending approval.

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");
client.revokeAccess("A0000000000");
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")
client.revokeAccess("A0000000000")
```

### Students
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get students
foreach (Dictionary<string, object> kv in school.students.all())
{
	Console.WriteLine("Student's Name is {0} {1}", kv["forename"], kv["surname"]);
}


// Get single student
var student = school.students.get("STUDENT_ID_GOES_HERE");

// Get students and include contact_details object
foreach (Dictionary<string, object> kv in school.students.all(new string[] { "contact_details" }))
{
	Console.WriteLine("Student's Name is {0} {1}", kv["forename"], kv["surname"]);
}

// Get students and include contacts array
foreach (Dictionary<string, object> kv in school.students.all(new string[] { "contacts" })) {
	Console.WriteLine("Student's Name is {0} {1}", kv["forename"], kv["surname"]);
}

// Get students, include contact_details object, include extended_details object and filter by updated after date
var param = new Dictionary<string, string>();
param.Add("updated_after", "2016-06-24 00:00:00");
foreach (Dictionary<string, object> kv in school.students.all(new string[] { "contact_details", "extended_details" }, param))
{
	Console.WriteLine("Student's Name is {0} {1}", kv["forename"], kv["surname"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get students
For Each kv As Dictionary(Of String, Object) In school.students.all()
	Console.WriteLine("Student's Name is {0} {1}", kv("forename"), kv("surname"))
Next kv

' Get single student
Dim student = school.students.get("STUDENT_ID_GOES_HERE")

' Get students And include contact_details object
For Each kv As Dictionary(Of String, Object) In school.students.all(New String() {"contact_details"})
	Console.WriteLine("Student's Name is {0} {1}", kv("forename"), kv("surname"))
Next kv

' Get students And include contacts array
For Each kv As Dictionary(Of String, Object) In school.students.all(New String() {"contacts"})
	Console.WriteLine("Student's Name is {0} {1}", kv("forename"), kv("surname"))
Next kv

' Get students, include contact_details object, include extended_details object And filter by updated after date
Dim param As New Dictionary(Of String, String)
param.Add("updated_after", "2016-06-24 00:00:00")
For Each kv As Dictionary(Of String, Object) In school.students.all(New String() {"contact_details", "extended_details"}, param))
	Console.WriteLine("Student's Name is {0} {1}", kv("forename"), kv("surname"))
Next kv
```

### Achievements
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get achievements
foreach (Dictionary<string, object> achievement in school.achievements.all()) {
    Console.WriteLine("Comment: {0}", achievement["comment"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get achievements
For Each achievement As Dictionary(Of String, Object) In school.achievements.all()
	Console.WriteLine("Comment: {0}", achievement("comment"))
Next achievement
```

### POST Achievements
For Posting/Deleting achievements you would need permissions for your token

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Create StudentsAchievements object using employee details, comments, date, etc.
Wonde.WriteBack.StudentsAchievements achievements = new Wonde.WriteBack.StudentsAchievements("AH00394J", "2017-01-23", "NYPA", "RE", "A4");

// Add StudentsAchievementRecord object for each student's achievement you need to post
achievements.addStudentsAchievementRecord(new Wonde.WriteBack.StudentsAchievementRecord("A34092203", 200));
achievements.addStudentsAchievementRecord(new Wonde.WriteBack.StudentsAchievementRecord("E342222223", 250, "TROP", "2016-04-01"));

// Post student's achievements
school.achievements.postAchievements(achievements);
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Create StudentsAchievements object using employee details, comments, date, etc.
Dim achievements As New Wonde.WriteBack.StudentsAchievements("AH00394J", "2017-01-23", "NYPA", "RE", "A4")

' Add StudentsAchievementRecord object for each student's achievement you need to post
achievements.addStudentsAchievementRecord(new Wonde.WriteBack.StudentsAchievementRecord("A34092203", 200))
achievements.addStudentsAchievementRecord(new Wonde.WriteBack.StudentsAchievementRecord("E342222223", 250, "TROP", "2016-04-01"))

' Post student's achievements
school.achievements.postAchievements(achievements)
```

### Assessments - (BETA)
This endpoint is included in the stable release but is likely to change in the future. Please contact support for more information.

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get aspects
foreach (Dictionary<string, object> aspect in school.assessment.Aspects.all()) {
    Console.WriteLine("Aspect ID: {0}", aspect["id"]);
}

// Get templates
foreach (Dictionary<string, object> template in school.assessment.Templates.all()) {
    Console.WriteLine("Template ID: {0}", template["id"]);
}

// Get result sets
foreach (Dictionary<string, object> resultset in school.assessment.ResultSets.all()) {
    Console.WriteLine("ResultSet ID: {0}", resultset["id"]);
}

// Get results 
foreach (Dictionary<string, object> result in school.assessment.Results.all()) {
    Console.WriteLine("Result ID: {0}", result["id"]);
}

// Get marksheets
foreach (Dictionary<string, object> marksheet in school.assessment.Marksheets.all()) {
    Console.WriteLine("Marksheet ID: {0}", marksheet["id"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get aspects
For Each aspect As Dictionary(Of String, Object) In school.assessment.aspects.all()
	Console.WriteLine("Aspect ID: {0}", aspect("id"))
Next aspect

' Get templates
For Each template As Dictionary(Of String, Object) In school.assessment.templates.all()
	Console.WriteLine("Template ID: {0}", template("id"))
Next template

' Get result sets
For Each resultset As Dictionary(Of String, Object) In school.assessment.resultsets.all()
	Console.WriteLine("ResultSet ID: {0}", resultset("id"))
Next resultset

' Get results 
For Each result As Dictionary(Of String, Object) In school.assessment.results.all()
	Console.WriteLine("Result ID: {0}", result("id"))
Next result

' Get marksheets
For Each marksheet As Dictionary(Of String, Object) In school.assessment.marksheets.all()
	Console.WriteLine("Marksheet ID: {0}", marksheet("id"))
Next marksheet
```

### Attendance
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get attendance
foreach (Dictionary<string, object> attendance in school.attendance.all()) {
    Console.WriteLine("Attendance Comment: {0}", attendance["comment"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get attendance
For Each attendance As Dictionary(Of String, Object) In school.attendance.all()
	Console.WriteLine("Attendance Comment: {0}", attendance("comment"))
Next attendance
```

### POST Attendance
You would require permissions to post attendances

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

// Initiate a new register
var register = new Wonde.Writeback.SessionRegister();

// Initiate a new attendance record
var attendance = new Wonde.Writeback.SessionAttendanceRecord();

// Set fields
attendance.setStudentId("STUDENT_ID_GOES_HERE");
attendance.setDate("2017-01-01");
attendance.setSession(Session.AM); // AM or PM
attendance.setAttendanceCodeId("ATTENDANCE_CODE_ID_GOES_HERE");
attendance.setComment("Comment here.");

// Add attendance mark to register
register.add(attendance);

// Save the session register
var result = school.attendance.sessionRegister(register);

// Writeback id is part of the response
Console.WriteLine ("Writeback id: {0}", result["writeback_id"]);
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

' Initiate a new register
Dim register As new Wonde.Writeback.SessionRegister()

' Initiate a new attendance record
Dim attendance As new Wonde.Writeback.SessionAttendanceRecord()

' Set fields
attendance.setStudentId("STUDENT_ID_GOES_HERE")
attendance.setDate("2017-01-01") ' y-m-d format
attendance.setSession(Session.AM) ' AM or PM
attendance.setAttendanceCodeId("ATTENDANCE_CODE_ID_GOES_HERE")
attendance.setComment("Comment here.")

' Add attendance mark to register
register.add(attendance)

' Save the session register
Dim result = school.attendance.sessionRegister(register)

' Writeback id is part of the response
Console.WriteLine ("Writeback id: {0}", result("writeback_id"))
```

### Attendance Codes
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

// Get attendance codes
foreach (Dictionary<string, object> attendanceCode in client.AttendanceCodes.all()) {
    Console.WriteLine("Attendance Code: {0}", attendanceCode["code"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

' Get attendance codes
For Each attendanceCode As Dictionary(Of String, Object) In client.AttendanceCodes.all()
	Console.WriteLine("Attendance Code: {0}", attendanceCode("code"))
Next attendanceCode
```

### Behaviours
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get behaviours
foreach (Dictionary<string, object> behaviour in school.behaviours.all()) {
    Console.WriteLine("Behaviour Incident: {0}", behaviour["incident"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get behaviours
For Each behaviour As Dictionary(Of String, Object) In school.behaviours.all()
	Console.WriteLine("Behaviour Incident: {0}", behaviour("incident"))
Next behaviour
```

### POST Behaviours
You would need permissions to Post behaviours

C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Create StudentsBehaviours object using employee details, comments, date, etc.
Wonde.WriteBack.StudentsBehaviours behaviours = new Wonde.WriteBack.StudentsBehaviours("AH00394J", "2017-01-23", "FUT", "BULL");

// Add StudentsBehaviourRecord object for each student's behaviour you need to post
behaviours.addStudentsBehaviourRecord(new Wonde.WriteBack.StudentsBehaviourRecord("A34092203", 200));
behaviours.addStudentsBehaviourRecord(new Wonde.WriteBack.StudentsBehaviourRecord("E342222223", 250, "TA", "PARL", "2016-04-01"));

// Post student's behaviours
school.behaviours.postBehaviours(behaviours);
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Create StudentsBehaviours object using employee details, comments, date, etc.
Dim behaviours As New Wonde.WriteBack.StudentsBehaviours("AH00394J", "2017-01-23", "FUT", "BULL")

' Add StudentsBehaviourRecord object for each student's behaviour you need to post
behaviours.addStudentsBehaviourRecord(new Wonde.WriteBack.StudentsBehaviourRecord("A34092203", 200))
behaviours.addStudentsBehaviourRecord(new Wonde.WriteBack.StudentsBehaviourRecord("E342222223", 250, "TA", "PARL", "2016-04-01"))

' Post student's behaviours
school.behaviours.postBehaviours(behaviours)
```

### Classes
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get classes
foreach (Dictionary<string, object> sclass in school.classes.all()) {
    Console.WriteLine("Class Name: {0}", sclass["name"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get classes
For Each sclass As Dictionary(Of String, Object) In school.classes.all()
	Console.WriteLine("Class Name: {0}", sclass("name"))
Next sclass
```

### Contacts
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get contacts
foreach (Dictionary<string, object> contact in school.contacts.all()) {
    Console.WriteLine("Contact Name: {0} {1}", contact["forename"], contact["surname"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get contacts
For Each contact As Dictionary(Of String, Object) In school.contacts.all()
	Console.WriteLine("Contact Name: {0} {1}", contact("forename"), contact("surname"))
Next contact
```

### Counts
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get counts
var counts = school.counts.all(new string[] { "students", "contacts" }, new Dictionary<string, string>()).ArrayData;
var studentsCount = ((Dictionary<string, object>)counts)["students"] as Dictionary<string, object>;
var contactsCount = ((Dictionary<string, object>)counts)["contacts"] as Dictionary<string, object>;
Console.WriteLine("Student's count: {0}", ((Dictionary<string, object>)studentsCount["data"])["count"]);
Console.WriteLine("Contacts's count: {0}", ((Dictionary<string, object>)contactsCount["data"])["count"]);
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get counts
Dim counts = school.counts.all(New String() {"students", "contacts"}, New Dictionary(Of String, String)()).ArrayData
Dim studentsCount = CType(CType(counts, Dictionary(Of String, Object))("students"), Dictionary(Of String, Object))("data")
Dim contactsCount = CType(CType(counts, Dictionary(Of String, Object))("students"), Dictionary(Of String, Object))("data")
Console.WriteLine("Student's count: {0}", studentsCount("count"))
Console.WriteLine("Contacts's count: {0}", contactsCount("count"))
```
### Deletions
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get deletions
foreach (Dictionary<string, object> deletion in school.deletions.all()) {
    Console.WriteLine("Deletion ID: {0}", deletion["id"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get deletions
For Each deletion As Dictionary(Of String, Object) In school.deletions.all()
	Console.WriteLine("Deletion ID: {0}", deletion("id"))
Next deletion
```

### Employees
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get employees
foreach (Dictionary<string, object> employee in school.employees.all()) {
    Console.WriteLine("Employee Name: {0} {1}", employee["forename"], employee["surname"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get employees
For Each employee As Dictionary(Of String, Object) In school.employees.all()
	Console.WriteLine("Employee Name: {0} {1}", employee("forename"), employee("surname"))
Next employee
```

### Events
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get events
foreach (Dictionary<string, object> _event in school.events.all()) {
    Console.WriteLine("Event ID: {0}", _event["id"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get events
For Each _event As Dictionary(Of String, Object) In school.events.all()
	Console.WriteLine("Event ID: {0}", _event("id"))
Next _event
```

### Lessons
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get lessons
foreach (Dictionary<string, object> lesson in school.lessons.all()) {
    Console.WriteLine("Period ID, Class ID: {0}, {1}", lesson["period_id"], lesson["class_id"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get lessons
For Each lesson As Dictionary(Of String, Object) In school.lessons.all()
	Console.WriteLine("Period ID, Class ID: {0}, {1}", lesson("period_id"), lesson("class_id"))
Next lesson
```

### Lesson Attendance
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get lesson attendance
foreach (Dictionary<string, object> lesson in school.lessonAttendance.all()) {
    Console.WriteLine("Lesson Attendance Comment: {0}", lesson["comment"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get lesson attendance
For Each lesson As Dictionary(Of String, Object) In school.lessonAttendance.all()
	Console.WriteLine("Lesson Attendance Comment: {0}", lesson("comment"))
Next lesson
```

### POST Lesson Attendance

```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Initiate a new register
var register = new Wonde.Writeback.LessonRegister();

// Initiate a new attendance record
var attendance = new Wonde.Writeback.LessonAttendanceRecord();

// Set fields
attendance.setStudentId("STUDENT_ID_GOES_HERE");
attendance.setLessonId("LESSON_ID_GOES_HERE");
attendance.setAttendanceCodeId("ATTENDANCE_CODE_ID_GOES_HERE");

// Add attendance mark to register
register.add(attendance);

// Save the lesson register
var result = school.lessonAttendance().lessonRegister(register);

// Writeback id is part of the response
Console.WriteLine("Writeback ID: {0}", result["writeback_id"];
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Initiate a new register
Dim register As new Wonde.Writeback.LessonRegister()

' Initiate a new attendance record
Dim attendance As new Wonde.Writeback.LessonAttendanceRecord()

' Set fields
attendance.setStudentId("STUDENT_ID_GOES_HERE")
attendance.setLessonId("LESSON_ID_GOES_HERE")
attendance.setAttendanceCodeId("ATTENDANCE_CODE_ID_GOES_HERE")

' Add attendance mark to register
register.add(attendance)

' Save the lesson register
var result = school.lessonAttendance().lessonRegister(register)

' Writeback id is part of the response
Console.WriteLine("Writeback ID: {0}", result("writeback_id")
```

### Medical Conditions
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get Medical conditions
foreach (Dictionary<string, object> mconditions in school.medicalConditions.all()) {
    Console.WriteLine("Medical conditions Description: {0}", mconditions["description"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get Medical conditions
For Each mconditions As Dictionary(Of String, Object) In school.medicalConditions.all()
	Console.WriteLine("Medical conditions Description: {0}", mconditions("description"))
Next mconditions
```

### Medical Events
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get Medical events
foreach (Dictionary<string, object> mevent in school.medicalEvents.all()) {
    Console.WriteLine("Medical event Description: {0}", mevent["description"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get Medical events
For Each mevent As Dictionary(Of String, Object) In school.medicalEvents.all()
	Console.WriteLine("Medical event Description: {0}", mevent("description"))
Next mevent
```

### Periods
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get periods
foreach (Dictionary<string, object> period in school.periods.all()) {
    Console.WriteLine("Period Name: {0}", period["name"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get periods
For Each period As Dictionary(Of String, Object) In school.periods.all()
	Console.WriteLine("Period Name: {0}", period("name"))
Next period
```

### Photos
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get photos
foreach (Dictionary<string, object> photo in school.photos.all()) {
    Console.WriteLine("Photo Hash: {0}", photo["hash"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get photos
For Each photo As Dictionary(Of String, Object) In school.photos.all()
	Console.WriteLine("Photo Hash: {0}", photo("hash"))
Next photo
```

### Rooms
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get rooms
foreach (Dictionary<string, object> room in school.rooms.all()) {
    Console.WriteLine("Room Name: {0}", room["name"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get rooms
For Each room As Dictionary(Of String, Object) In school.rooms.all()
	Console.WriteLine("Room Name: {0}", room("name"))
Next room
```

### Subjects
C#
```C#
var client = new Wonde.Client("TOKEN_GOES_HERE");

var school = client.school("SCHOOL_ID_GOES_HERE");

// Get subjects
foreach (Dictionary<string, object> subject in school.subjects.all()) {
    Console.WriteLine("Subject Name: {0}", subject["name"]);
}
```
VB.Net
```VB
Dim client As New Wonde.Client("TOKEN_GOES_HERE")

Dim school = client.school("SCHOOL_ID_GOES_HERE")

' Get subjects
For Each subject As Dictionary(Of String, Object) In school.subjects.all()
	Console.WriteLine("Subject Name: {0}", subject("name"))
Next subject
```
This Readme file is not yet completed.