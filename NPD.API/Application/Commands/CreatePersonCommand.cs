using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class CreatePersonCommand : IRequest<bool>
    {        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }
        public string PersonalNumber { get; set; }       
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public IEnumerable<PhoneNumberDTO> PhoneNumbers { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<RelatedPersonDTO> RelatedPeople { get; set; }
    }

    public class PhoneNumberDTO
    {
        public int Type { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
    }

    public class RelatedPersonDTO
    {
        public int Type { get; set; }
        public int PersonId { get; set; }
    }
}
