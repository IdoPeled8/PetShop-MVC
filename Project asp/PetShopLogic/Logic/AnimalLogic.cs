
namespace PetShopLogic;

public class AnimalLogic
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalLogic(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    //public async Task<IEnumerable<Comment>> GetAllAnimalCommentsAsync(int id) => await _animalRepository.GetAllComments(id);
    public async Task<ICollection<Animal>> GetAnimalsWithMostComments() => await _animalRepository.GetAnimalsWithMostComments();

    public async Task<Animal> GetAnimalByIdAsync(int id) => await _animalRepository.GetByIdAsync(id);

    public async Task<ICollection<Animal>> GetAllAnimalsAsync() => await _animalRepository.GetAllAsync();

    public async Task<ICollection<Animal>> GetAnimalsByCategoryAsync(int categoryId) => await _animalRepository.GetByCategoryAsync(categoryId);

    public async Task AddCommentToAnimalAsync(string commentText, int animalId) => await _animalRepository.AddCommentAsync(commentText, animalId);

    public async Task AddAnimalAsync(Animal animal) => await _animalRepository.AddAsync(animal);

    public async Task UpdateAnimalAsync(Animal animal) => await _animalRepository.UpdateAsync(animal);

    public async Task DeleteAnimalAsync(int id) => await _animalRepository.DeleteAsync(id);

    public async Task AddPhotoToAnimal(IFormFile newPhoto, Animal animal)
    {
        // Save the uploaded file to wwwRoot
        var fileName = Path.GetFileName(newPhoto.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pics", fileName);

        //checks if this photo already exist in the project
        if (!File.Exists(filePath))
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await newPhoto.CopyToAsync(stream);
            }
        }
        // Update the ImageName property with the saved file name
        animal.ImageName = fileName;
    }
}
