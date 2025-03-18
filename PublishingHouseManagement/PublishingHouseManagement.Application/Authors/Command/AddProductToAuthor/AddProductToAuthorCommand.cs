using MediatR;

namespace PublishingHouseManagement.Application.Authors.Command.AddProductToAuthor
{
    public class AddProductToAuthorCommand : IRequest<AddProductToAuthorResponse>
    {
        public int AuthorId { get; set; }   
        public int ProductId { get; set; }   
    }
}