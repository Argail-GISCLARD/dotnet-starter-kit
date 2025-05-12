using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneModels.Update.v1;
public class UpdatePlaneModelCommandValidator : AbstractValidator<UpdatePlaneModelCommand>
{
    public UpdatePlaneModelCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
