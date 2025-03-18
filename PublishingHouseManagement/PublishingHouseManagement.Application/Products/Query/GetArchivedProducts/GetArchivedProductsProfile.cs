using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Products.Query.GetArchivedProducts
{
    public class GetArchivedProductsProfile : Profile
    {
        public GetArchivedProductsProfile()
        {
            CreateMap<Product, GetArchivedProductsResponse>();
        }
    }
}