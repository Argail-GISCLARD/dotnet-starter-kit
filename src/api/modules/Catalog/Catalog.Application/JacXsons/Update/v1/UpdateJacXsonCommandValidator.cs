using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Update.v1;
public class UpdateJacXsonCommandValidator : AbstractValidator<UpdateJacXsonCommand>
{
    public UpdateJacXsonCommandValidator()
    {
        RuleFor(b => b.SerialNumber).NotEmpty().MinimumLength(2).MaximumLength(100);
    }
}
