using Fetenashare.Kernel;
using Fetenashare.Kernel.Interfaces;

namespace Fetenashare.Catalog.Domain.Aggregates.InstitutionAggregate
{
    public class Institution : Entity, IAggregateRoot
    {
        public string Name { get; protected set; }

        public static Institution Create(string name)
        {
            return new Institution { Name = name };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
