using System;

namespace OOPLesson002.Library.Concrete
{
    public class Teacher : Human
    {
        private List<Class> _classes = new List<Class>();
        internal List<Class> ClassesList
        {
            get
            {
                return this._classes;
            }
        }
        public IEnumerable<Class> Classes
        {
            get
            {
                return this._classes;
            }
        }

        public Teacher(string name, DateTime birthDate, bool isMale) : base(name, birthDate, isMale)
        {
        }
    }
}