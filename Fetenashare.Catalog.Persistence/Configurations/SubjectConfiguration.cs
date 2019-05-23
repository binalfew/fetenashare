using System;
using Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fetenashare.Catalog.Persistence.Configurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.IsDeleted);
            builder.Property(s => s.Created);
            builder.Property(s => s.Modified);

            builder.HasQueryFilter(s => !s.IsDeleted);
            builder.Metadata.FindNavigation(nameof(Subject.Topics)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}