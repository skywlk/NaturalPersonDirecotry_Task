using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using System.Collections.Generic;

namespace NPD.API.Application.Commands
{
    public class FastSearchPersonCommand : IRequest<IEnumerable<Person>>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PersonalNumber { get; set; }
        public int Page { get; set; }

    }
}
