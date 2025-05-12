using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using FSH.Starter.WebApi.Catalog.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Update.v1;
public sealed class UpdateJacXsonTypeHandler(
    ILogger<UpdateJacXsonTypeHandler> logger,
    [FromKeyedServices("catalog:jacxsontypes")] IRepository<JacXsonType> repository)
    : IRequestHandler<UpdateJacXsonTypeCommand, UpdateJacXsonTypeResponse>
{
    public async Task<UpdateJacXsonTypeResponse> Handle(UpdateJacXsonTypeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonType = await repository.GetByIdAsync(request.Id, cancellationToken);
        _ = jacXsonType ?? throw new JacXsonTypeNotFoundException(request.Id);
        var updatedJacXsonType = jacXsonType.Update(request.Name);
        await repository.UpdateAsync(updatedJacXsonType, cancellationToken);
        logger.LogInformation("jacxson type with id : {JacXsonTypeId} updated.", jacXsonType.Id);
        return new UpdateJacXsonTypeResponse(jacXsonType.Id);
    }
}
