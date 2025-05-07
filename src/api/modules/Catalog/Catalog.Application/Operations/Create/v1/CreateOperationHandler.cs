using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Create.v1;
public sealed class CreateOperationHandler(
    ILogger<CreateOperationHandler> logger,
    [FromKeyedServices("catalog:operations")] IRepository<Operation> repository)
    : IRequestHandler<CreateOperationCommand, CreateOperationResponse>
{
    public async Task<CreateOperationResponse> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var operation = Operation.Create(request.Name!);
        await repository.AddAsync(operation, cancellationToken);
        logger.LogInformation("operation created {OperationId}", operation.Id);
        return new CreateOperationResponse(operation.Id);
    }
}
