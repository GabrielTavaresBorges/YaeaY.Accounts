using YaeaY.Account.Domain.Abstraction.Entities;
using YaeaY.Account.Domain.Abstraction.Interfaces;
using YaeaY.Account.Infrastructure.Data.Context;
using YaeaY.Account.Infrastructure.Events.Dispatchers;

namespace YaeaY.Account.Infrastructure.Data.Persistence;

public sealed class UnityOfWork : IUnityOfWork
{
    private readonly AppDbContext _context;
    private readonly DomainEventDispatcher _domainEventDispatcher;

    public UnityOfWork(
        AppDbContext context,
        DomainEventDispatcher domainEventDispatcher)
    {
        _context = context;
        _domainEventDispatcher = domainEventDispatcher;
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        var entitiesWithEvents = _context.ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .Where(entity => entity.DomainEvents.Any())
            .ToList();

        var domainEvents = entitiesWithEvents
            .SelectMany(entity => entity.DomainEvents)
            .ToList();

        foreach (var entity in entitiesWithEvents)
        {
            entity.ClearDomainEvents();
        }

        await _context.SaveChangesAsync(cancellationToken);

        if (domainEvents.Count == 0)
            return;

        await _domainEventDispatcher.DispatchAsync(domainEvents, cancellationToken);
    }
}
