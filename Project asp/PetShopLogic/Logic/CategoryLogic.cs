namespace PetShopLogic
{
    public class CategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync() => await _categoryRepository.GetAllAsync();

        public async Task<Category> GetCategoryByIdAsync(int id) => await _categoryRepository.GetByIdAsync(id);

        public async Task<Category?> GetCategoryByNameAsync(string name) => await _categoryRepository.GetByNameAsync(name);

        public async Task AddCategoryAsync(string categoryName) => await _categoryRepository.AddAsync(categoryName);

        public async Task UpdateCategoryAsync(Category category) => await _categoryRepository.UpdateAsync(category);

        public async Task DeleteCategoryAsync(int categoryId) => await _categoryRepository.DeleteAsync(categoryId);
    }
}