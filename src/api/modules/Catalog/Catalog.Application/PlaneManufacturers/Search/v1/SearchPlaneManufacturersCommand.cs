using FSH.Framework.Core.Paging;
using FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Get.v1;
using MediatR;

namespace FSH.Starter.WebApi.Catalog.Application.PlaneManufacturers.Search.v1;

public class SearchPlaneManufacturersCommand : PaginationFilter, IRequest<PagedList<PlaneManufacturerResponse>>
{}
