using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.Operations.Get.v1;
public class GetOperationRequest : IRequest<OperationResponse>
{
    public Guid Id { get; set; }
    public GetOperationRequest(Guid id) => Id = id;
}
