using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Create.v1;
public sealed record CreateJacXsonTypeCommand(
    [property: DefaultValue("JacXson Type Name")] string Name)
    : IRequest<CreateJacXsonTypeResponse>;

