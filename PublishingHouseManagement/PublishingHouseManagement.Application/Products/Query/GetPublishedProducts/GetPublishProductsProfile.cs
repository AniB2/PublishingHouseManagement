using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Products.Query.GetPublishedProducts
{
    public class GetPublishProductsProfile : Profile
    {
        public GetPublishProductsProfile()
        {
            CreateMap<Product, GetPublishedProductsResponse>();
        }
    }
}