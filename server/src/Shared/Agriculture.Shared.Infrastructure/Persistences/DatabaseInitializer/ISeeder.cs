namespace Agriculture.Shared.Infrastructure.Persistences.DatabaseInitializer
{
    public interface ISeeder
    {
        Task SeedAsync(CancellationToken cancellationToken = default);
    }
}
