using MediatR;

namespace PublishingHouseManagement.Application.Authors.Query.GetFilteredAuthors
{
    public class GetFilteredAuthorsCommand : IRequest<List<GetFilteredAuthorsResponse>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}