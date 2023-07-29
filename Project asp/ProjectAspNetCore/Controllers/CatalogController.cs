
namespace ProjectAspNetCore.Controllers
{

    public class CatalogController : Controller
    {

        public IActionResult ShowCatagories(int? categoryId)
        {
            var pageAndId = new Tuple<string,int?>("catalog",categoryId);
            ViewBag.PageAndID = pageAndId;
            return View();
        }

    }
}
