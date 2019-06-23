using Family.DTO;
using Family.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Family.Implementation
{
    public sealed class PersonRelationships : IPersonRelationships
    {
        public List<Edge> Edges { get; private set; }
        public List<Person> Parents { get; private set; }
        public Person Spouse { get; private set; }

        public PersonRelationships()
        {
            Edges = new List<Edge>();
            Parents = new List<Person>();
        }
        public PersonRelationships(List<Edge> edges, List<Person> persons)
        {
            Edges = edges;
            Parents = persons;
        }

        public bool CanAddParent(Person parent)
        {
            if (Parents.Count() == 2)
                return false;
            return !Parents.Any(m => m.Gender == parent.Gender);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void AddParent(Person parent)
        {
            Parents.Add(parent);
        }

        public void AddSpouse(Person spouse)
        {
            Spouse = spouse;
        }
    }
}
