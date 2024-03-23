using System;

namespace OOPLesson002.Library.Concrete
{
    public class Student : Human
    {
        private Class _class;

        public Class Class
        {
            get
            {
                return this._class;
            }
            internal set
            {
                this._class = value;
            }
        }

        public Student(string name, DateTime birthDate, bool isMale) : base(name, birthDate, isMale)
        {
        }
    }
}