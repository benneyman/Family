using Family.DTO;
using Family.Enums;
using Family.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Implementation
{
    public sealed class Relationships : IRelationships
    {
        private IPersonStore PersonStore;
        public Relationships()
        {
            var personStore = ServiceLocator.GetService<IPersonStore>();
            PersonStore = personStore ?? throw new Exception("Could not load dependencies");
        }
        public Person GetPerson(string person)
        {
            Person personObject;
            try
            {
                personObject = PersonStore.GetPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
            return personObject;
        }

        public IEnumerable<Person> BrotherInLaw(string person)
        {
            return InLaws(person, Gender.Male);
        }

        public IEnumerable<Person> Daughter(string person)
        {
            return Children(person, Gender.Female);
        }

        public IEnumerable<Person> MaternalAunt(string person)
        {
            return UncleAndAunt(person, "Maternal", "Aunt");
        }

        public IEnumerable<Person> MaternalUncle(string person)
        {
            return UncleAndAunt(person, "Maternal", "Uncle");
        }

        public IEnumerable<Person> PaternalAunt(string person)
        {
            return UncleAndAunt(person, "Paternal", "Aunt");
        }

        public IEnumerable<Person> PaternalUncle(string person)
        {
            return UncleAndAunt(person, "Paternal", "Uncle");
        }

        public IEnumerable<Person> Siblings(string person)
        {
            Person personObject;
            try
            {
                personObject = GetPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
            return personObject.Siblings();
        }

        public IEnumerable<Person> SisterInLaw(string person)
        {
            return InLaws(person, Gender.Female);
        }

        public IEnumerable<Person> Son(string person)
        {
            return Children(person, Gender.Male);
        }

        private IEnumerable<Person> UncleAndAunt(string person, string direction, string uncleOrAunt)
        {
            Person personObject;
            try
            {
                personObject = GetPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
            Gender parentsGender = direction == "Maternal" ? Gender.Female : Gender.Male;
            Gender uncleOrAuntGender = uncleOrAunt == "Aunt" ? Gender.Female : Gender.Male;
            return personObject.Parents(parentsGender)
                .Siblings(uncleOrAuntGender);
        }

        private IEnumerable<Person> Children(string person, Gender gender)
        {
            Person personObject;
            try
            {
                personObject = GetPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
            return personObject.Children(gender);
        }

        private IEnumerable<Person> InLaws(string person, Gender gender)
        {
            Person personObject;
            try
            {
                personObject = GetPerson(person);
            }
            catch (Exception)
            {
                throw;
            }
            return personObject.Spouse().Siblings(gender);
        }
    }
}
