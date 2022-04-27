using Domain.Common.Interfaces;
using System;

namespace Domain.Common
{
    public abstract class AuditIdentityEntity : AuditableEntity, IEntity
    {
        public AuditIdentityEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
