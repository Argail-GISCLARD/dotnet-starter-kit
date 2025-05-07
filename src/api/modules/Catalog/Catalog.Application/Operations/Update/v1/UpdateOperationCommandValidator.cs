using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Update.v1;
public class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
{
    public UpdateOperationCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
    }
}
