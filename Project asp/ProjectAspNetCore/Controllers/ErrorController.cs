namespace ProjectAspNetCore.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult UnexpectedError()
        {
            TempData["UnexpectedError"] = "UnexpectedError occurred";
            return View("NotAuthorize"); 
        }

        public IActionResult NotAuthorize()
        {
            TempData["UnexpectedError"] = "sry you are not authorize to join this page";
            return View();
        }
    }
}
