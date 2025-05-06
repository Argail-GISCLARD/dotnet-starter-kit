using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsons.Create.v1;
public class CreateJacXsonCommandValidator : AbstractValidator<CreateJacXsonCommand>
{
    public CreateJacXsonCommandValidator()
    {
        RuleFor(b => b.SerialNumber).NotEmpty().MinimumLength(2).MaximumLength(100);
    }
}
