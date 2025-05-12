using FluentValidation;

namespace FSH.Starter.WebApi.Catalog.Application.Skills.Update.v1;
public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
{
    public UpdateSkillCommandValidator()
    {
        RuleFor(b => b.Name).MaximumLength(1000);
        RuleFor(b => b.TenantId).MaximumLength(64);
    }
}
