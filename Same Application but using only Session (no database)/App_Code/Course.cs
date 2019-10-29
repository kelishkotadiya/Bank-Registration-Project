using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Course
    {
        private string courseNumber;
        public string CourseNumber { get { return courseNumber; } }

        private string courseName;
        public string CourseName { get { return courseName; } }

        private List<Student> students = new List<Student>();

        public Course(string courseNumber, string courseName, List<Student> students)
        {
            this.courseNumber = courseNumber;
            this.courseName = courseName;
            this.students = students;
        }
        public override string ToString()
        {
            return courseNumber + " - " + courseName;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetStudents()
        {
            return students;
        }

        public bool IsEmpty { get { return students.Count == 0; } }
    }
}

