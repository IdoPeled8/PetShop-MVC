
namespace ProjectAspNetCore.Controllers;


public class HomeController : Controller
{
    private readonly AnimalLogic _animalLogic;
    public IHubContext<ChatHub> _hubContext;

    public HomeController(AnimalLogic animalLogic, IHubContext<ChatHub> hubContext)
    {
        _animalLogic = animalLogic;
        _hubContext = hubContext;
    }

    public async Task<IActionResult> MostCommentedAnimals()
    {
        return View(await _animalLogic.GetAnimalsWithMostComments());
    }

}
