using NPD.Domain.DTOs;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Interfaces;
using NPD.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPD.Infrastructure.Services
{
    public class PersonPresenterService : IPersonPresenterService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IImageStoreage _imageStoreage;

        public PersonPresenterService(IPersonRepository personRepository, IImageStoreage imageStoreage)
        {
            _personRepository = personRepository;
            _imageStoreage = imageStoreage;
        }

        public async System.Threading.Tasks.Task<PersonDTO> GetPersonFullInfoAsync(int personId)
        {
            var personDto = await _personRepository.GetPersonByIdWithRelatedPersonsAndPhoneNumbers(personId);
            if (personDto != null && !string.IsNullOrEmpty(personDto.ImagePath))
            {
                var base64Image = await _imageStoreage.ReadImage(personDto.ImagePath);
                personDto.ImageBase64String = base64Image ?? "";
            }
            
            return personDto;
        }
    }
}
