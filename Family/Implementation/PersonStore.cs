using Family.DTO;
using Family.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Implementation
{
    public class PersonStore : IPersonStore
    {
        private Dictionary<string, Person> people;

        public PersonStore()
        {
            people = new Dictionary<string, Person>();
        }

        public void Add(Person person)
        {
            if(Contains(person.Name))
            {
                throw new ArgumentException($"{person.Name} is already present");
            }
            people.Add(person.Name, person);
        }

        public void Add(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                try
                {
                    Add(person);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Contains(string personName)
        {
            return people.ContainsKey(personName);
        }

        public IEnumerable<Person> GetPeople(List<string> people)
        {
            List<Person> result = new List<Person>();
            people.ForEach(person => {
                try
                {
                    Person personObject = GetPerson(person);
                    result.Add(personObject);
                }
                catch (Exception)
                {
                    throw;
                }
            });
            return result;
        }

        public Person GetPerson(string personName)
        {
            Person person;
            bool result = people.TryGetValue(personName, out person);
            if(!result)
            {
                throw new ArgumentException($"{personName} isn't found");
            }
            return person;
        }
    }
}
