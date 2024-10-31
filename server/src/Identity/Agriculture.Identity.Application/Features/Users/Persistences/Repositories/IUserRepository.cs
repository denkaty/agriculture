using Agriculture.Identity.Domain.Features.Users.Models.Entities;

namespace Agriculture.Identity.Application.Features.Users.Persistences.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken);
    }
}
