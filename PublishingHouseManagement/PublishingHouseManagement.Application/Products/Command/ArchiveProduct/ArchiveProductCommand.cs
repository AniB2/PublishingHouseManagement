using MediatR;

namespace PublishingHouseManagement.Application.Products.Command.ArchiveProduct
{
    public class ArchiveProductCommand : IRequest<ArchiveProductResponse>
    {
        public int Id { get; set; }
    }
}