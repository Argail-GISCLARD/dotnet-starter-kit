using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Create.v1;
public sealed record CreateRecipeStatusCommand(
    [property: DefaultValue(0)] int Status,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime ManufacturerDecisionOn,
    [property: DefaultValue("1970-01-01T00:00:00")] DateTime ExcentDecisionOn)
    : IRequest<CreateRecipeStatusResponse>;

