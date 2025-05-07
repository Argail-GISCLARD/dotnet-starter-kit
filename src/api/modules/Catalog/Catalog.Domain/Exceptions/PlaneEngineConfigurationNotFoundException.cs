using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class PlaneEngineConfigurationNotFoundException : NotFoundException
{
    public PlaneEngineConfigurationNotFoundException(Guid id)
        : base($"plane engine configuration with id {id} not found")
    {
    }
}
