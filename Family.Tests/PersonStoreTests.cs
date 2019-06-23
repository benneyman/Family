using Family.DTO;
using Family.Enums;
using Family.Implementation;
using Family.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Tests
{
    public class PersonStoreTests
    {
        [Test]
        public void AddNewPerson()
        {
            Person person = new Person("Name", Gender.Male);
            IPersonStore personStore = new PersonStore();
            personStore.Add(person);
            var actual = personStore.Contains("Name");
            actual.Should().Be(true);
        }
        [Test]
        public void AddingExistingPersonShouldThrowException()
        {
            Person person = new Person("Name", Gender.Male);
            IPersonStore personStore = new PersonStore();
            personStore.Add(person);
            Action act = () => personStore.Add(person);
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void NonExistantPersonContainsShouldReturnFalse()
        {
            Person person = new Person("Name", Gender.Male);
            IPersonStore personStore = new PersonStore();
            var actual = personStore.Contains("Name");
            actual.Should().Be(false);
        }


    }
}