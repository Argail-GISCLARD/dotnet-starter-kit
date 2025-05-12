using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Create.v1;
public class CreatePlaneModelCommandValidator : AbstractValidator<CreatePlaneModelCommand>
{
    public CreatePlaneModelCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
