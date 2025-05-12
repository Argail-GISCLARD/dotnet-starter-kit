using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeStatuses.Update.v1;
public class UpdateRecipeStatusCommandValidator : AbstractValidator<UpdateRecipeStatusCommand>
{
    public UpdateRecipeStatusCommandValidator()
    {
        RuleFor(b => b.Status).GreaterThanOrEqualTo(0);
    }
}
