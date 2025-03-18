using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Products.Command.PublishProduct
{
    public class PublishProductCommandHandler : IRequestHandler<PublishProductCommand, PublishProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublishProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PublishProductResponse> Handle(PublishProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == request.Id, cancellationToken)
                                                   ?? throw new NotFoundException("The requested resource was not found.");

                if (product.IsPublished)
                    return new PublishProductResponse { Success = false, Message = "Product is already published." };

                product.IsPublished = true;
                await _unitOfWork.ProductRepository.UpdateAsync(product, cancellationToken);

                return new PublishProductResponse { Success = true, Message = "Product published successfully." };
            }
            catch(Exception ex)
            {
                return new PublishProductResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
    }
}