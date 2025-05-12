using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Update.v1;
public sealed record UpdateRecipeStatusCommand(
    Guid Id,
    int Status,
    DateTime ManufacturerDecisionOn,
    DateTime ExcentDecisionOn) : IRequest<UpdateRecipeStatusResponse>;
