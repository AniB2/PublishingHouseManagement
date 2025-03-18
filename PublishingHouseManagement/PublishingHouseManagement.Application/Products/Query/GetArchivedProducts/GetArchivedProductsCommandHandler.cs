using AutoMapper;
using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Products.Query.GetArchivedProducts
{
    public class GetArchivedProductsCommandHandler : IRequestHandler<GetArchivedProductsCommand, List<GetArchivedProductsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetArchivedProductsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetArchivedProductsResponse>> Handle(GetArchivedProductsCommand request, CancellationToken cancellationToken)
        {
            var authors = await _unitOfWork.ProductRepository.GetAllAsync(x => x.IsArchive == true, cancellationToken: cancellationToken)
                                                       ?? throw new NotFoundException("The requested resource was not found.");

            return _mapper.Map<List<GetArchivedProductsResponse>>(authors);
        }
    }
}