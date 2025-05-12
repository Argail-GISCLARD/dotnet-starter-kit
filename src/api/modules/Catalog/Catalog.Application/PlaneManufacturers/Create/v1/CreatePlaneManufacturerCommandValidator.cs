using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Create.v1;
public class CreatePlaneManufacturerCommandValidator : AbstractValidator<CreatePlaneManufacturerCommand>
{
    public CreatePlaneManufacturerCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
