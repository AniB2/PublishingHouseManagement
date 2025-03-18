using AutoMapper;
using MediatR;
using PublishingHouseManagement.Application.Common.Enums;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Products.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.IsDefined(typeof(ProductType), request.ProductType))
                throw new InvalidInputException("The input provided is invalid.");

            var response = await _unitOfWork.ProductRepository.AddAsync(_mapper.Map<Product>(request), cancellationToken);

            return new CreateProductResponse { Id = response.Id };
        }
    }
}