using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Domain.Entities;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Infrastructure.Context;
using System;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", NPDContext.Schema);
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.PersonalNumber).HasMaxLength(11).IsRequired();
            builder.HasIndex(x => x.PersonalNumber).IsUnique();

            builder.Property(x => x.ImagePath).HasMaxLength(500);
            builder.Ignore(x => x.DomainEvents);

            builder.OwnsOne(x => x.Firstname).Property(n => n.Value).HasColumnName("Firstname");
            builder.OwnsOne(x => x.Lastname).Property(n => n.Value).HasColumnName("Lastname");
            builder.OwnsOne(x => x.BirthDate).Property(d => d.Value).HasColumnName("BirthDate");
                        
            builder.HasMany(x => x.PhoneNumbers).WithOne();
            builder.HasMany(x => x.RelatedPeople).WithOne().HasForeignKey(r => r.PersonId).IsRequired();

            builder.Metadata.FindNavigation(nameof(Person.PhoneNumbers)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Person.RelatedPeople)).SetPropertyAccessMode(PropertyAccessMode.Field);
                        
            builder.Property<DateTime>("CreatedDate").HasDefaultValueSql("GETDATE()");
        }
    }
}
