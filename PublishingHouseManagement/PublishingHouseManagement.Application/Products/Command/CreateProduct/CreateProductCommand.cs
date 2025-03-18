using MediatR;
using PublishingHouseManagement.Application.Common.Enums;

namespace PublishingHouseManagement.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Annotation { get; set; }
        public ProductType ProductType { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PublishingHouse { get; set; }
        public string Address { get; set; }
        public string NumberOfPages { get; set; }
    }
}