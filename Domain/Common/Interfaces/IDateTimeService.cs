using System;

namespace Domain.Common.Interfaces
{
    public interface IDateTimeService
    {
        public DateTime NowUtc { get; }
    }
}
