using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Persistence.Context;
using PublishingHouseManagement.Persistence.Repositories;

namespace PublishingHouseManagement.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PublishingHouseManagementContext _context;
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IAuthorRepository _authorRepository;
        private IProductRepository _productRepository;

        public UnitOfWork(PublishingHouseManagementContext context) => _context = context;

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository(_context);
        public IAuthorRepository AuthorRepository => _authorRepository ??= new AuthorRepository(_context);
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);
    }
}