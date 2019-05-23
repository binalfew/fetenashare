using System;
using System.Collections.Generic;
using MediatR;

namespace Fetenashare.Kernel
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }

        public bool IsDeleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        protected Entity()
        {
            IsDeleted = false;
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetType() != other.GetType()) return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty) return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => a != null && !a.Equals(b);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}