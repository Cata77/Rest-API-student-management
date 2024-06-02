namespace UniversityManagerAPI.Data.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFacultyRepository Faculties { get; }
        IStudentRepository Students { get; }
        IUserRepository Users { get; }
        int SaveChanges();
    }
}
