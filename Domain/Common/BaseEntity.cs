using Domain.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        public void DeleteDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }
        public void CleanDomainEvent()
        {
            _domainEvents.Clear();
        }
    }
}
