namespace PetShopDAL.Repository
{
    public interface IAnimalRepository
    {
        Task<ICollection<Animal>> GetAnimalsWithMostComments();
        Task<Animal> GetByIdAsync(int id);
        Task<ICollection<Animal>> GetAllAsync();
        Task<ICollection<Animal>> GetByCategoryAsync(int categoryId);
        Task AddCommentAsync(string commentText, int animalId);

        Task AddAsync(Animal animal);
        Task UpdateAsync(Animal animal);
        Task DeleteAsync(int id);
    }
}
