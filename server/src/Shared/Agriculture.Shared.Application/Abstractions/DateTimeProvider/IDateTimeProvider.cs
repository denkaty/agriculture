namespace Agriculture.Shared.Application.Abstractions.DateTimeProvider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
