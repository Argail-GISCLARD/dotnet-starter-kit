using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Delete.v1;
public sealed class DeleteStandHandler(
    ILogger<DeleteStandHandler> logger,
    [FromKeyedServices("catalog:stands")] IRepository<Stand> repository)
    : IRequestHandler<DeleteStandCommand>
{
    public async Task Handle(DeleteStandCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var Stand = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = Stand ?? throw new StandNotFoundException(request.Id);
        await repository.DeleteAsync(Stand, cancellationToken);
        logger.LogInformation("stand with id : {StandId} deleted", Stand.Id);
    }
}
