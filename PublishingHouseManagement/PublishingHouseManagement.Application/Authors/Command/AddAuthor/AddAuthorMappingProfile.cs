using AutoMapper;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Authors.Command.AddAuthor
{
    public class AddAuthorMappingProfile : Profile
    {
        public AddAuthorMappingProfile()
        {
            CreateMap<AddAuthorCommand, Author>();
        }
    }
}