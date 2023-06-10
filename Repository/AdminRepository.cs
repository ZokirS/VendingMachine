using Contracts;
using Entities.Models;

namespace Repository
{
    public class AdminRepository : RepositoryBase<User>, IAdminRepository
    {
        public AdminRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}
    }
}
