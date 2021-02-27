using System;

namespace IMDBApp.Models.Classes
{
    public abstract class Person
    {

        public string Name { get; set; }
      
        public string Bio { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
    }
}