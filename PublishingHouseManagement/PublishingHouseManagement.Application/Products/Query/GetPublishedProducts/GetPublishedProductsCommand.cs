using MediatR;

namespace PublishingHouseManagement.Application.Products.Query.GetPublishedProducts
{
    public class GetPublishedProductsCommand : IRequest<List<GetPublishedProductsResponse>> { }
}