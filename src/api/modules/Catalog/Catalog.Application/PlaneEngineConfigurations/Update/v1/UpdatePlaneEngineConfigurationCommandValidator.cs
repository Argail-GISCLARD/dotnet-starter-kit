using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngineConfigurations.Update.v1;
public class UpdatePlaneEngineConfigurationCommandValidator : AbstractValidator<UpdatePlaneEngineConfigurationCommand>
{
    public UpdatePlaneEngineConfigurationCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
