using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.DTO
{
    public class Person
    {
        public Person(string name, Gender gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            Name = name;
            Gender = gender;
        }

        public string Name { get; }
        public Gender Gender { get; }
    }
}
