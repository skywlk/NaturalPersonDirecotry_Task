using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using NPD.Domain.Entities;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Interfaces;
using NPD.Domain.ViewModels;
using NPD.Infrastructure.EntityConfigurations;
using NPD.Infrastructure.Extensions;
using NPD.Infrastructure.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Context
{
    //dbcontext already is iunitofwork by default
    public class NPDContext : DbContext, IUnitOfWork
    {
        public const string Schema = "NPD";

        public DbSet<Person> People { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<RelatedPerson> RelatedPeople { get; set; }

        private readonly IMediator _mediator;

        public NPDContext()
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // if (!optionsBuilder.IsConfigured)
        //     // {
        //     //     optionsBuilder.UseSqlServer();
        //     // }
        // }

        public NPDContext(DbContextOptions<NPDContext> options) : base(options)
        {
        }

        public NPDContext(DbContextOptions<NPDContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);
            var result = await base.SaveChangesAsync();
            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
            modelBuilder.ApplyConfiguration(new RelatedPersonConfiguration());
            modelBuilder.ApplyConfiguration(new ClientRequestConfiguration()); 
            modelBuilder.ApplyConfiguration(new PersonsRelatedTypesByRelationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UnprocessedExceptionConfiguration());
        }
    }
}
