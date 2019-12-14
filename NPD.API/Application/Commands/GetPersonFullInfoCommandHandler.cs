using MediatR;
using NPD.Domain.DTOs;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class GetPersonFullInfoCommandHandler : IRequestHandler<GetPersonFullInfoCommand, PersonDTO>
    {
        private readonly IPersonPresenterService _personPresenterService;

        public GetPersonFullInfoCommandHandler(IPersonPresenterService personPresenterService)
        {
            _personPresenterService = personPresenterService;
        }

        public async Task<PersonDTO> Handle(GetPersonFullInfoCommand request, CancellationToken cancellationToken)
        {
            return await _personPresenterService.GetPersonFullInfoAsync(request.PersonId);
        }
    }
}
