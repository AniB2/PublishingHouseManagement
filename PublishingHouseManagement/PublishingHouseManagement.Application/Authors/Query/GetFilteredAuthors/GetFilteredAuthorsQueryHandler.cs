using AutoMapper;
using MediatR;
using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Domain.Entities;
using System.Linq.Expressions;

namespace PublishingHouseManagement.Application.Authors.Query.GetFilteredAuthors
{
    public class GetFilteredAuthorsQueryHandler : IRequestHandler<GetFilteredAuthorsCommand, List<GetFilteredAuthorsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFilteredAuthorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetFilteredAuthorsResponse>> Handle(GetFilteredAuthorsCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Author, bool>> filter = a => (string.IsNullOrEmpty(request.FirstName) || a.FirstName.Contains(request.FirstName)) &&
                                                         (string.IsNullOrEmpty(request.LastName) || a.LastName.Contains(request.LastName));

            var result = await _unitOfWork.AuthorRepository.GetPagedResultAsync(filter, pageNumber: request.PageNumber, pageSize: request.PageSize);

            return _mapper.Map<List<GetFilteredAuthorsResponse>>(result);
        }
    }
}