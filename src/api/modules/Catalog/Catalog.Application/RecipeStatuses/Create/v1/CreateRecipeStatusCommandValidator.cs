using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Create.v1;
public class CreateRecipeStatusCommandValidator : AbstractValidator<CreateRecipeStatusCommand>
{
    public CreateRecipeStatusCommandValidator()
    {
        RuleFor(rv => rv.Status).GreaterThanOrEqualTo(0);
    }
}
