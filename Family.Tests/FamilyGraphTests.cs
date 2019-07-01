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

        [OneTimeSetUp]
        public void SetUp()
        {
            PersonStore = new PersonStore();
            Person george = PersonStore.AddPerson("George", Gender.Male);
            Person mary = PersonStore.AddPerson("Mary", Gender.Female);
            Person bob = PersonStore.AddPerson("Bob", Gender.Male);
            Person sally = PersonStore.AddPerson("Sally", Gender.Female);
            familyGraph = new FamilyGraph(PersonStore);
        }
        [Test]
        public void AddSpouseForExistingPeopleShouldNotThrowException()
        {
            Action act = ()=> familyGraph.AddRelationship("George", "Mary", "Spouse");
            act.Should().NotThrow();
        }
        [Test]
        public void AddParentForExistingPeopleShouldNotThrowException()
        {
            Action act = () => familyGraph.AddRelationship("Bob", "Sally", "Parent");
            act.Should().NotThrow();
        }
        
    }
}
