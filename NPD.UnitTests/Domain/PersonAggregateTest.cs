using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Exceptions;
using NPD.UnitTests.Domain.Stubs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NPD.UnitTests.Domain
{
    public class PersonAggregateTest
    {
        [Fact]
        public void CreatePersonAggregateSuccess()
        {
            var person = Person
                .Create(Name.Create("Johnny"), Name.Create("Cash"), Gender.Male, "12345678911", new BirthDate(new DateTime(1932, 9, 12), 
                new CurrentDateProviderStub()), 1, new []{ new PhoneNumber(PhoneType.Mobile, "123456789") }, "Images/image.jpg", new[] { new RelatedPerson(RelationType.Friend, 1) });
            Assert.NotNull(person);
        }

        [Fact]
        public void CreatePersonAggregateFail()
        {
            Assert.Throws<NPDDomainException>(() => Person
                .Create(null, Name.Create("Cash"), Gender.Male, "12345678911", new BirthDate(new DateTime(1932, 9, 12),
                new CurrentDateProviderStub()), 1, new[] { new PhoneNumber(PhoneType.Mobile, "123456789") }, "Images/image.jpg", new[] { new RelatedPerson(RelationType.Friend, 1) })
            );
        }

        [Fact]
        public void AddPhoneNumberForDomainEventCountCheckSuccess()
        {
            var person = Person
                .Create(Name.Create("Johnny"), Name.Create("Cash"), Gender.Male, "12345678911", new BirthDate(new DateTime(1932, 9, 12),
                new CurrentDateProviderStub()), 1, new[] { new PhoneNumber(PhoneType.Mobile, "123456789") }, "Images/image.jpg", new[] { new RelatedPerson(RelationType.Friend, 1) });
            person.AddPhoneNumber(new PhoneNumber(PhoneType.Home, "12345678"));

            Assert.Equal(person.DomainEvents.Count, 1);
        }
    }
}
