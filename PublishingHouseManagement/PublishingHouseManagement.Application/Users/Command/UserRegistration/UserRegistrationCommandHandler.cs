using MediatR;
using PublishingHouseManagement.Application.Common.Enums;
using PublishingHouseManagement.Application.Common.Exceptions;
using PublishingHouseManagement.Application.Common.PasswordService;
using PublishingHouseManagement.Domain.Abstractions;

namespace PublishingHouseManagement.Application.Users.Command.UserRegistration
{
    public class UserRegistrationCommandHandler : IRequestHandler<UserRegistrationCommand, UserRegistrationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRegistrationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRegistrationResponse> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _unitOfWork.UserRepository.GetAsync(x => x.UserName == request.UserName, cancellationToken);

                if (existingUser != null)
                    throw new AlreadyExistsException("An item already exists.");

                var role = RemoveSpacesAndToPascalCase(request.Role);

                if (!Enum.IsDefined(typeof(Roles), role))
                {
                    throw new InvalidOperationException($"The role '{role}' is invalid.");
                }

                var user = await _unitOfWork.UserRepository.AddAsync(new Domain.Entities.User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Password = PasswordService.GenerateHash(request.Password),
                    Role = new Domain.Entities.Role
                    {
                        UserRole = role
                    }
                }, cancellationToken);

                return new UserRegistrationResponse { Success = true, Message = "Registration was successfully." };

            }
            catch (Exception ex)
            {
                return new UserRegistrationResponse { Success = false, Message = $"An error occurred: {ex.Message}" };
            }
        }

        private string RemoveSpacesAndToPascalCase(string input)
        {
            string role;

            var noSpaces = input.Replace(" ", string.Empty);
            role = noSpaces.Trim();

            return role.ToLower();
        }
    }
}