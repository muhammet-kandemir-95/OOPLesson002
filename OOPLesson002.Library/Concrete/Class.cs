using System;

namespace OOPLesson002.Library.Concrete
{
    public class Class
    {
        public string Code;

        private List<Teacher> _teachers = new List<Teacher>();
        public IEnumerable<Teacher> Teachers
        {
            get
            {
                return this._teachers;
            }
        }
        private List<Student> _students = new List<Student>();
        public IEnumerable<Student> Students
        {
            get
            {
                return this._students;
            }
        }

        public Class(string code, IEnumerable<Teacher> teachers, IEnumerable<Student> students)
        {
            this.Validate(code, teachers, students);

            this.Code = code;
            this._teachers.AddRange(teachers);
            foreach (Teacher teacher in this.Teachers)
            {
                teacher.ClassesList.Add(this);
            }

            this._students.AddRange(students);
            foreach (Student student in this.Students)
            {
                student.Class = this;
            }
        }

        private void Validate(string code, IEnumerable<Teacher> teachers, IEnumerable<Student> students)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ApplicationException("Code must be filled!");
            }

            if (code.Length > 4)
            {
                throw new ApplicationException("Code must be shorter than 4 characters!");
            }
            
            if (teachers.Count() == 0)
            {
                throw new ApplicationException("Teachers must contain at least one item!");
            }

            if (teachers.GroupBy(o => o).Any(g => g.Count() > 1))
            {
                throw new ApplicationException("A teacher can not be assigned to a same class more than once!");
            }
            
            if (students.Count() == 0)
            {
                throw new ApplicationException("Students must contain at least one item!");
            }

            if (students.Any(o => o.Class != null))
            {
                throw new ApplicationException("A student can not be assigned to multiple classes!");
            }

            if (students.GroupBy(o => o).Any(g => g.Count() > 1))
            {
                throw new ApplicationException("A student can not be assigned to a same class more than once!");
            }
        }
    }
}