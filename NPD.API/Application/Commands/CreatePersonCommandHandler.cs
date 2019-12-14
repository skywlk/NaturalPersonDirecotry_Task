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
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IPersonRepository _personRepository;
        private readonly ICurrentDateProvider _dateProvider;

        public CreatePersonCommandHandler(IMediator mediator, IPersonRepository personRepository, ICurrentDateProvider dateProvider)
        {
            _mediator = mediator;
            _personRepository = personRepository;
            _dateProvider = dateProvider;
        }

        public async Task<bool> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var phoneNumbers = new List<PhoneNumber>();
            foreach (var item in request.PhoneNumbers)
            {
                phoneNumbers.Add(new PhoneNumber((PhoneType)item.Type, item.Value));
            }
            var people = new List<RelatedPerson>();
            foreach (var item in request.RelatedPeople)
            {
                people.Add(new RelatedPerson((RelationType)item.Type, item.PersonId));
            }

            var person = Person
                .Create(Name.Create(request.Firstname), Name.Create(request.Lastname), (Gender)request.Gender, request.PersonalNumber, new BirthDate(request.BirthDate, _dateProvider), request.CityId, phoneNumbers, request.ImagePath, people);
            
            _personRepository.Add(person);

            return await _personRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}

