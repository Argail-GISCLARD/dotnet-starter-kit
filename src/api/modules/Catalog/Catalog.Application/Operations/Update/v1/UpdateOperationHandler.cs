using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Update.v1;
public sealed class UpdateOperationHandler(
    ILogger<UpdateOperationHandler> logger,
    [FromKeyedServices("catalog:operations")] IRepository<Operation> repository)
    : IRequestHandler<UpdateOperationCommand, UpdateOperationResponse>
{
    public async Task<UpdateOperationResponse> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = operation ?? throw new OperationNotFoundException(request.Id);
        var updatedOperation = operation.Update(request.Name, request.RecipeOperations);
        await repository.UpdateAsync(updatedOperation, cancellationToken);
        logger.LogInformation("operation with id : {OperationId} updated.", operation.Id);
        return new UpdateOperationResponse(operation.Id);
    }
}
