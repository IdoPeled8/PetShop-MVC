

namespace PetShopDAL.Repository
{
    public class CategoryRepository : ICategoryRepository

    {
        PetShopContext _petShopContext;

        public CategoryRepository(PetShopContext petShopContext)
        {
            _petShopContext = petShopContext;
        }



        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _petShopContext.Categories!.ToListAsync();
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _petShopContext.Categories!.FirstOrDefaultAsync(C => C.Name == name);
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _petShopContext.Categories!.FirstAsync(C => C.CategoryId == id);
        }
        public async Task AddAsync(Category newCategory)
        {
            await _petShopContext.Categories!.AddAsync(newCategory);
            await _petShopContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Category category)
        {
            _petShopContext.Categories!.Update(category);
            await _petShopContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await _petShopContext.Categories!.FirstAsync(c => c.CategoryId == categoryId);
            _petShopContext.Categories!.Remove(category!);
            await _petShopContext.SaveChangesAsync();
        }

    }
}
