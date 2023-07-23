
namespace PetShopDAL.Repository
{
    public interface ICategoryRepository
    {
        Task<Category> GetByIdAsync(int id);
        Task<Category?> GetByNameAsync(string name);
        Task<ICollection<Category>> GetAllAsync();

        Task AddAsync(string category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int categoryId);
    }
}
