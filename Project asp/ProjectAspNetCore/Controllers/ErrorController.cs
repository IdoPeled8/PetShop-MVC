namespace ProjectAspNetCore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult UnexpectedError()
        {
            return Content("Unexpected Error"); //make view
        }

        public IActionResult NotAuthorize()
        {
            return View();
        }
    }
}
