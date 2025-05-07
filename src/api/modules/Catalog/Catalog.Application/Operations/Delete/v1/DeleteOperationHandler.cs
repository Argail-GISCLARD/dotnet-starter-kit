using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Delete.v1;
public sealed class DeleteOperationHandler(
    ILogger<DeleteOperationHandler> logger,
    [FromKeyedServices("catalog:operations")] IRepository<Operation> repository)
    : IRequestHandler<DeleteOperationCommand>
{
    public async Task Handle(DeleteOperationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = operation ?? throw new OperationNotFoundException(request.Id);
        await repository.DeleteAsync(operation, cancellationToken);
        logger.LogInformation("operation with id : {OperationId} deleted", operation.Id);
    }
}
