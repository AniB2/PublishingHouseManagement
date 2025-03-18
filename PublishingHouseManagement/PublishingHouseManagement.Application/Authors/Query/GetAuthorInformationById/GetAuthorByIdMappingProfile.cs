using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Authors.Query.GetAuthorInformationById
{
    public class GetAuthorByIdMappingProfile : Profile
    {
        public GetAuthorByIdMappingProfile()
        {
            CreateMap<Author, GetAuthorByIdResponse>();
            CreateMap<Product, ProductResponse>();
        }
    }
}