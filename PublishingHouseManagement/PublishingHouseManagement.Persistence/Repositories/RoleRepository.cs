using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Domain.Entities;
using PublishingHouseManagement.Persistence.Context;

namespace PublishingHouseManagement.Persistence.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(PublishingHouseManagementContext context) : base(context)
        {

        }
    }
}