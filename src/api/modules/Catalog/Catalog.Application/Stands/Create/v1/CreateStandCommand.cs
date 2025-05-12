using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Create.v1;
public sealed record CreateStandCommand(
    [property: DefaultValue("Stand Name")] string Name) 
    : IRequest<CreateStandResponse>;

