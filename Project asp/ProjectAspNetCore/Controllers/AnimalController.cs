
namespace ProjectAspNetCore.Controllers;

public class AnimalController : Controller
{
    private readonly AnimalLogic _animalLogic;
    private readonly CommentLogic _commentLogic;

    public AnimalController(AnimalLogic animalLogic, CommentLogic commentLogic)
    {
        _animalLogic = animalLogic;
        _commentLogic = commentLogic;
    }

    public async Task<IActionResult> AnimalInformation(int id)
    {
        var animal = await _animalLogic.GetAnimalByIdAsync(id);
        if (animal == null)
        {
            return NotFound();
        }
        return View(animal);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddComment(int animalId, string commentText)
    {
        if (ModelState.IsValid)
        {
            var animal = await _animalLogic.GetAnimalByIdAsync(animalId);
            if (animal == null)
            {
                return NotFound();
            }
            await _animalLogic.AddCommentToAnimalAsync(commentText, animalId);

            return PartialView("_CommentsPartial", animal);
        }
        return BadRequest();
    }

    public async Task<IActionResult> RemoveComment(int animaLId, int commentId)
    {
        if (ModelState.IsValid)
        {
            await _commentLogic.DeleteCommentAsync(commentId);
        }
        return RedirectToAction("AnimalInformation", new { id = animaLId });
    }
}
