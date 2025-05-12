using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Delete.v1;
public sealed class DeleteJacXsonTypeHandler(
    ILogger<DeleteJacXsonTypeHandler> logger,
    [FromKeyedServices("catalog:jacxsontypes")] IRepository<JacXsonType> repository)
    : IRequestHandler<DeleteJacXsonTypeCommand>
{
    public async Task Handle(DeleteJacXsonTypeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var JacXsonType = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = JacXsonType ?? throw new JacXsonTypeNotFoundException(request.Id);
        await repository.DeleteAsync(JacXsonType, cancellationToken);
        logger.LogInformation("jacxson type with id : {JacXsonTypeId} deleted", JacXsonType.Id);
    }
}
