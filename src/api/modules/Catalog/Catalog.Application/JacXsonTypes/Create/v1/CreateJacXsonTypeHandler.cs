using FSH.Framework.Core.Persistence;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Create.v1;
public sealed class CreateJacXsonTypeHandler(
    ILogger<CreateJacXsonTypeHandler> logger,
    [FromKeyedServices("catalog:jacxsontypes")] IRepository<JacXsonType> repository)
    : IRequestHandler<CreateJacXsonTypeCommand, CreateJacXsonTypeResponse>
{
    public async Task<CreateJacXsonTypeResponse> Handle(CreateJacXsonTypeCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var jacXsonType = JacXsonType.Create(request.Name);        
        await repository.AddAsync(jacXsonType, cancellationToken);
        logger.LogInformation("jacxson type created {JacXsonTypeId}", jacXsonType.Id);
        return new CreateJacXsonTypeResponse(jacXsonType.Id);
    }
}
