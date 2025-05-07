using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;

public class JacXson : AuditableEntity, IAggregateRoot
{
    public string SerialNumber { get; private set; } = string.Empty;
    public int Status { get; private set; } = 0;
    public string W0 { get; private set; } = string.Empty;
    public string L { get; private set; } = string.Empty;
    public string Salt { get; private set; } = string.Empty;
    public virtual ICollection<Post> Posts { get; private set; } = new Collection<Post>();

    private JacXson() { }

    private JacXson(Guid id, string serialNumber, int status, string w0, string l, string salt)
    {
        Id = id;
        SerialNumber = serialNumber;
        Status = status;
        W0 = w0;
        L = l;
        Salt = salt;
        QueueDomainEvent(new JacXsonUpdated { JacXson = this });
    }

    public static JacXson Create(string serialNumber, int status, string w0, string l, string salt)
    {
        return new JacXson(Guid.NewGuid(), serialNumber, status, w0, l, salt);
    }

    public JacXson Update(string? serialNumber, int? status, string? w0, string? l, string? salt)
    {
        bool isUpdated = false;

        if (!string.IsNullOrWhiteSpace(serialNumber) && !string.Equals(SerialNumber, serialNumber, StringComparison.OrdinalIgnoreCase))
        {
            SerialNumber = serialNumber;
            isUpdated = true;
        }

        if(status.HasValue && Status != status.Value)
        {
            Status = status.Value;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(l) && !string.Equals(L, l, StringComparison.OrdinalIgnoreCase))
        {
            L = l;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(salt) && !string.Equals(Salt, salt, StringComparison.OrdinalIgnoreCase))
        {
            Salt = salt;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(w0) && !string.Equals(W0, w0, StringComparison.OrdinalIgnoreCase))
        {
            W0 = w0;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new JacXsonUpdated { JacXson = this });
        }

        return this;
    }
} 


