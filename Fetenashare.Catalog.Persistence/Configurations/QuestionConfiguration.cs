using System;
using System.Collections.Generic;
using Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate;
using Fetenashare.Catalog.Domain.Aggregates.QuestionAggregate;
using Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate;
using Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Fetenashare.Catalog.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");
            builder.HasKey(q => q.Id);
            builder.HasOne<QuestionType>().WithMany().HasForeignKey(q => q.QuestionTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Subject>().WithMany().HasForeignKey(q => q.SubjectId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Topic>().WithMany().HasForeignKey(q => q.TopicId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne<Institution>().WithMany().HasForeignKey(q => q.InstitutionId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(q => q.Content).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v));
            builder.Property(q => q.IsDeleted);
            builder.Property(q => q.Created);
            builder.Property(q => q.Modified);
            builder.HasQueryFilter(q => !q.IsDeleted);
        }
    }
}
