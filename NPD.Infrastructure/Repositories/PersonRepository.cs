using Microsoft.EntityFrameworkCore;
using NPD.Domain.DTOs;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Interfaces;
using NPD.Domain.ViewModels;
using NPD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NPDContext _context;

        public PersonRepository(NPDContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        //dbcontext already impliments iunitofwork
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public Person Add(Person entity)
        {
            if (entity.IsTransient())
            {
                return _context.People.Add(entity).Entity;
            }
            else
            {
                return entity;
            }
        }

        public void Delete(Person entity)
        {
            _context.People.Remove(entity);
        }

        public async Task<Person> FindByIdAsync(int Id)
        {
            return await _context.People.FindAsync(Id);
        }

        public Person Update(Person entity)
        {
            return _context.People.Update(entity).Entity;
        }

        public async Task<PersonDTO> GetPersonByIdWithRelatedPersonsAndPhoneNumbers(int id)
        {
            return await _context.People.Include(x => x.RelatedPeople).Include(x => x.PhoneNumbers).Where(x => x.Id == id)
                .Select(x => PersonDTO.CreateFrom(x, x.RelatedPeople.Select(r => RelatedPersonDTO.CreateFrom(r.Id,r.PersonId, (int)r.Type, PersonDTO.CreateFrom(_context.People.FirstOrDefault(p => p.Id == r.RPersonId),null)))))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Person>> FastSearchAsync(string firstname, string lastname, string personalNumber, int pageIndex = 1, int pageSize = 10)
        {
            var query = _context.People
                .Where(p => EF.Functions.Like(p.Firstname.Value, $"%{firstname}%") && EF.Functions.Like(p.Lastname.Value, $"%{lastname}%") && EF.Functions.Like(p.PersonalNumber, $"%{personalNumber}%"))
                .Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return await query.ToListAsync();

        }

        // TODO: create stored procedure for better performance
        public Task<IEnumerable<Person>> AdvansedSearchAsync(string firstname, string lastname, string personalNumber, DateTime birthDateFrom, DateTime birthDateTo, int pageIndex = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonsRelatedTypesByRelationTypeReport>> reportOfRelatedPersonsByRelationTypes()
        {
            return await _context.Set<PersonsRelatedTypesByRelationTypeReport>().ToListAsync();
        }
    }
}

