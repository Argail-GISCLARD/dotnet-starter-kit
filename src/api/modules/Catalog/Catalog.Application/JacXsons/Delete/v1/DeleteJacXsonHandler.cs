using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Delete.v1;
public sealed class DeleteJacXsonHandler(
    ILogger<DeleteJacXsonHandler> logger,
    [FromKeyedServices("catalog:jacxsons")] IRepository<JacXson> repository)
    : IRequestHandler<DeleteJacXsonCommand>
{
    public async Task Handle(DeleteJacXsonCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXson = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXson ?? throw new JacXsonNotFoundException(request.Id);
        await repository.DeleteAsync(jacXson, cancellationToken);
        logger.LogInformation("jacxson with id : {JacXsonId} deleted", jacXson.Id);
    }
}
