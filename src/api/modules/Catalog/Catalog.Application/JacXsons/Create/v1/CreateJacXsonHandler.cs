using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Create.v1;
public sealed class CreateJacXsonHandler(
    ILogger<CreateJacXsonHandler> logger,
    [FromKeyedServices("catalog:jacxsons")] IRepository<JacXson> repository)
    : IRequestHandler<CreateJacXsonCommand, CreateJacXsonResponse>
{
    public async Task<CreateJacXsonResponse> Handle(CreateJacXsonCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXson = JacXson.Create(request.SerialNumber!, request.Status, request.W0!, request.L!, request.Salt!);
        await repository.AddAsync(jacXson, cancellationToken);
        logger.LogInformation("jacxson created {JacXsonId}", jacXson.Id);
        return new CreateJacXsonResponse(jacXson.Id);
    }
}
