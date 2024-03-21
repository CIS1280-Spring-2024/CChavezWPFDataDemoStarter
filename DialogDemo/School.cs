namespace DialogDemo
{
    public class School
    {
        public string[] Courses { get; set; }
        public string[] Majors { get; set; }
        public string[] Campuses { get; set; }
        public List<Student> Students { get; set; }

        public School()
        {
            Courses = new string[] { "CIS 101", "CIS 102", "CIS 103", "CIS 104" };
            Majors = new string[] { "Application Development", "Web Development", "IT" };
            Campuses = new string[] { "Main", "Montoya", "Rio Rancho", "ATC" };
            Students = new List<Student>();
        }
    }
}
