using MediatR;

namespace PublishingHouseManagement.Application.Authors.Command.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<DeleteAuthorResponse>
    {
        public int Id { get; set; }
    }
}