
using PetShopModels;

namespace ProjectAspNetCore.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{

    private readonly AnimalLogic _animalLogic;
    private readonly CategoryLogic _categoryLogic;

    public AdminController(AnimalLogic animalLogic, CategoryLogic categoryLogic)
    {
        _animalLogic = animalLogic;
        _categoryLogic = categoryLogic;
    }

    public IActionResult AdminCatalog(int? categoryId)
    {
        ViewBag.user = User.Identity!.Name;
        var pageAndId = new Tuple<string, int?>("admin", categoryId);
        ViewBag.PageAndID = pageAndId;
        return View();
    }

    public async Task<IActionResult> ChangeDataForm(string actionType, int animalId)
    {
        ViewBag.animals = new SelectList(await _animalLogic.GetAllAnimalsAsync(), "AnimalId", "Name");
        ViewBag.Categories = new SelectList(await _categoryLogic.GetAllCategoriesAsync(), "CategoryId", "Name");
        ViewBag.actionType = actionType;
        if (actionType == "addAnimal")
            return View("AddAnimal", new Animal());

        else if (actionType == "editAnimal")
            return View("EditAnimal", await _animalLogic.GetAnimalByIdAsync(animalId));

        else if (actionType == "addCategory")
            return View("AddCategory");

        else if (actionType == "removeCategory")
            return View("RemoveCategory");

        return RedirectToAction("AdminCatalog");
    }
    [HttpPost]
    public async Task<IActionResult> AddCategory(string newCategoryName)
    {
        var res = await _categoryLogic.GetCategoryByNameAsync(newCategoryName);
        if (res == null)
        {
            await _categoryLogic.AddCategoryAsync(newCategoryName);
            TempData["succeededMessages"] = UiMessages.categoryAdded;
        }
        //send msg say this category Name already Exist
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveCategory(int categoryId)
    {
        var animals = await _animalLogic.GetAllAnimalsAsync();
        var res = animals.FirstOrDefault(animal => animal.CategoryId == categoryId);
        if (res == null)
        {
            await _categoryLogic.DeleteCategoryAsync(categoryId);
            TempData["succeededMessages"] = UiMessages.categoryRemoved;
        }
        else
            TempData["categoryHaveAnimalMsg"] = UiMessages.categoryHaveAnimalMsg;

        return RedirectToAction("ChangeDataForm", new { actionType = "removeCategory" });
    }

    [HttpPost]
    public async Task<IActionResult> AddAnimal(Animal animal, IFormFile? imageFile)
    {
        if (imageFile == null)
        {
            TempData["PhotoIsNull"] = UiMessages.PhotoIsNull;
        }
        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                await _animalLogic.AddPhotoToAnimal(imageFile, animal);
            }
            await _animalLogic.AddAnimalAsync(animal);
            TempData["succeededMessages"] = UiMessages.animalAdded;
            //await _hubContext.Clients.All.SendAsync("UpdateAnimal", animal);

        }
        return RedirectToAction("ChangeDataForm", new { actionType = "addAnimal" });
    }

    [HttpPost]
    public async Task<IActionResult> EditAnimal(Animal animal, IFormFile? imageFile)
    {
        if (ModelState.IsValid)
        {
            if (imageFile != null)
            {
                await _animalLogic.AddPhotoToAnimal(imageFile, animal);
            }
            await _animalLogic.UpdateAnimalAsync(animal);
            TempData["succeededMessages"] = UiMessages.animalUpdated;
        }
        return RedirectToAction("ChangeDataForm", new { actionType = "editAnimal", animalId = animal.AnimalId });
    }

    [HttpPost]
    public async Task RemoveAnimal(int animalId)
    {
        await _animalLogic.DeleteAnimalAsync(animalId);
    }

}
