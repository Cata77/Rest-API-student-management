using Microsoft.EntityFrameworkCore;
using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Data.Repository
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(UniversityDbContext universityDbContext) : base(universityDbContext) { }

        public Faculty? GetByIdWithStudents(int id)
        {
            return universityDbContext.Faculties.Include(f => f.Students).FirstOrDefault(f => f.Id == id);
        }
    }
}
