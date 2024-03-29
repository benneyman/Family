﻿using Family.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.DTO
{
    public sealed class Person : IEquatable<Person>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            return other != null &&
                   Name == other.Name &&
                   Gender == other.Gender &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Gender, Id);
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return EqualityComparer<Person>.Default.Equals(person1, person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }
    }
}
