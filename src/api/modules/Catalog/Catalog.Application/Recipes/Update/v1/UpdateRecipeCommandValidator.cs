using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Update.v1;
public class UpdateRecipeCommandValidator : AbstractValidator<UpdateRecipeCommand>
{
    public UpdateRecipeCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().MinimumLength(2).MaximumLength(100);
    }
}
