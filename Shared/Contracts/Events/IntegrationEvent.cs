namespace Shared.Contracts.Events;

/// <summary>
/// Base type for events published between services via the MessagingQueue service.
/// </summary>
public abstract record IntegrationEvent
{
    public Guid EventId { get; init; } = Guid.NewGuid();
    public DateTime OccurredAtUtc { get; init; } = DateTime.UtcNow;
}
