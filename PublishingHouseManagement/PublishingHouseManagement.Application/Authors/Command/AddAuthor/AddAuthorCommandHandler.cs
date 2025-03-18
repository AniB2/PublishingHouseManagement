using AutoMapper;
using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Application.Authors.Command.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AddAuthorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddAuthorResponse> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var existingAuthor = await _unitOfWork.AuthorRepository.GetAsync(x => x.PrivateNumber == request.PrivateNumber, cancellationToken);

            if (existingAuthor != null)
                throw new AlreadyExistsException("The item already exists in the system.");

            var author = await _unitOfWork.AuthorRepository.AddAsync(_mapper.Map<Author>(request), cancellationToken);

            return new AddAuthorResponse { Id = author.Id };
        }
    }
}