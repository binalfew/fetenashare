using System;
using Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fetenashare.Catalog.Persistence.Configurations
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("QuestionTypes");
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Name).IsRequired();
            builder.Property(q => q.IsDeleted);
            builder.Property(q => q.Created);
            builder.Property(q => q.Modified);
            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}
