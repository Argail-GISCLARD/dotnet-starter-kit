using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeChangelogs.Update.v1;
public class UpdateRecipeChangelogCommandValidator : AbstractValidator<UpdateRecipeChangelogCommand>
{
    public UpdateRecipeChangelogCommandValidator()
    {
        RuleFor(b => b.Summary).MaximumLength(1000);
    }
}
