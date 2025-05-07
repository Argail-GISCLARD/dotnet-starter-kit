using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;

public class JacXsonEvent: AuditableEntity, IAggregateRoot
{
    public string JacXsonSerialNumber { get; private set; } = string.Empty;
    public DateTime OccuredAt { get; private set; } = DateTime.UtcNow;
    public string? Source{ get; private set; } = string.Empty;
    public string? EventName { get; private set; } = string.Empty;
    public string? Details { get; private set; } = string.Empty;

    private JacXsonEvent() { }

    private JacXsonEvent(Guid id, string jacXsonSerialNumber, DateTime occuredAt, string? source, string? eventName, string? details)
    {
        Id = id;
        JacXsonSerialNumber = jacXsonSerialNumber;
        OccuredAt = occuredAt;
        Source = source;
        EventName = eventName;
        Details = details;
        QueueDomainEvent(new JacXsonEventUpdated { JacXsonEvent = this });
    }

    public static JacXsonEvent Create(string jacXsonSerialNumber, DateTime occuredAt, string? source, string? eventName, string? details)
    {
        return new JacXsonEvent(Guid.NewGuid(), jacXsonSerialNumber, occuredAt, source, eventName, details);
    }

    public JacXsonEvent Update(string? jacXsonSerialNumber, DateTime? occuredAt, string? source, string? eventName, string? details)
    {
        bool isUpdated = false;

        if (jacXsonSerialNumber != null && jacXsonSerialNumber != JacXsonSerialNumber)
        {
            JacXsonSerialNumber = jacXsonSerialNumber;
            isUpdated = true;
        }

        if (occuredAt != null && occuredAt != OccuredAt)
        {
            OccuredAt = occuredAt.Value;
            isUpdated = true;
        }

        if (source != null && source != Source)
        {
            Source = source;
            isUpdated = true;
        }

        if (eventName != null && eventName != EventName)
        {
            EventName = eventName;
            isUpdated = true;
        }

        if (details != null && details != Details)
        {
            Details = details;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new JacXsonEventUpdated { JacXsonEvent = this });
        }

        return this;
    }
} 


