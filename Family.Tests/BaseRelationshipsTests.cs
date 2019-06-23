using Family.DTO;
using Family.Enums;
using Family.Implementation;
using Family.Interfaces;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Tests
{
    public class BaseRelationshipsTests
    {
        public IPersonStore PersonStore;
        public IFamilyGraph familyGraph;

        Person george = new Person("George", Gender.Male);
        Person mary = new Person("Mary", Gender.Female);
        Person bob = new Person("Bob", Gender.Male);
        Person sally = new Person("Sally", Gender.Female);
        Person dave = new Person("Dave", Gender.Male);

        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore = new PersonStore();
            PersonStore.Add(new List<Person>() { george, mary, bob, sally, dave });
            ServiceLocator.RegisterType(PersonStore);
        }

        [Test]
        public void ParentsTest()
        {
            //Add George and Mary as Bob's Parents
            familyGraph = new FamilyGraph();
            familyGraph.Add(new EdgeInput("George", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Bob", RelationshipType.Parent));
            ServiceLocator.RegisterType(familyGraph);
            Person bob = PersonStore.GetPerson("Bob");
            IEnumerable<Person> actual = bob.Parents();
            IEnumerable<Person> expected = PersonStore.GetPeople(new List<string>() { "George", "Mary" });
            actual.Should().BeEquivalentTo(expected);
            
        }
        [Test]
        public void EmptyParentsTest()
        {
            //Add George and Mary as Bob's Parents
            familyGraph = new FamilyGraph();
            ServiceLocator.RegisterType(familyGraph);

            Person bob = PersonStore.GetPerson("Bob");
            IEnumerable<Person> actual = bob.Parents();
            IEnumerable<Person> expected = new List<Person>();
            actual.Should().BeEquivalentTo(expected);

        }
        [Test]
        public void SiblingsTest()
        {
            //Add George and Mary as Bob's Parents
            familyGraph = new FamilyGraph();
            familyGraph.Add(new EdgeInput("George", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Sally", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Sally", RelationshipType.Parent));
            ServiceLocator.RegisterType(familyGraph);
            IEnumerable<Person> actual = dave.Siblings();
            IEnumerable<Person> expected = PersonStore.GetPeople(new List<string>() { "Bob", "Sally" });
            actual.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void SiblingsHaveSameParentsTest()
        {
            //Add George and Mary as Bob's Parents
            familyGraph = new FamilyGraph();
            familyGraph.Add(new EdgeInput("George", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Sally", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Sally", RelationshipType.Parent));
            ServiceLocator.RegisterType(familyGraph);
            dave.Parents().Should().BeEquivalentTo(bob.Parents());
        }
        [Test]
        public void ChildrenTest()
        {
            //Add George and Mary as Bob's Parents
            familyGraph = new FamilyGraph();
            familyGraph.Add(new EdgeInput("George", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Sally", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Sally", RelationshipType.Parent));
            ServiceLocator.RegisterType(familyGraph);
            IEnumerable<Person> actual = george.Children();
            IEnumerable<Person> expected = new List<Person>() { dave, bob, sally };
            actual.Should().BeEquivalentTo(expected);
        }

    }
}
