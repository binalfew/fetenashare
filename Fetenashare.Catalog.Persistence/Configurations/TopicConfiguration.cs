using System;
using Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fetenashare.Catalog.Persistence.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired();
            builder.HasOne(t => t.Subject).WithMany(s => s.Topics).HasForeignKey(t => t.SubjectId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(t => t.IsDeleted);
            builder.Property(t => t.Created);
            builder.Property(t => t.Modified);
            builder.HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
