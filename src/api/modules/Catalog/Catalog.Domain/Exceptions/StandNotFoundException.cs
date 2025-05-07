using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class StandNotFoundException : NotFoundException
{
    public StandNotFoundException(Guid id)
        : base($"stand with id {id} not found")
    {
    }
}
