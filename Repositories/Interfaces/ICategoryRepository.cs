using PhotoGallery.Models;

namespace PhotoGallery.Repositories.Interfaces
{
    public interface ICategoryRepository : ICrudRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(Guid id);
    }
}
