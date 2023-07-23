

namespace PetShopDAL.Repository;

public class AnimalRepository : IAnimalRepository/* , IMainRepository<Animals>*/
{
    PetShopContext _petShopContext;

    public AnimalRepository(PetShopContext petShopContext)
    {
        _petShopContext = petShopContext;
    }
    public async Task<ICollection<Animal>> GetAnimalsWithMostComments()
    {
        var animalsWithMostComments = await _petShopContext.Animals!
           .Include(a => a.Category)
           .Include(a => a.Comments)
           .OrderByDescending(a => a.Comments!.Count)
           .Take(2)
           .ToListAsync();

        return animalsWithMostComments;

    }

    public async Task<Animal> GetByIdAsync(int id)
    {
        return await _petShopContext.Animals!
            .Include(a => a.Category)
            .Include(a => a.Comments)
            .FirstAsync(a => a.AnimalId == id)!;
    }

    public async Task<ICollection<Animal>> GetAllAsync()
    {
        return await _petShopContext.Animals!
            .Include(a => a.Category)
            .ToListAsync();
    }

    public async Task<ICollection<Animal>> GetByCategoryAsync(int categoryId)
    {
        if (categoryId == 0)
        {
            return await GetAllAsync();
        }
        return await _petShopContext.Animals!
            .Include(a => a.Category)
            .Where(a => a.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task AddCommentAsync(string commentText, int animalId)
    {
        Animal animal = await GetByIdAsync(animalId);
        var newComment = new Comment { CommentText = commentText };
        animal.Comments!.Add(newComment);

        await _petShopContext.SaveChangesAsync();
    }


    public async Task AddAsync(Animal animal)
    {
        await _petShopContext.Animals!.AddAsync(animal);
        await _petShopContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Animal animal)
    {
        _petShopContext.Animals!.Update(animal);
        await _petShopContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var animal = GetByIdAsync(id);
        if (animal != null)
        {
            _petShopContext.Animals!.Remove(await animal);
            _petShopContext.SaveChanges();
        }
    }
}
