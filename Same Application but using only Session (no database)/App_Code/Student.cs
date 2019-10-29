using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3
{
    public class Student
    {
        private string id;
        public string Id { get { return id; } }

        private string name;
        public string Name { get { return name; } }

        private int grade;
        public int Grade { get { return grade; } }


        public Student(string id, string name, string grade)
        {
            this.id = id;
            this.name = name;
            this.grade = int.Parse(grade);
        }
    }
}
