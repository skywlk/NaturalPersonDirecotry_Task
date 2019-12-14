using NPD.Domain.Common;
using NPD.Domain.Events;
using NPD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public class Person : AggregateRoot
    {
        //For entity framework core
        private Person()
        {
        }

        public static Person Create(Name firstname, Name lastname, Gender gender, string personalNumber, BirthDate birthDate, int cityId, IEnumerable<PhoneNumber> phoneNumbers, string imagePath, IEnumerable<RelatedPerson> relatedPeople, int id = 0)
        {
            return new Person
            {
                Firstname = firstname ?? throw new NPDDomainException(nameof(firstname)),
                Lastname = lastname ?? throw new NPDDomainException(nameof(lastname)),
                Gender = Enum.IsDefined(typeof(Gender), gender) ? gender : throw new NPDDomainException(nameof(gender)),
                PersonalNumber = personalNumber == null || personalNumber.Length != 11 ? throw new NPDDomainException(nameof(personalNumber)) : personalNumber,
                BirthDate = birthDate ?? throw new NPDDomainException(nameof(birthDate)),
                CityId = cityId,
                ImagePath = imagePath,
                _phoneNumbers = phoneNumbers != null ? phoneNumbers.ToList() : throw new NPDDomainException(nameof(phoneNumbers)),
                _relatedPeople = relatedPeople != null ? relatedPeople.ToList() : throw new NPDDomainException(nameof(relatedPeople)),
                Id = id,
            };
        }

        public Gender Gender { get; protected set; }
        public string PersonalNumber { get; protected set; }
        
        public int CityId { get; protected set; }
        public string ImagePath { get; protected set; }

        //Owned types
        public Name Firstname { get; protected set; }
        public Name Lastname { get; protected set; }
        public BirthDate BirthDate { get; protected set; }

        //Backing fields
        private List<PhoneNumber> _phoneNumbers = new List<PhoneNumber>();
        public IReadOnlyList<PhoneNumber> PhoneNumbers => _phoneNumbers.AsReadOnly();

        private List<RelatedPerson> _relatedPeople = new List<RelatedPerson>();
        public IReadOnlyList<RelatedPerson> RelatedPeople => _relatedPeople.AsReadOnly();


        public void AddPhoneNumber(PhoneNumber phoneNumber)
        {
            _phoneNumbers.Add(phoneNumber);
            this.AddDomainEvent(new PhoneNumberAddedEvent(this, phoneNumber.Value));
        }

        public void AddRelatedPerson(RelatedPerson relatedPerson)
        {
            _relatedPeople.Add(relatedPerson);
        }

        public void RemoveRelatedPerson(RelatedPerson relatedPerson)
        {
            _relatedPeople.Remove(relatedPerson);
        }

        public void UpdateImagePath(string path)
        {
            ImagePath = path;
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
