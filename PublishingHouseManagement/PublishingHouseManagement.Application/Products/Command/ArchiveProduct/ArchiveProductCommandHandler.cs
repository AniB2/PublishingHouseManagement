using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Products.Command.ArchiveProduct
{
    public class ArchiveProductCommandHandler : IRequestHandler<ArchiveProductCommand, ArchiveProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArchiveProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ArchiveProductResponse> Handle(ArchiveProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(x => x.Id == request.Id, cancellationToken)
                                                   ?? throw new NotFoundException("The requested resource was not found.");

                if (product.IsArchive)
                    return new ArchiveProductResponse { Success = false, Message = "Product is already archived." };

                product.IsArchive = true;
                product.IsPublished = false;
                await _unitOfWork.ProductRepository.UpdateAsync(product, cancellationToken);

                return new ArchiveProductResponse { Success = true, Message = "Product archived successfully." };
            }
            catch (Exception ex)
            {
                return new ArchiveProductResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }
    }
}