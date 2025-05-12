using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonRecipeVersions.Create.v1;
public class CreateJacXsonRecipeVersionCommandValidator : AbstractValidator<CreateJacXsonRecipeVersionCommand>
{
    public CreateJacXsonRecipeVersionCommandValidator()
    {
        RuleFor(rv => rv.InstalledBy).MaximumLength(1000);
    }
}
