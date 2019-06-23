using Family.DTO;
using Family.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Implementation
{
    public class FamilyGraph : IFamilyGraph
    {
        private Dictionary<Person, PersonRelationships> Families;
        public FamilyGraph()
        {
            Families = new Dictionary<Person, PersonRelationships>();
        }
        public IPersonStore PersonStore { get { return ServiceLocator.GetService<IPersonStore>(); } }

        public void Add(EdgeInput inputEdge)
        {
            Edge edge;
            try
            {
                edge = GetEdge(inputEdge);
            }
            catch (ArgumentException)
            {
                throw;
            }
            switch (edge.RelationshipType)
            {
                case Enums.RelationshipType.Parent:
                    AddParentRelationship(edge);
                    return;
                case Enums.RelationshipType.Spouse:
                    AddSpouseRelationship(edge);
                    return;
            }
        }
        private void AddSpouseRelationship(Edge edge)
        {
            PersonRelationships sourcePersonRelationships, targetPersonRelationships;
            Families.TryAdd(edge.Source, new PersonRelationships());
            Families.TryAdd(edge.Target, new PersonRelationships());

            Families.TryGetValue(edge.Source, out sourcePersonRelationships);
            Families.TryGetValue(edge.Target, out targetPersonRelationships);

            if (targetPersonRelationships.Spouse == null && sourcePersonRelationships.Spouse == null)
            {
                targetPersonRelationships.AddSpouse(edge.Source);
                sourcePersonRelationships.AddSpouse(edge.Target);
            }
            else
            {
                throw new InvalidOperationException($"Cannot add spouse");
            }
        }
        private void AddParentRelationship(Edge edge)
        {
            PersonRelationships sourcePersonRelationships, targetPersonRelationships;
            Families.TryAdd(edge.Source, new PersonRelationships());
            Families.TryAdd(edge.Target, new PersonRelationships());

            Families.TryGetValue(edge.Source, out sourcePersonRelationships);
            Families.TryGetValue(edge.Target, out targetPersonRelationships);
            if (targetPersonRelationships.CanAddParent(edge.Source))
            {
                targetPersonRelationships.AddParent(edge.Source);
                sourcePersonRelationships.AddEdge(edge);
            }
            else
            {
                throw new InvalidOperationException($"Cannot add parents to {edge.Target.Name}");
            }
        }
        public Edge GetEdge(EdgeInput inputEdge)
        {
            Person source, target;
            try
            {
                source = PersonStore.GetPerson(inputEdge.Source);
                target = PersonStore.GetPerson(inputEdge.Target);
            }
            catch (Exception)
            {

                throw;
            }
            return new Edge(source, target, inputEdge.RelationshipType);
        }
        public IPersonRelationships Get(Person person)
        {
            PersonRelationships personRelationships;
            Families.TryGetValue(person, out personRelationships);
            return personRelationships;
        }
    }
}
