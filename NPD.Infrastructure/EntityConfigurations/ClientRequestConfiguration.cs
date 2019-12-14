using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPD.Infrastructure.Context;
using NPD.Infrastructure.RequestStash;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Infrastructure.EntityConfigurations
{
    public class ClientRequestConfiguration : IEntityTypeConfiguration<ClientRequest>
    {
        public void Configure(EntityTypeBuilder<ClientRequest> builder)
        {
            builder.ToTable("ClientRequests", "Req");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Time).HasDefaultValue(DateTime.Now);
        }
    }
}
