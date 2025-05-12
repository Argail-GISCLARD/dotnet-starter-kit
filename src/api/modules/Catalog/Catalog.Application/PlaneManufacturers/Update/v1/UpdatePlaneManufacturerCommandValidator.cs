using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Update.v1;
public class UpdatePlaneManufacturerCommandValidator : AbstractValidator<UpdatePlaneManufacturerCommand>
{
    public UpdatePlaneManufacturerCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
