using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class AddRelatedPersonCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int RelationType { get; set; }
        public int RelationId { get; set; } = 0;
        public bool Delete { get; set; }
    }
}
