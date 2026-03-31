using YaeaY.Account.Domain.Abstraction.Interfaces;

namespace YaeaY.Account.Domain.Abstraction.Events;

public abstract record DomainEvent : IDomainEvent
{
    public DateTimeOffset OccurredOnUtc { get; init; } = DateTime.UtcNow;
}
