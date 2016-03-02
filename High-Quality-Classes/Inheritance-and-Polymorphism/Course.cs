using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Course
    {
        private string name = null;
        private string teacherName = null;
        private IList<string> students = new List<string>();
        
        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name { get; set; }
        public string TeacherName { get; set; }
        public IList<string> Students { get; set; }


    }
}
