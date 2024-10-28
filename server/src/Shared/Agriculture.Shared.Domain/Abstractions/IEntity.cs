namespace Agriculture.Shared.Domain.Abstractions
{
    public interface IEntity : IAuditableInfo
    {
        string Id { get; set; }
    }
}
