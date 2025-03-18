using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Authors.Command.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeleteAuthorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteAuthorResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var author = await _unitOfWork.AuthorRepository.GetAsync(x => x.Id == request.Id, cancellationToken)
                                                   ?? throw new NotFoundException("The requested resource was not found.");

                author.IsDelete = true;
                await _unitOfWork.AuthorRepository.UpdateAsync(author, cancellationToken);

                return new DeleteAuthorResponse { Success = true, Message = "Author deleted successfully." };
            }
            catch (Exception ex)
            {
                return new DeleteAuthorResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
    }
}