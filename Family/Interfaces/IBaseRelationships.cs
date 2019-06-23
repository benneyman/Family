using Family.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Interfaces
{
    public interface IBaseRelationships
    {
        IEnumerable<Person> Parents(IEnumerable<Person> people);
        IEnumerable<Person> Children(IEnumerable<Person> people);
        IEnumerable<Person> Siblings(IEnumerable<Person> people);
    }
}

