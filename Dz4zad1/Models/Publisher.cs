using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dz4zad1.Models
{
    public class Publisher
    {
        public  int Id { get; set; }
        public string Name { get; set; }

        public Publisher(string name)
        {
            Name = name;
        }

        public void Rename_publisher(string name)
        {
            Name = name;
        }
    }
}