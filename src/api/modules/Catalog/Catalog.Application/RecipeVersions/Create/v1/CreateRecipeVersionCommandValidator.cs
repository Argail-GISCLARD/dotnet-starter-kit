using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeVersions.Create.v1;
public class CreateRecipeVersionCommandValidator : AbstractValidator<CreateRecipeVersionCommand>
{
    public CreateRecipeVersionCommandValidator()
    {
        RuleFor(rv => rv.VersionNumber).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(rv => rv.Description).MaximumLength(1000);
    }
}
