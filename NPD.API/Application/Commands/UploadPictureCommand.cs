using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class UploadPictureCommand : IRequest<string>
    {
        public int PersonId { get; set; }
        public string ImageData { get; set; }

    }
}
