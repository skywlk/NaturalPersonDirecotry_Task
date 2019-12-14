using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class AddRelatedPersonCommandHandler : IRequestHandler<AddRelatedPersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public AddRelatedPersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.FindByIdAsync(request.PersonId);
            var relatedPerson = new RelatedPerson((RelationType)request.RelationType, request.RelatedPersonId, request.RelationId);
            
            if (request.Delete)
            {
                person.RemoveRelatedPerson(relatedPerson);
            }

            person.AddRelatedPerson(relatedPerson);

            return true;
        }
    }
}
