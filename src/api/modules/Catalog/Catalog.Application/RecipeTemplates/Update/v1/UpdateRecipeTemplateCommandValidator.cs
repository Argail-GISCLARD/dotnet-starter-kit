using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.RecipeTemplates.Update.v1;
public class UpdateRecipeTemplateCommandValidator : AbstractValidator<UpdateRecipeTemplateCommand>
{
    public UpdateRecipeTemplateCommandValidator()
    {
        RuleFor(b => b.VersionNumber).GreaterThanOrEqualTo(0);
        RuleFor(b => b.Description).MaximumLength(1000);
        RuleFor(b => b.Publisher).MaximumLength(1000);
    }
}
