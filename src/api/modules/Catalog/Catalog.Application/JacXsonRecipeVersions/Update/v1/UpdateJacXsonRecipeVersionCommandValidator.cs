using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Update.v1;
public class UpdateJacXsonRecipeVersionCommandValidator : AbstractValidator<UpdateJacXsonRecipeVersionCommand>
{
    public UpdateJacXsonRecipeVersionCommandValidator()
    {
        RuleFor(b => b.InstalledBy).MaximumLength(1000);
    }
}
