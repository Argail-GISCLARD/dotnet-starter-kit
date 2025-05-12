using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonEvents.Update.v1;
public class UpdateJacXsonEventCommandValidator : AbstractValidator<UpdateJacXsonEventCommand>
{
    public UpdateJacXsonEventCommandValidator()
    {
        RuleFor(b => b.JacXsonSerialNumber).MaximumLength(1000);
        RuleFor(b => b.EventName).MaximumLength(1000);
    }
}
