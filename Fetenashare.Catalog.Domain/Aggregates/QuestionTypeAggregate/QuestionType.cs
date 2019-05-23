using System;
using System.Collections.Generic;
using Fetenashare.Kernel;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.QuestionTypeAggregate
{
    public class QuestionType : Entity, IAggregateRoot
    {
        public string Name { get; protected set; }

        public static QuestionType Create(string name)
        {
            return new QuestionType { Name = name };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
