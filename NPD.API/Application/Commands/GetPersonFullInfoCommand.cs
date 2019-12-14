using MediatR;
using NPD.Domain.DTOs;

namespace NPD.API.Application.Commands
{
    public class GetPersonFullInfoCommand : IRequest<PersonDTO>
    {
        public int PersonId { get; set; }
    }
}
