using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Update.v1;
public class UpdateJacXsonTypeCommandValidator : AbstractValidator<UpdateJacXsonTypeCommand>
{
    public UpdateJacXsonTypeCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
    }
}
