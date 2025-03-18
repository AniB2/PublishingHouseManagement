using PublishingHouseManagement.Domain.Abstractions.IRepositories;

namespace PublishingHouseManagement.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}