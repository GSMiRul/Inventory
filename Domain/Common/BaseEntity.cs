using Domain.Common.Interfaces;
using System;

namespace Domain.Common
{
    public abstract class BaseEntity : IEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
