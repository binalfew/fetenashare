using System;
using System.Collections.Generic;
using Fetenashare.Kernel;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.QuestionAggregate
{
    public class Question : Entity, IAggregateRoot
    {
        public Guid SubjectId { get; protected set; }

        public Guid TopicId { get; protected set; }

        public Guid InstitutionId { get; protected set; }

        public Guid QuestionTypeId { get; protected set; }

        public Dictionary<string, string> Content { get; protected set; } = new Dictionary<string, string>();

        public static Question Create(Guid subjectId, Guid topicId, Guid institutionId, Guid questionTypeId, Dictionary<string, string> content)
        {
            return new Question
            {
                SubjectId = subjectId,
                TopicId = topicId,
                InstitutionId = institutionId,
                QuestionTypeId = questionTypeId,
                Content = content
            };
        }
    }
}
