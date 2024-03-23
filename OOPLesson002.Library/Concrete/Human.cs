using System;

namespace OOPLesson002.Library.Concrete
{
    public abstract class Human
    {
        public string Name;
        public DateTime BirthDate;
        public bool IsMale;

        public Human(string name, DateTime birthDate, bool isMale)
        {
            this.Validate(name, birthDate);

            this.Name = name;
            this.BirthDate = birthDate;
            this.IsMale = isMale;
        }

        private void Validate(string name, DateTime birthDate)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ApplicationException("Name must be filled!");
            }
            
            if (name.Any(o => char.IsLetter(o) == false))
            {
                throw new ApplicationException("Name must contain only letter!");
            }

            if (DateTime.UtcNow.Year - birthDate.Year < 7)
            {
                throw new ApplicationException("BirthDate must be greater than 7 years!");
            }
        }
    }
}