using MediatR;
using YaeaY.Account.Domain.Abstraction.Interfaces;

namespace YaeaY.Account.Application.Events.Notifications;

public sealed class DomainEventNotification<TDomainEvent> : INotification where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; }

    public DomainEventNotification(TDomainEvent domainEvent)
    {
        DomainEvent = domainEvent;
    }
}
