using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Persistence.Context;
using PublishingHouseManagement.Domain.Entities;

namespace PublishingHouseManagement.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PublishingHouseManagementContext context) : base(context)
        {

        }
    }
}