namespace Agriculture.Shared.Application.Events.Users
{
    public record UserCreatedEvent(string Id, string Email, string FirstName, string LastName);
}
