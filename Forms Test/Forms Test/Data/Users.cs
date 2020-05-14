using System;
using System.Collections.Generic;
using System.Text;

namespace FormsTest.Data
{
   public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"({Id}) {Name}, {Password}";
        }
    }
}
