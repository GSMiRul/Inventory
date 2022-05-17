using Domain.Common.Interfaces;
using System;

namespace Domain.Entities
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
