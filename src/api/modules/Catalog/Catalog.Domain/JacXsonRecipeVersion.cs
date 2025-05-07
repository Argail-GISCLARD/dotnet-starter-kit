using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;

namespace FSH.Starter.WebApi.Catalog.Domain;

public class JacXsonRecipeVersion : AuditableEntity, IAggregateRoot
{
    public DateTime InstalledOn { get; private set; } = DateTime.UtcNow;
    public string InstalledBy { get; private set; } = string.Empty;
    public Guid? JacXsonId { get; private set; }
    public JacXson JacXson { get; private set; } = default!;
    public Guid? RecipeId { get; private set; }
    public Recipe Recipe { get; private set; } = default!;

    private JacXsonRecipeVersion() { }

    private JacXsonRecipeVersion(Guid id, DateTime installedOn, string installedBy, Guid? jacXsonId, Guid? recipeId)
    {
        Id = id;
        InstalledOn = installedOn;
        InstalledBy = installedBy;
        QueueDomainEvent(new JacXsonRecipeVersionUpdated { JacXsonRecipeVersion = this });
    }

    public static JacXsonRecipeVersion Create(DateTime installedOn, string installedBy, Guid? jacXsonId, Guid? recipeId)
    {
        return new JacXsonRecipeVersion(Guid.NewGuid(), installedOn, installedBy, jacXsonId, recipeId);
    }

    public JacXsonRecipeVersion Update(DateTime? installedOn, string? installedBy, Guid? jacXsonId, Guid? recipeId)
    {
        bool isUpdated = false;

        if (installedOn.HasValue && InstalledOn != installedOn.Value)
        {
            InstalledOn = installedOn.Value;
            isUpdated = true;
        }

        if (!string.IsNullOrWhiteSpace(installedBy) && !string.Equals(InstalledBy, installedBy, StringComparison.OrdinalIgnoreCase))
        {
            InstalledBy = installedBy;
            isUpdated = true;
        }

        if (jacXsonId.HasValue && jacXsonId.Value != Guid.Empty && JacXsonId != jacXsonId.Value)
        {
            JacXsonId = jacXsonId.Value;
            isUpdated = true;
        }

        if (recipeId.HasValue && recipeId.Value != Guid.Empty && RecipeId != recipeId.Value)
        {
            RecipeId = recipeId.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new JacXsonRecipeVersionUpdated { JacXsonRecipeVersion = this });
        }

        return this;
    }
} 


