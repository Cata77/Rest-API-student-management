using UniversityManagerAPI.Data.Repository.Interfaces;
using UniversityManagerAPI.Helpers;

namespace UniversityManagerAPI.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly UniversityDbContext universityDbContext;
        public IFacultyRepository Faculties { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IUserRepository Users { get; private set; }

        public UnitOfWork(UniversityDbContext universityDbContext)
        {
            this.universityDbContext = universityDbContext;
            Faculties = new FacultyRepository(universityDbContext);
            Students = new StudentRepository(universityDbContext);
            Users = new UserRepository(universityDbContext);
        }

        public void Dispose()
        {
            universityDbContext.Dispose();
        }

        public int SaveChanges()
        {
            try
            {
                return universityDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new AppException(AppExceptions.INVALIDDATA.ToString());
            }
        }
    }
}
