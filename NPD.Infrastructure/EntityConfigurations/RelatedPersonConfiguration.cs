using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class RelatedPersonConfiguration : IEntityTypeConfiguration<RelatedPerson>
    {
        public void Configure(EntityTypeBuilder<RelatedPerson> builder)
        {
            builder.ToTable("RelatedPersons", NPDContext.Schema);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
