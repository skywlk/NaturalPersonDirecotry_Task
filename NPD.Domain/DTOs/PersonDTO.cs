using NPD.Domain.Entities.PersonAggreagete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPD.Domain.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<PhoneNumberDTO> PhoneNumbers { get; set; }
        public IEnumerable<RelatedPersonDTO> RelatedPeople { get; set; }
        public string ImageBase64String { get; set; }

        public static PersonDTO CreateFrom(Person person, IEnumerable<RelatedPersonDTO> relatedPeople)
        {
            return new PersonDTO()
            {
                Firstname = person.Firstname.Value,
                Lastname = person.Lastname.Value,
                Id = person.Id,
                BirthDate = person.BirthDate.Value,
                ImagePath = person.ImagePath,
                CityId = person.CityId,
                Gender = (int)person.Gender,
                PersonalNumber = person.PersonalNumber,
                PhoneNumbers = person.PhoneNumbers.Select(n => new PhoneNumberDTO { Type = (int)n.Type, Value = n.Value }),
                RelatedPeople = relatedPeople
            };
        }

    }
}
