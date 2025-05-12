using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Create.v1;
public class CreatePlaneEngineCommandValidator : AbstractValidator<CreatePlaneEngineCommand>
{
    public CreatePlaneEngineCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
