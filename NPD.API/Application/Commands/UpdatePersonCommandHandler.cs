using MediatR;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.API.Application.Commands
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, int>
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICurrentDateProvider _currentDateProvider;

        public UpdatePersonCommandHandler(IPersonRepository personRepository, ICurrentDateProvider currentDateProvider)
        {
            _personRepository = personRepository;
            _currentDateProvider = currentDateProvider;
        }

        public async Task<int> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.FindByIdAsync(request.PersonId);
            var phoneNumbers = request.PhoneNumbers.Select(x => new PhoneNumber((PhoneType)x.Type, x.Value, x.Id));
            var updatedPerson = Person.Create(Name.Create(request.Firstname), Name.Create(request.Lastname), (Gender)request.Gender, request.PersonalNumber, new BirthDate(request.BirthDate, _currentDateProvider), request.CityId, phoneNumbers, person.ImagePath, person.RelatedPeople, person.Id);

            _personRepository.Update(updatedPerson);
            
            return await _personRepository.UnitOfWork.SaveChangesAsync(); 
        }
    }
}
