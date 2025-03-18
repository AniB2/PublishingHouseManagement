using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Authors.Query.GetFilteredAuthors
{
    public class GetFilteredMappingProfile : Profile
    {
        public GetFilteredMappingProfile()
        {
            CreateMap<Author, GetFilteredAuthorsResponse>();
        }
    }
}