using PublishingHouseManagement.Domain.Abstractions.IRepositories;
using PublishingHouseManagement.Domain.Entities;
using PublishingHouseManagement.Persistence.Context;

namespace PublishingHouseManagement.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(PublishingHouseManagementContext context) : base(context)
        {

        }
    }
}