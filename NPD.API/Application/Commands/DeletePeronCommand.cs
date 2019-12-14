using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class DeletePeronCommand : IRequest<bool>
    {
        public int PersonId { get; set; }
    }
}
