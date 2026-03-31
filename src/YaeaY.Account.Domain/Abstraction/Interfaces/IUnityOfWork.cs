namespace YaeaY.Account.Domain.Abstraction.Interfaces;

public interface IUnityOfWork
{
    Task CommitAsync(CancellationToken cancellationToken = default);
}
