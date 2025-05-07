using System.Collections.ObjectModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Update.v1;
public sealed record UpdateOperationCommand(
    Guid Id,
    string? Name,
    Collection<RecipeOperation>? RecipeOperations) : IRequest<UpdateOperationResponse>;
