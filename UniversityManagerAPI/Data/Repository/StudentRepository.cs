using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Data.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(UniversityDbContext universityDbContext) : base(universityDbContext) { }
    }
}
