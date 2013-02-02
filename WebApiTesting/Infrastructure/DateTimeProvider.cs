using System;

namespace WebApiTesting.Infrastructure
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now()
        {
            return new DateTimeOffset(DateTime.UtcNow, TimeSpan.Zero);
        }
    }
}