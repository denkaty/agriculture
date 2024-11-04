namespace Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync(CancellationToken cancellationToken);
    }
}
