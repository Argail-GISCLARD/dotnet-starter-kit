using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Create.v1;
public class CreateJacXsonEventCommandValidator : AbstractValidator<CreateJacXsonEventCommand>
{
    public CreateJacXsonEventCommandValidator()
    {
        RuleFor(rv => rv.JacXsonSerialNumber).MaximumLength(1000);
        RuleFor(rv => rv.EventName).MaximumLength(1000);
    }
}
