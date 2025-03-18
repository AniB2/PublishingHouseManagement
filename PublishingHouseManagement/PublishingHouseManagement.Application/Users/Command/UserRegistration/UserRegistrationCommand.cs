using MediatR;

namespace PublishingHouseManagement.Application.Users.Command.UserRegistration
{
    public class UserRegistrationCommand : IRequest<UserRegistrationResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}