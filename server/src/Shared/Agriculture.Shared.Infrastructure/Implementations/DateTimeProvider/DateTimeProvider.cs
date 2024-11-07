using Agriculture.Shared.Application.Abstractions.DateTimeProvider;

namespace Agriculture.Shared.Infrastructure.Implementations.DateTimeProvider
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
