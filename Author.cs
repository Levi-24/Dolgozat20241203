using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolgozat20241203
{
    internal class Author
    {
        private string firstName;
        private string lastName;
        public Guid Guid { get; set; }

        public string FirstName { 
            get => firstName; 
            set
            {
                if (value is null)
                    throw new ArgumentException("You didn't specify the first name.");
                if (value.Length < 3 || value.Length > 32)
                    throw new ArgumentException("The first name length must be between 3 and 32 characters.");
                firstName = value;
            } 
        }
        public string LastName { 
            get => lastName; 
            set 
            {
                if (value is null)
                    throw new ArgumentException("You didn't specify the last name.");
                if (value.Length < 3 || value.Length > 32)
                    throw new ArgumentException("The last name length must be between 3 and 32 characters.");
                lastName = value;
            }
        }

        public Author(string name)
        {
            var space = "\u0020";
            var names = name.Split(space);

            Guid = Guid.NewGuid();
            FirstName = names[0];
            LastName = names[1];
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Guid}";
        }
    }


}
