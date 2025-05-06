using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeVersion : AuditableEntity, IAggregateRoot
{
    public int VersionNumber { get; private set; } = 1;
    public bool IsMandatory { get; private set; } = false;
    public string? Description { get; private set; }
    public DateTime RealeasedOn { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    public string? Publisher { get; private set; } = string.Empty;

    private RecipeVersion() { }

    private RecipeVersion(Guid id, int versionNumber, string? description, bool isMandatory, DateTime releasedOn, DateTime updatedOn, string? publisher)
    {
        Id = id;
        VersionNumber = versionNumber;
        IsMandatory = isMandatory;
        Description = description;
        RealeasedOn = releasedOn;
        UpdatedOn = updatedOn;
        Publisher = publisher;
        QueueDomainEvent(new RecipeVersionCreated { RecipeVersion = this });
    }

    public static RecipeVersion Create(int versionNumber, string? description, bool isMandatory, DateTime releasedOn, DateTime updatedOn, string? publisher)
    {
        return new RecipeVersion(Guid.NewGuid(), versionNumber, description, isMandatory, releasedOn, updatedOn, publisher);
    }

    public RecipeVersion Update(int? versionNumber, string? description, bool? isMandatory, DateTime? releasedOn, DateTime? updatedOn, string? publisher)
    {
        bool isUpdated = false;

        if (versionNumber.HasValue && versionNumber.Value != VersionNumber)
        {
            VersionNumber = versionNumber.Value;
            isUpdated = true;
        }

        if (isMandatory.HasValue && isMandatory.Value != IsMandatory)
        {
            IsMandatory = isMandatory.Value;
            isUpdated = true;
        }

        if (!string.Equals(Description, description, StringComparison.OrdinalIgnoreCase))
        {
            Description = description;
            isUpdated = true;
        }

        if (releasedOn.HasValue && releasedOn.Value != RealeasedOn)
        {
            RealeasedOn = releasedOn.Value;
            isUpdated = true;
        }

        if (updatedOn.HasValue && updatedOn.Value != UpdatedOn)
        {
            UpdatedOn = updatedOn.Value;
            isUpdated = true;
        }

        if (!string.Equals(Publisher, publisher, StringComparison.OrdinalIgnoreCase))
        {
            Publisher = publisher;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeVersionUpdated { RecipeVersion = this });
        }

        return this;
    }
}


