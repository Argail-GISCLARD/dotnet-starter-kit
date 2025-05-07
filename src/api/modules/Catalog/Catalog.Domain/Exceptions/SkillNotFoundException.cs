using FSH.Framework.Core.Exceptions;

namespace FSH.Starter.WebApi.Catalog.Domain.Exceptions;
public sealed class SkillNotFoundException : NotFoundException
{
    public SkillNotFoundException(Guid id)
        : base($"skill with id {id} not found")
    {
    }
}
