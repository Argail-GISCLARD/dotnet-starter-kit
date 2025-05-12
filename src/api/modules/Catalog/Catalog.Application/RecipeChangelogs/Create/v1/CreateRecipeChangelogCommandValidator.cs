using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Create.v1;
public class CreateRecipeChangelogCommandValidator : AbstractValidator<CreateRecipeChangelogCommand>
{
    public CreateRecipeChangelogCommandValidator()
    {
        RuleFor(rv => rv.Summary).MaximumLength(1000);
    }
}
