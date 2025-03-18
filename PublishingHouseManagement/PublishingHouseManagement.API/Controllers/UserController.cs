using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PublishingHouseManagement.API.Infrastrcture.AuthHandlers.JWT;
using PublishingHouseManagement.Application.Users.Command.LogIn;
using PublishingHouseManagement.Application.Users.Command.UserRegistration;

namespace PublishingHouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOptions<JWTConfiguration> _options;

        public UserController(IMediator mediator, IOptions<JWTConfiguration> options)
        {
            _mediator = mediator;
            _options = options;
        }

        [HttpPost("Register")]
        [Authorize(Roles = "manager")]
        public async Task<UserRegistrationResponse> RegisterAsync(UserRegistrationCommand command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpPost("LogIn")]
        public async Task<string> LogIn(LogInCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(command, cancellationToken);
                return JWTHelper.GenerateJWTToken(user.UserName, user.Role, _options);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}