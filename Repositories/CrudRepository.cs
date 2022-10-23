using Microsoft.EntityFrameworkCore;
using PhotoGallery.Data;
using PhotoGallery.Repositories.Interfaces;

namespace PhotoGallery.Repositories
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public CrudRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();

        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            Save();

        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
