namespace Agriculture.Shared.Domain.Abstractions
{
    public interface IAuditableInfo
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
