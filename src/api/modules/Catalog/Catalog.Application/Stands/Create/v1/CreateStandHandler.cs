using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Create.v1;
public sealed class CreateStandHandler(
    ILogger<CreateStandHandler> logger,
    [FromKeyedServices("catalog:stands")] IRepository<Stand> repository)
    : IRequestHandler<CreateStandCommand, CreateStandResponse>
{
    public async Task<CreateStandResponse> Handle(CreateStandCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var stand = Stand.Create(request.Name);        
        await repository.AddAsync(stand, cancellationToken);
        logger.LogInformation("stand created {StandId}", stand.Id);
        return new CreateStandResponse(stand.Id);
    }
}
