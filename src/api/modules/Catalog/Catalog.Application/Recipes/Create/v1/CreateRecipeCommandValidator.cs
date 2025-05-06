using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Recipes.Create.v1;
public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
{
    public CreateRecipeCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
    }
}
