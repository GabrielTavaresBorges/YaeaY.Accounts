using YaeaY.Account.Domain.Entities.AggregateRoots.Users;

namespace YaeaY.Account.Domain.Repositories.Users;

public interface IUserRepository : IRepository<User>
{
    Task CreateUserAsync(User user, CancellationToken cancellationToken);
    Task UpdateUserAsync(User user, CancellationToken cancellationToken);    
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}