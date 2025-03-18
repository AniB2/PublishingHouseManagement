using MediatR;

namespace PublishingHouseManagement.Application.Users.Command.LogIn
{
    public class LogInCommand : IRequest<LogInResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}