using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class UserImageRepository : BaseRepository<UserImage>, IUserImageRepository
    {
        public UserImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
