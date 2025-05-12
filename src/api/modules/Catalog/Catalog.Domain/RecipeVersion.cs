using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeVersion : AuditableEntity, IAggregateRoot
{
    public int VersionNumber { get; private set; } = 1;
    public bool IsMandatory { get; private set; }
    public bool IsPaid { get; private set; }
    public string? Description { get; private set; }
    public DateTime RealeasedOn { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedOn { get; private set; } = DateTime.UtcNow;
    public string? Publisher { get; private set; } = string.Empty;
    public virtual Collection<Operation> Operations { get; private set; } = [];
    public virtual Collection<JacXsonRecipeVersion> JacXsonRecipeVersions { get; private set; } = [];
    public virtual Collection<Skill> Skills { get; private set; } = [];
    public Guid? RecipeId { get; private set; }
    public Recipe Recipe { get; private set; } = default!;
    public Guid? JacXsonTypeId { get; private set; }
    public JacXsonType JacXsonType { get; private set; } = default!;
    public Guid? RecipeStatusId { get; private set; }
    public RecipeStatus RecipeStatus { get; private set; } = default!;
    public Guid? RecipeContentId { get; private set; }
    public RecipeContent RecipeContent { get; private set; } = default!;
    public Guid? RecipeChangelogId { get; private set; }
    public RecipeChangelog RecipeChangelog { get; private set; } = default!;

    private RecipeVersion() { }

    private RecipeVersion(Guid id, int versionNumber, string? description, bool isMandatory, bool isPaid, DateTime releasedOn, DateTime updatedOn, string? publisher, Guid? recipeId, Guid? jacXsonTypeId, Guid? recipeStatusId, Guid? recipeContentId, Guid? recipeChangelogId )
    {
        Id = id;
        VersionNumber = versionNumber;
        IsMandatory = isMandatory;
        IsPaid = isPaid;
        Description = description;
        RealeasedOn = releasedOn;
        UpdatedOn = updatedOn;
        Publisher = publisher;
        RecipeId = recipeId;
        JacXsonTypeId = jacXsonTypeId;
        RecipeStatusId = recipeStatusId;
        RecipeContentId = recipeContentId;
        RecipeChangelogId = recipeChangelogId;
        QueueDomainEvent(new RecipeVersionCreated { RecipeVersion = this });
    }

    public static RecipeVersion Create(int versionNumber, string? description, bool isMandatory, bool isPaid, DateTime releasedOn, DateTime updatedOn, string? publisher, Guid? recipeId, Guid? jacXsonTypeId, Guid? recipeStatusId, Guid? recipeContentId, Guid? recipeChangelogId)
    {
        return new RecipeVersion(Guid.NewGuid(), versionNumber, description, isMandatory, isPaid, releasedOn, updatedOn, publisher, recipeId, jacXsonTypeId, recipeStatusId, recipeContentId, recipeChangelogId);
    }

    public RecipeVersion Update(int? versionNumber, string? description, bool? isMandatory, bool? isPaid, DateTime? releasedOn, DateTime? updatedOn, string? publisher, Collection<Operation>? operations,
        Guid? recipeId, Guid? jacXsonTypeId, Guid? recipeStatusId, Guid? recipeContentId, Guid? recipeChangelogId, Collection<JacXsonRecipeVersion>? jacXsonRecipeVersions, Collection<Skill>? skills)
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

        if (isPaid.HasValue && isPaid.Value != IsMandatory)
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

        if (operations != null && !operations!.Equals(Operations))
        {
            Operations = operations;
            isUpdated = true;
        }

        if (skills != null && !skills!.Equals(Skills))
        {
            Skills = skills;
            isUpdated = true;
        }

        if (jacXsonRecipeVersions != null && !jacXsonRecipeVersions!.Equals(JacXsonRecipeVersions))
        {
            JacXsonRecipeVersions = jacXsonRecipeVersions;
            isUpdated = true;
        }

        if (recipeId.HasValue && recipeId.Value != Guid.Empty && RecipeId != recipeId.Value)
        {
            RecipeId = recipeId.Value;
            isUpdated = true;
        }

        if (jacXsonTypeId.HasValue && jacXsonTypeId.Value != Guid.Empty && JacXsonTypeId != jacXsonTypeId.Value)
        {
            JacXsonTypeId = jacXsonTypeId.Value;
            isUpdated = true;
        }

        if (recipeStatusId.HasValue && recipeStatusId.Value != Guid.Empty && RecipeStatusId != recipeStatusId.Value)
        {
            RecipeStatusId = recipeStatusId.Value;
            isUpdated = true;
        }

        if (recipeContentId.HasValue && recipeContentId.Value != Guid.Empty && RecipeContentId != recipeContentId.Value)
        {
            RecipeContentId = recipeContentId.Value;
            isUpdated = true;
        }

        if (recipeChangelogId.HasValue && recipeChangelogId.Value != Guid.Empty && RecipeChangelogId != recipeChangelogId.Value)
        {
            RecipeChangelogId = recipeChangelogId.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeVersionUpdated { RecipeVersion = this });
        }

        return this;
    }
}


