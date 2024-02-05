using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email,cancellationToken);
        }
    }
}
