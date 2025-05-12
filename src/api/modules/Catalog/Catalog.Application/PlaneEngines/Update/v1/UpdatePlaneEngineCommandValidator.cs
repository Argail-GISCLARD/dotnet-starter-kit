using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneEngines.Update.v1;
public class UpdatePlaneEngineCommandValidator : AbstractValidator<UpdatePlaneEngineCommand>
{
    public UpdatePlaneEngineCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
