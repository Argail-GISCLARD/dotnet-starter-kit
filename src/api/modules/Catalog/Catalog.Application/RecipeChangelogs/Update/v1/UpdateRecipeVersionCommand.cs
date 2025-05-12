using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Update.v1;
public sealed record UpdateRecipeChangelogCommand(
    Guid Id,
    string? Content = null,
    string? Summary = null) : IRequest<UpdateRecipeChangelogResponse>;
