using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PublishingHouseManagement.API.Infrastrcture.AuthHandlers.JWT;
using PublishingHouseManagement.Application.Authors.Command.AddAuthor;
using PublishingHouseManagement.Application.Authors.Command.AddProductToAuthor;
using PublishingHouseManagement.Application.Authors.Command.DeleteAuthor;
using PublishingHouseManagement.Application.Authors.Command.UpdateAuthor;
using PublishingHouseManagement.Application.Authors.Query.GetAuthorInformationById;
using PublishingHouseManagement.Application.Authors.Query.GetFilteredAuthors;

namespace PublishingHouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IOptions<JWTConfiguration> _options;

        public AuthorController(IMediator mediator, IOptions<JWTConfiguration> options)
        {
            _mediator = mediator;
            _options = options;
        }

        [HttpPost("CreateAuthor")]
        public async Task<int> CreateAuthorAsync(AddAuthorCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return response.Id;
        }

        [HttpDelete("DeleteAuthor")]
        public async Task DeleteAuthorAsync(DeleteAuthorCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
        }

        [HttpPut("UpdateAuthor")]
        public async Task UpdateAuthorAsync(UpdateAuthorCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
        }

        [HttpGet("GetAuthorFullInfo")]
        public async Task<GetAuthorByIdResponse> GetAuthorFullInfoAsync(int id, CancellationToken cancellationToken = default)
        {
           return await _mediator.Send(new GetAuthorByIdCommand { Id = id }, cancellationToken);
        }

        [HttpPost("GetFilteredAuthors")]
        public async Task<List<GetFilteredAuthorsResponse>> GetFilteredAuthorsAsync(GetFilteredAuthorsCommand command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpPost("AddProductToAuthorAuthors")]
        public async Task<AddProductToAuthorResponse> AddProductToAuthorAsync(AddProductToAuthorCommand command, CancellationToken cancellationToken = default)
        {
             return await _mediator.Send(command, cancellationToken);
        }
    }
}