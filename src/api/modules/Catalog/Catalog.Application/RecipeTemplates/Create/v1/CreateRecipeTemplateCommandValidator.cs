using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Create.v1;
public class CreateRecipeTemplateCommandValidator : AbstractValidator<CreateRecipeTemplateCommand>
{
    public CreateRecipeTemplateCommandValidator()
    {
        RuleFor(rv => rv.VersionNumber).GreaterThanOrEqualTo(0);
        RuleFor(rv => rv.Description).MaximumLength(1000);
        RuleFor(rv => rv.Publisher).MaximumLength(1000);
    }
}
