using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Create.v1;
public class CreateJacXsonTypeCommandValidator : AbstractValidator<CreateJacXsonTypeCommand>
{
    public CreateJacXsonTypeCommandValidator()
    {
        RuleFor(rv => rv.Name).MaximumLength(1000);
    }
}
