using System.Collections.Generic;
using Family.DTO;

namespace Family.Interfaces
{
    public interface IPersonRelationships
    {
        List<Edge> Edges { get; }
        List<Person> Parents { get; }
        Person Spouse { get; }

        void AddEdge(Edge edge);
        void AddParent(Person parent);
        void AddSpouse(Person spouse);
        bool CanAddParent(Person parent);
    }
}