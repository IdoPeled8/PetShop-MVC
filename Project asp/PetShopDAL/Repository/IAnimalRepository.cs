namespace PetShopDAL.Repository
{
    public interface IAnimalRepository : IPetShopRepository<Animal>
    {
        Task<ICollection<Animal>> GetAnimalsWithMostComments();
        Task<ICollection<Animal>> GetByCategoryAsync(int categoryId);
        Task AddCommentAsync(string commentText, int animalId);

    }
}
