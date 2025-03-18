using MediatR;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Application.Common.PasswordService;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Users.Command.LogIn
{
    public partial class LogInCommandHandler : IRequestHandler<LogInCommand, LogInResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogInCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<LogInResponse> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var password = PasswordService.GenerateHash(request.Password);

            var user = await _unitOfWork.UserRepository.GetWithRelatedEntitiesAsync(x => x.UserName == request.UserName && x.Password == password,
                                                                                    includeProperty: a => a.Role,
                                                                                    cancellationToken: cancellationToken) ?? throw new NotFoundException("The requested resource was not found.");
            return new LogInResponse
            {
                UserName = user.UserName,
                Role = user.Role.UserRole
            };
        }
    }
}