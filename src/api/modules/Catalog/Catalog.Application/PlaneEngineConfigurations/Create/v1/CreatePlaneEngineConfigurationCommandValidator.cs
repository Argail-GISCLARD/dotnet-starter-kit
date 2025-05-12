using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Create.v1;
public class CreatePlaneEngineConfigurationCommandValidator : AbstractValidator<CreatePlaneEngineConfigurationCommand>
{
    public CreatePlaneEngineConfigurationCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
