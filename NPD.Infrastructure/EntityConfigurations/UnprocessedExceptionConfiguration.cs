using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Domain.Entities;
using System;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class UnprocessedExceptionConfiguration : IEntityTypeConfiguration<UnprocessedException>
    {
        public void Configure(EntityTypeBuilder<UnprocessedException> builder)
        {
            builder.ToTable("UnprocessedExceptions", "Exc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ExceptionUuid).HasMaxLength(150);
            builder.Property(x => x.Level);
            builder.Property(x => x.ExceptionType).HasMaxLength(150);
            builder.Property(x => x.ExceptionData);
        }
    }
}
