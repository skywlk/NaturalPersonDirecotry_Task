using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class FastSearchPersonCommandHandler : IRequestHandler<FastSearchPersonCommand, IEnumerable<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public FastSearchPersonCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Handle(FastSearchPersonCommand request, CancellationToken cancellationToken)
        {
            return await _personRepository.FastSearchAsync(request.Firstname, request.Lastname, request.PersonalNumber, request.Page);
        }
    }
}
