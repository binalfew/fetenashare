using System;
using Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fetenashare.Catalog.Persistence.Configurations
{
    public class InstitutionConfiguration : IEntityTypeConfiguration<Institution>
    {
        public void Configure(EntityTypeBuilder<Institution> builder)
        {
            builder.ToTable("Institutions");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.IsDeleted);
            builder.Property(i => i.Created);
            builder.Property(i => i.Modified);
            builder.HasQueryFilter(i => !i.IsDeleted);
        }
    }
}
