using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Stands.Get.v1;
public class GetStandRequest : IRequest< StandResponse>
{
    public Guid Id { get; set; }
    public GetStandRequest(Guid id) => Id = id;
}
