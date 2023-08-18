
namespace PetShopDAL.Repository
{
    public interface ICategoryRepository:IPetShopRepository<Category>
    {
        Task<Category> GetByNameAsync(string name);
    }
}
