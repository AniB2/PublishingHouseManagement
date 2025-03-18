using AutoMapper;
using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Authors.Query.GetAuthorInformationById
{
    public class GetAuthorByIdCommandHandler : IRequestHandler<GetAuthorByIdCommand, GetAuthorByIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdResponse> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.GetWithRelatedEntitiesAsync(x => x.Id == request.Id, 
                                                                                        includeProperty: a => a.Products, 
                                                                                        cancellationToken: cancellationToken) ?? throw new NotFoundException("The requested resource was not found.");

            return _mapper.Map<GetAuthorByIdResponse>(author);
        }
    }
}