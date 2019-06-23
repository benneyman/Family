using Family.DTO;
using Family.Enums;
using Family.Implementation;
using Family.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Tests
{
    public class FamilyGraphTests
    {
        public IPersonStore PersonStore;
        public IFamilyGraph familyGraph;

        Person george = new Person("George", Gender.Male);
        Person mary = new Person("Mary", Gender.Female);
        Person bob = new Person("Bob", Gender.Male);
        Person sally = new Person("Sally", Gender.Female);

        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore = new PersonStore();
            PersonStore.Add(george);
            PersonStore.Add(mary);
            PersonStore.Add(bob);
            PersonStore.Add(sally);
            ServiceLocator.RegisterType(PersonStore);
        }
        [Test]
        public void AddSpouseForExistingPeopleShouldNotThrowException()
        {
            IFamilyGraph familyGraph = new FamilyGraph();
            var edgeInput = new EdgeInput("George", "Mary", RelationshipType.Spouse);
            Action act = ()=> familyGraph.Add(edgeInput);
            act.Should().NotThrow();
        }
        [Test]
        public void AddParentForExistingPeopleShouldNotThrowException()
        {
            IFamilyGraph familyGraph = new FamilyGraph();
            var edgeInput = new EdgeInput("Bob", "Sally", RelationshipType.Parent);
            Action act = () => familyGraph.Add(edgeInput);
            act.Should().NotThrow();
        }
        [Test]
        public void AdddingParentForExistingPeopleShouldReturnProperEdges()
        {
            IFamilyGraph familyGraph = new FamilyGraph();
            var edgeInput = new EdgeInput("George", "Bob", RelationshipType.Parent);
            familyGraph.Add(edgeInput);
            IPersonRelationships actual = familyGraph.Get(PersonStore.GetPerson("George"));
            var edges = new List<Edge>() { new Edge(george, bob, RelationshipType.Parent) };
            var expected = new PersonRelationships(edges , new List<Person>());
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
