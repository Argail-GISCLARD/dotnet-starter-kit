using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Create.v1;
public class CreateOperationCommandValidator : AbstractValidator<CreateOperationCommand>
{
    public CreateOperationCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
    }
}
