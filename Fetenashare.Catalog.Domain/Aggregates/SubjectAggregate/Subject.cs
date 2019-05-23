using System;
using System.Collections.Generic;
using System.Linq;
using Fetenashare.Kernel;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.SubjectAggregate
{
    public class Subject : Entity, IAggregateRoot
    {
        public string Name { get; protected set; }

        private readonly List<Topic> _topics = new List<Topic>();
        public IReadOnlyCollection<Topic> Topics => _topics.AsReadOnly();

        public static Subject Create(string name)
        {
            return new Subject { Name = name };
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void AddTopic(Guid topicId, string name)
        {
            _topics.Add(Topic.Create(topicId, name));
        }

        public void UpdateTopic(Guid topicId, string name)
        {
            _topics.FirstOrDefault(t => t.Id == topicId)?.Update(name);
        }
    }
}