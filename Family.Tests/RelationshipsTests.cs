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
    public class RelationshipsTests
    {
       
        Person george = new Person("George", Gender.Male);
        Person mary = new Person("Mary", Gender.Female);
        Person bob = new Person("Bob", Gender.Male);
        Person sally = new Person("Sally", Gender.Female);
        Person dave = new Person("Dave", Gender.Male);
        Person davesMaternalUncle = new Person("Hulk", Gender.Male);
        Person davesPaternalAunt = new Person("Aunt", Gender.Female);
        Person davesMaternalGrandDad = new Person("Thor", Gender.Male);
        Person davesMaternalGrandMom = new Person("Wonder", Gender.Female);
        Person davesPaternalGrandDad = new Person("Thor1", Gender.Male);
        Person davesPaternalGrandMom = new Person("Wonder1", Gender.Female);

        Person amy = new Person("Amy", Gender.Female);
        Person bamy = new Person("Bamy", Gender.Female);
        Person miller = new Person("Miller", Gender.Male);
        Person amysMom = new Person("Miley", Gender.Female);
        Person amysDad = new Person("Brad", Gender.Male);


        Relationships relationships;

        [OneTimeSetUp]
        public void SetUp()
        {
            IPersonStore PersonStore = new PersonStore();
            IFamilyGraph familyGraph  = new FamilyGraph();

            PersonStore.Add(new List<Person>()
            {
                george, mary, bob, sally, dave, davesMaternalUncle, davesMaternalGrandDad, davesMaternalGrandMom,
                davesPaternalAunt, davesPaternalGrandDad, davesPaternalGrandMom, amy, bamy, miller, amysMom, amysDad
            });

            ServiceLocator.RegisterType(PersonStore);

            //Daves Family
            familyGraph.Add(new EdgeInput("Thor", "Mary", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Wonder", "Mary", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Thor", "Hulk", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Wonder", "Hulk", RelationshipType.Parent));

            familyGraph.Add(new EdgeInput("Thor1", "George", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Wonder1", "George", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Thor1", "Aunt", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Wonder1", "Aunt", RelationshipType.Parent));

            familyGraph.Add(new EdgeInput("George", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Bob", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Dave", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("George", "Sally", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Mary", "Sally", RelationshipType.Parent));


            //Spouse
            familyGraph.Add(new EdgeInput("Dave", "Amy", RelationshipType.Spouse));
            
            //Amy's Family
            familyGraph.Add(new EdgeInput("Brad", "Miller", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Miley", "Miller", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Brad", "Amy", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Miley", "Amy", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Brad", "Bamy", RelationshipType.Parent));
            familyGraph.Add(new EdgeInput("Miley", "Bamy", RelationshipType.Parent));

            
            ServiceLocator.RegisterType(familyGraph);

            relationships = new Relationships();
        }

        [Test]
        public void MaternalUncleTest()
        {
            var davesUncle = relationships.MaternalUncle("Dave");
            var expected = new List<Person>() { davesMaternalUncle };
            davesUncle.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void MaternalUncleTest1()
        {
            var amysUncle = relationships.MaternalUncle("Amy");
            var expected = new List<Person>() {  };
            amysUncle.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void PaternalAuntTest()
        {
            var davesAunt = relationships.PaternalAunt("Dave");
            var expected = new List<Person>() { davesPaternalAunt };
            davesAunt.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void MaternalAuntTest1()
        {
            var amysUncle = relationships.MaternalAunt("Amy");
            var expected = new List<Person>() { };
            amysUncle.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void BrotherInLawTest()
        {
            var AmysInLaws = relationships.BrotherInLaw("Amy");
            var expected = new List<Person>() { bob };
            AmysInLaws.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void SisterInLawTest()
        {
            var AmysInLaws = relationships.SisterInLaw("Amy");
            var expected = new List<Person>() { sally };
            AmysInLaws.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void BrotherInLawTest1()
        {
            var AmysInLaws = relationships.BrotherInLaw("Bob");
            var expected = new List<Person>() { };
            AmysInLaws.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void SisterInLawTest1()
        {
            var AmysInLaws = relationships.SisterInLaw("Bob");
            var expected = new List<Person>() {  };
            AmysInLaws.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void SonTest1()
        {
            var GeorgeSons = relationships.Son("George");
            var expected = new List<Person>() { bob, dave };
            GeorgeSons.Should().BeEquivalentTo(expected);
        }
        [Test]
        public void DaughterTest1()
        {
            var GeorgeSons = relationships.Daughter("George");
            var expected = new List<Person>() { sally };
            GeorgeSons.Should().BeEquivalentTo(expected);
        }
    }
}
