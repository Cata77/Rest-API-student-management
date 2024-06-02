using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(UniversityDbContext universityDbContext) : base(universityDbContext) { }

        public User? GetByUsername(string username) => universityDbContext.Users.Where(u => u.Username == username).FirstOrDefault();
    }
}
