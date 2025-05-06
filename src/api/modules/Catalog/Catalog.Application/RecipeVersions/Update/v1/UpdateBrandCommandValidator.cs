using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Update.v1;
public class UpdateRecipeVersionCommandValidator : AbstractValidator<UpdateRecipeVersionCommand>
{
    public UpdateRecipeVersionCommandValidator()
    {
        RuleFor(b => b.VersionNumber).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(b => b.Description).MaximumLength(1000);
    }
}
