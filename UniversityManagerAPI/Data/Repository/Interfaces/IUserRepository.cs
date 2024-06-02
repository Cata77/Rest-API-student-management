using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Data.Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User? GetByUsername(string username);
    }
}
