using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    /// <summary>
    /// ფიზიკური პირის ძირითადი ინფორმაციის ცვლილება, რომელიც მოიცავს შემდეგ მონაცემებს: სახელი, გვარი, სქესი, პირადი ნომერი, დაბადების თარიღი, ქალაქი, ტელეფონის ნომრები
    /// </summary>
    public class UpdatePersonCommand : IRequest<int>
    {
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Gender { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public IEnumerable<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}
