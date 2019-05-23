using System;
using Fetenashare.Kernel;

namespace Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate
{
    public class Topic : Entity
    {
        public string Name { get; protected set; }

        public Guid SubjectId { get; protected set; }

        public Subject Subject { get; protected set; }

        public static Topic Create(Guid topicId, string name)
        {
            return new Topic { Id = topicId, Name = name };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
