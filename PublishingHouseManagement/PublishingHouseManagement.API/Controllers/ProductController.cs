using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PublishingHouseManagement.Application.Products.Command.ArchiveProduct;
using PublishingHouseManagement.Application.Products.Command.CreateProduct;
using PublishingHouseManagement.Application.Products.Command.PublishProduct;
using PublishingHouseManagement.Application.Products.Query.GetArchivedProducts;
using PublishingHouseManagement.Application.Products.Query.GetPublishedProducts;

namespace PublishingHouseManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [HttpPost("CreateProduct")]
        [Authorize(Roles = "manager")]
        public async Task<int> CreateProductAsync(CreateProductCommand command, CancellationToken cancellationToken = default)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return response.Id;
        }

        [HttpPost("PublishProduct")]
        [Authorize]
        public async Task<PublishProductResponse> PublishProductAsync(PublishProductCommand command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpPost("ArchiveProduct")]
        [Authorize]
        public async Task<ArchiveProductResponse> ArchiveProductAsync(ArchiveProductCommand command, CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(command, cancellationToken);
        }

        [HttpGet("GetPublishedProducts")]
        [Authorize]
        public async Task<List<GetPublishedProductsResponse>> GetPublishProductsAsync(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetPublishedProductsCommand(), cancellationToken);
        }

        [HttpGet("GetArchivedProducts")]
        [Authorize]
        public async Task<List<GetArchivedProductsResponse>> GetArchivedProductsAsync(CancellationToken cancellationToken = default)
        {
            return await _mediator.Send(new GetArchivedProductsCommand(), cancellationToken);
        }
    }
}