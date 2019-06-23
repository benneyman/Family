using Family.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Interfaces
{
    public interface IPersonStore
    {
        void Add(Person person);
        void Add(IEnumerable<Person> person);
        bool Contains(string personName);
        Person GetPerson(string personName);
        IEnumerable<Person> GetPeople(List<string> people);
    }
}
