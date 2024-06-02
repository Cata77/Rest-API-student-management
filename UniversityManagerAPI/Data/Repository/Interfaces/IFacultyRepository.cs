using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Data.Repository.Interfaces
{
    public interface IFacultyRepository : IGenericRepository<Faculty>
    {
        Faculty? GetByIdWithStudents(int id);
    }
}
