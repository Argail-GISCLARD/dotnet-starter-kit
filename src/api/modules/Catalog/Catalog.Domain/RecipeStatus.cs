using System.Collections.ObjectModel;
using FSH.Framework.Core.Domain;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Starter.WebApi.Catalog.Domain.Events;
using Microsoft.VisualBasic;

namespace FSH.Starter.WebApi.Catalog.Domain;
public class RecipeStatus : AuditableEntity, IAggregateRoot
{
    public DateTime ManufacturerDecisionOn { get; set; } = DateTime.UtcNow;
    public DateTime ExcenDecisionOn { get; set; } = DateTime.UtcNow;
    public int Status { get; set; } = 0;
    public virtual RecipeVersion RecipeVersion { get; private set; } = default!;

    private RecipeStatus() { }

    private RecipeStatus(Guid id, int status, DateTime manufacturerDecisionOn, DateTime excentDecisionOn)
    {
        Id = id;
        Status = status;
        ManufacturerDecisionOn = manufacturerDecisionOn;
        ExcenDecisionOn = excentDecisionOn;
        QueueDomainEvent(new RecipeStatusCreated { RecipeStatus = this });
    }

    public static RecipeStatus Create(int status, DateTime manufacturerDecisionOn, DateTime excentDecisionOn)
    {
        return new RecipeStatus(Guid.NewGuid(), status, manufacturerDecisionOn, excentDecisionOn);
    }

    public RecipeStatus Update(int? status, DateTime? manufacturerDecisionOn, DateTime? excentDecisionOn)
    {
        bool isUpdated = false;

        if (status.HasValue && status != Status)
        {
            Status = status.Value;
            isUpdated = true;
        }

        if (manufacturerDecisionOn.HasValue && manufacturerDecisionOn != ManufacturerDecisionOn)
        {
            ManufacturerDecisionOn = manufacturerDecisionOn.Value;
            isUpdated = true;
        }

        if (excentDecisionOn.HasValue && excentDecisionOn != ExcenDecisionOn)
        {
            ExcenDecisionOn = excentDecisionOn.Value;
            isUpdated = true;
        }

        if (isUpdated)
        {
            QueueDomainEvent(new RecipeStatusUpdated { RecipeStatus = this });
        }

        return this;
    }
}
