using MediatR;

namespace PublishingHouseManagement.Application.Authors.Query.GetAuthorInformationById
{
    public class GetAuthorByIdCommand : IRequest<GetAuthorByIdResponse>
    {
        public int Id { get; set; }
    }
}