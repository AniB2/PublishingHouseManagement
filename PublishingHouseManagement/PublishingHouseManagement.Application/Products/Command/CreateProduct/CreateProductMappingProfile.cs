using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Products.Command.CreateProduct
{
    public class CreateProductMappingProfile : Profile
    {
        public CreateProductMappingProfile()
        {
            CreateMap<CreateProductCommand, Product>();
        }
    }
}