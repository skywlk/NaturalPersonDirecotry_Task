using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Infrastructure.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class UploadPictureCommandHandler : IRequestHandler<UploadPictureCommand, string>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ImageManager _imageManager;

        public UploadPictureCommandHandler(IPersonRepository personRepository, ImageManager imageManager)
        {
            _personRepository = personRepository;
            _imageManager = imageManager;
        }

        public async Task<string> Handle(UploadPictureCommand request, CancellationToken cancellationToken)
        {
            var imagePath = await _imageManager.SaveBase64EncodedImageAsync(request.ImageData, request.PersonId);

            var person = await _personRepository.FindByIdAsync(request.PersonId);
            if (person == null)
            {
                throw new ArgumentException($"Person with id: {request.PersonId} not found");
            }

            person.UpdateImagePath(imagePath);
            await _personRepository.UnitOfWork.SaveEntitiesAsync();

            return await Task.FromResult(imagePath);
        }
    }
}
