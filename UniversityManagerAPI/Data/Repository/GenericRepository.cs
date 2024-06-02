using UniversityManagerAPI.Data.Repository.Interfaces;

namespace UniversityManagerAPI.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly UniversityDbContext universityDbContext;

        public GenericRepository(UniversityDbContext universityDbContext) 
        {
            this.universityDbContext = universityDbContext;
        }

        public IEnumerable<T> GetAll() => universityDbContext.Set<T>().ToList();

        public T? GetById(int id) => universityDbContext.Set<T>().Find(id);

        public void Add(T entity) => universityDbContext.Set<T>().Add(entity);

        public void Update(T entity) => universityDbContext.Set<T>().Update(entity);
        
        public void Delete(T entity) => universityDbContext.Set<T>().Remove(entity);

        public void Save() => universityDbContext.SaveChanges();
    }
}
