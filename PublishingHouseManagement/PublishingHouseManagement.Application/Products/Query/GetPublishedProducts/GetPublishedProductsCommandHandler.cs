using AutoMapper;
using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Products.Query.GetPublishedProducts
{
    public class GetPublishedProductsCommandHandler : IRequestHandler<GetPublishedProductsCommand, List<GetPublishedProductsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPublishedProductsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetPublishedProductsResponse>> Handle(GetPublishedProductsCommand request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.ProductRepository.GetAllAsync(x => x.IsPublished == true, cancellationToken: cancellationToken)
                                                        ?? throw new NotFoundException("The requested resource was not found.");

            return _mapper.Map<List<GetPublishedProductsResponse>>(authors);
        }
    }
}