using MediatR;

namespace PublishingHouseManagement.Application.Products.Command.PublishProduct
{
    public class PublishProductCommand : IRequest<PublishProductResponse>
    {
        public int Id { get; set; }
    }
}