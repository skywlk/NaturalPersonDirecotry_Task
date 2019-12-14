using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class DeletePeronCommandHandler : IRequestHandler<DeletePeronCommand, bool>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePeronCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<bool> Handle(DeletePeronCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.FindByIdAsync(request.PersonId);
            _personRepository.Delete(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
