using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Domain.ViewModels;
using NPD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class PersonsRelatedTypesByRelationTypeConfiguration : IEntityTypeConfiguration<PersonsRelatedTypesByRelationTypeReport>
    {
        public void Configure(EntityTypeBuilder<PersonsRelatedTypesByRelationTypeReport> builder)
        {
            builder.HasNoKey();
            builder.ToView("V_PersonsRelatedPeopleReport", NPDContext.Schema);
            builder.Property(x => x.PersonalNumber).HasColumnName("PersonalNumber");
            builder.Property(x => x.Firstname).HasColumnName("Firstname");
            builder.Property(x => x.Lastname).HasColumnName("Lastname");
            builder.Property(x => x.Count).HasColumnName("Count");
        }
    }
}
