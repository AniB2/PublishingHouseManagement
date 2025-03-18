using MediatR;

namespace PublishingHouseManagement.Application.Products.Query.GetArchivedProducts
{
    public class GetArchivedProductsCommand : IRequest<List<GetArchivedProductsResponse>> { }
}