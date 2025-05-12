using System.Collections.ObjectModel;
using System.ComponentModel;
using FSH.Starter.WebApi.Catalog.Domain;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.JacXsonTypes.Update.v1;
public sealed record UpdateJacXsonTypeCommand(
    Guid Id,
    string Name) : IRequest<UpdateJacXsonTypeResponse>;
