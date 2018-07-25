using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Dz4zad1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }

        public Author(string name, string dateBirth, string dateDeath)
        {
            Name = name;
            DateOfBirth = dateBirth.AsDateTime();
            DateOfDeath = dateDeath.AsDateTime();
        }

        public void Raname_Author(string name, string dateBirth, string dateDeath)
        {
            Name = name;
            DateOfBirth = dateBirth.AsDateTime();
            DateOfDeath = dateDeath.AsDateTime();
        }
    }
}