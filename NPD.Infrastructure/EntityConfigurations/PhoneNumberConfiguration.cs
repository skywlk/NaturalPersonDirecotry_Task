using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            builder.ToTable("PhoneNumbers", NPDContext.Schema);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Type).IsRequired();
        }
    }
}
