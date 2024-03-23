using System;

namespace OOPLesson002.Library.Concrete
{
    public class School
    {
        public string Name;
        private List<Class> _classes = new List<Class>();
        public IEnumerable<Class> Classes
        {
            get
            {
                return this._classes;
            }
        }

        public School(string name, IEnumerable<Class> classes)
        {
            this.Validate(name, classes);

            this._classes.AddRange(classes);
        }

        private void Validate(string name, IEnumerable<Class> classes)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ApplicationException("Name must be filled!");
            }

            if (classes.Count() == 0)
            {
                throw new ApplicationException("Classes must contain at least one item!");
            }

            if (classes.GroupBy(o => o).Any(g => g.Count() > 1))
            {
                throw new ApplicationException("A class can not be assigned to a same school more than once!");
            }
        }
    }
}