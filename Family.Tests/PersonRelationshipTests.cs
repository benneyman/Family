using Family.DTO;
using Family.Enums;
using Family.Implementation;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Family.Tests
{
    public class PersonRelationshipTests
    {
        Person bob = new Person("Bob", Gender.Male);

        [Test]
        public void AddingEdgeTest()
        {
            var personRelationship = new PersonRelationships();
            personRelationship.AddParent(bob);
            personRelationship.Parents.Should().BeEquivalentTo(new List<Person>() { bob });
        }
    }
}
