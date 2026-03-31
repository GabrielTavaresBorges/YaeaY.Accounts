namespace YaeaY.Account.Domain.Abstraction.Interfaces;

public interface IDomainEvent
{
    DateTimeOffset OccurredOnUtc { get; }
}
