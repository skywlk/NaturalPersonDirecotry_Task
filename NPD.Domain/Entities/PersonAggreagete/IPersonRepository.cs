using NPD.Domain.DTOs;
using NPD.Domain.Interfaces;
using NPD.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPD.Domain.Entities.PersonAggreagete
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<PersonDTO> GetPersonByIdWithRelatedPersonsAndPhoneNumbers(int id);
        Task<IEnumerable<Person>> FastSearchAsync(string firstname, string lastname, string personalNumber, int pageIndex = 1, int pageSize = 10);

        // TODO: should add more parameters and combine them as type
        Task<IEnumerable<Person>> AdvansedSearchAsync(string firstname, string lastname, string personalNumber, DateTime birthDateFrom, DateTime birthDateTo, int pageIndex = 1, int pageSize = 10);

        Task<IEnumerable<PersonsRelatedTypesByRelationTypeReport>> reportOfRelatedPersonsByRelationTypes();
    }
}
