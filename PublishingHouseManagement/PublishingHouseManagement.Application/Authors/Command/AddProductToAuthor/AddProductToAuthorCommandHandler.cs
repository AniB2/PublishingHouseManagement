using MediatR;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Authors.Command.AddProductToAuthor
{
    public class AddProductToAuthorCommandHandler : IRequestHandler<AddProductToAuthorCommand, AddProductToAuthorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductToAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AddProductToAuthorResponse> Handle(AddProductToAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.AuthorRepository.AddProductToAuthorAsync(request.AuthorId, request.ProductId, cancellationToken);

                return new AddProductToAuthorResponse { Success = true, Message = "Author updated successfully." };
            }
            catch (Exception ex)
            {
                return new AddProductToAuthorResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
    }
}