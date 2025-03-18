using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Authors.Command.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateAuthorResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAuthor = await _unitOfWork.AuthorRepository.GetAsync(x => x.Id == request.Id, cancellationToken)
                                                    ?? throw new NotFoundException("The requested resource was not found.");

                foreach (var prop in typeof(UpdateAuthorCommand).GetProperties())
                {
                    var existingProp = typeof(Author).GetProperty(prop.Name);

                    if (existingProp != null && existingProp.CanWrite)
                    {
                        var value = prop.GetValue(request);
                        existingProp.SetValue(existingAuthor, value);
                    }
                }

                await _unitOfWork.AuthorRepository.UpdateAsync(existingAuthor, cancellationToken);
                return new UpdateAuthorResponse { Success = true, Message = "Author updated successfully." };
            }
            catch (Exception ex)
            {
                return new UpdateAuthorResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
    }
}