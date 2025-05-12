using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeTemplate : AuditableEntity, IAggregateRoot
{
    public int VersionNumber { get; private set; } = 1;
    public bool IsMandatory { get; private set; }
    public bool IsPaid { get; private set; }
    public string? Description { get; private set; }
    public DateTime RealeasedOn { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    public string? Publisher { get; private set; } = string.Empty;
    public Guid? RecipeTemplateContentId { get; private set; } = default!;
    public virtual RecipeTemplateContent RecipeTemplateContent { get; private set; } = default!;

    private RecipeTemplate() { }

    private RecipeTemplate(Guid id, int versionNumber, string? description, bool isMandatory, bool isPaid, DateTime releasedOn, DateTime updatedOn, string? publisher, Guid? recipeTemplateContentId )
    {
        Id = id;
        VersionNumber = versionNumber;
        IsMandatory = isMandatory;
        IsPaid = isPaid;
        Description = description;
        RealeasedOn = releasedOn;
        UpdatedOn = updatedOn;
        Publisher = publisher;
        RecipeTemplateContentId = recipeTemplateContentId;
        QueueDomainEvent(new RecipeTemplateCreated { RecipeTemplate = this });
    }

    public static RecipeTemplate Create(int versionNumber, string? description, bool isMandatory, bool isPaid, DateTime releasedOn, DateTime updatedOn, string? publisher, Guid? recipeTemplateContentId)
    {
        return new RecipeTemplate(Guid.NewGuid(), versionNumber, description, isMandatory, isPaid, releasedOn, updatedOn, publisher, recipeTemplateContentId);
    }

    public RecipeTemplate Update(int? versionNumber, string? description, bool? isMandatory, bool? isPaid, DateTime? releasedOn, DateTime? updatedOn, string? publisher, Guid? recipeTemplateContentId)
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

        if (isPaid.HasValue && isPaid.Value != IsPaid)
        {
            IsPaid = isPaid.Value;
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

        if (recipeTemplateContentId.HasValue && recipeTemplateContentId.Value != RecipeTemplateContentId)
        {
            RecipeTemplateContentId = recipeTemplateContentId.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeTemplateUpdated { RecipeTemplate = this });
        }

        return this;
    }
}


