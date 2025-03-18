using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Domain.Abstractions.IRepositories
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task AddProductToAuthorAsync(int authorId, int productId, CancellationToken cancellationToken = default);
    }
}