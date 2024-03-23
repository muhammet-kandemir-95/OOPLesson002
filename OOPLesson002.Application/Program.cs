using System;
using OOPLesson002.Library.Concrete;

namespace OOPLesson002.Application
{
    class Program
    {
        static IEnumerable<Student> GetStudentsBySchool(School school)
        {
            List<Student> students = new List<Student>();

            foreach (Class cls in school.Classes)
            {
                students.AddRange(cls.Students);
            }


            return students;
        }

        static IEnumerable<Class> GetClassesBySchool(School school)
        {
            return school.Classes;
        }

        static IEnumerable<Teacher> GetTeachersBySchool(School school)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (Class cls in school.Classes)
            {
                teachers.AddRange(cls.Teachers);
            }

            return teachers;
        }

        static IEnumerable<Student> GetStudentsByClass(Class cls)
        {
            return cls.Students;
        }

        static IEnumerable<Student> GetStudentsByTeacher(Teacher teacher)
        {
            List<Student> students = new List<Student>();

            foreach (Class cls in teacher.Classes)
            {
                students.AddRange(cls.Students);
            }

            return students;
        }

        static IEnumerable<Class> GetClassesByTeacher(Teacher teacher)
        {
            return teacher.Classes;
        }

        static IEnumerable<Teacher> GetTeachersByClass(Class cls)
        {
            return cls.Teachers;
        }

        static Class GetClassByStudent(Student student)
        {
            return student.Class;
        }

        static IEnumerable<Teacher> GetTeachersByStudent(Student student)
        {
            return student.Class.Teachers;
        }

        public static void Main(string[] args)
        {
            Teacher muhammetTeacher = new Teacher("Muhammet", new DateTime(1995, 8, 11), true);
            Teacher aylaTeacher = new Teacher("Ayla", new DateTime(1990, 5, 23), false);
            Student hamzaStudent = new Student("Hamza", new DateTime(1999, 7, 16), true);
            Student mertStudent = new Student("Mert", new DateTime(2000, 9, 27), true);
            Student omerStudent = new Student("Ömer", new DateTime(2000, 8, 23), true);
            Class classA = new Class("11A", new Teacher[]
            {
                muhammetTeacher,
                aylaTeacher
            }, new Student[]
            {
                hamzaStudent,
                mertStudent,
                omerStudent
            });

            Teacher aykutTeacher = new Teacher("Aykut", new DateTime(1984, 1, 2), true);
            Student remziStudent = new Student("Remzi", new DateTime(1992, 11, 25), true);
            Student nesibeStudent = new Student("Nesibe", new DateTime(2006, 11, 15), false);
            Class classB = new Class("11B", new Teacher[]
            {
                muhammetTeacher,
                aykutTeacher
            }, new Student[]
            {
                remziStudent,
                nesibeStudent
            });

            School salSchool = new School("Şirinyer Anadolu Lisesi", new Class[]
            {
                classA,
                classB
            });

            Console.WriteLine("Q1: GetStudentsBySchool:");
            foreach (Student student in GetStudentsBySchool(salSchool))
            {
                Console.WriteLine($"-> Student Name: '{student.Name}', Age: {DateTime.UtcNow.Year - student.BirthDate.Year}, Gender: {(student.IsMale == true ? "Male" : "Female")}");
            }

            Console.WriteLine("Q2: GetClassesBySchool:");
            foreach (Class cls in GetClassesBySchool(salSchool))
            {
                Console.WriteLine($"-> Class Code: '{cls.Code}'");
            }

            Console.WriteLine("Q3: GetTeachersBySchool:");
            foreach (Teacher teacher in GetTeachersBySchool(salSchool))
            {
                Console.WriteLine($"-> Teacher Name: '{teacher.Name}', Age: {DateTime.UtcNow.Year - teacher.BirthDate.Year}, Gender: {(teacher.IsMale == true ? "Male" : "Female")}");
            }

            Console.WriteLine("Q4: GetStudentsByClass:");
            foreach (Student student in GetStudentsByClass(classA))
            {
                Console.WriteLine($"-> Student Name: '{student.Name}', Age: {DateTime.UtcNow.Year - student.BirthDate.Year}, Gender: {(student.IsMale == true ? "Male" : "Female")}");
            }

            Console.WriteLine("Q5: GetStudentsByTeacher:");
            foreach (Student student in GetStudentsByTeacher(muhammetTeacher))
            {
                Console.WriteLine($"-> Student Name: '{student.Name}', Age: {DateTime.UtcNow.Year - student.BirthDate.Year}, Gender: {(student.IsMale == true ? "Male" : "Female")}");
            }

            Console.WriteLine("Q6: GetClassesByTeacher:");
            foreach (Class cls in GetClassesByTeacher(muhammetTeacher))
            {
                Console.WriteLine($"-> Class Code: '{cls.Code}'");
            }

            Console.WriteLine("Q7: GetTeachersByClass:");
            foreach (Teacher teacher in GetTeachersByClass(classB))
            {
                Console.WriteLine($"-> Teacher Name: '{teacher.Name}', Age: {DateTime.UtcNow.Year - teacher.BirthDate.Year}, Gender: {(teacher.IsMale == true ? "Male" : "Female")}");
            }

            Console.WriteLine("Q8: GetClassByStudent:");
            Class omerStudentClass = GetClassByStudent(omerStudent);
            Console.WriteLine($"-> Class Code: '{omerStudentClass.Code}'");

            Console.WriteLine("Q9: GetTeachersByStudent:");
            foreach (Teacher teacher in GetTeachersByStudent(omerStudent))
            {
                Console.WriteLine($"-> Teacher Name: '{teacher.Name}', Age: {DateTime.UtcNow.Year - teacher.BirthDate.Year}, Gender: {(teacher.IsMale == true ? "Male" : "Female")}");
            }
        }
    }
}