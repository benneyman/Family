using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.DTO
{
    public sealed class Person
    {
        public Person(string name, Gender gender, int id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            Name = name;
            Gender = gender;
            this.id = id;
        }

        public string Name { get; }
        public Gender Gender { get; }
        public int Id => id;
        private readonly int id;
    }
}
