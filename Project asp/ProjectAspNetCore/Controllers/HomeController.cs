namespace ProjectAspNetCore.Controllers;

public class HomeController : Controller
{
    private readonly AnimalLogic _animalLogic;
    public IHubContext<MainHub> _hubContext;

    public HomeController(AnimalLogic animalLogic, IHubContext<MainHub> hubContext)
    {
        _animalLogic = animalLogic;
        _hubContext = hubContext;
    }

    public async Task<IActionResult> MostCommentedAnimals()
    {
        return View(await _animalLogic.GetAnimalsWithMostComments());
    }

}
