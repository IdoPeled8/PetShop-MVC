


namespace ProjectAspNetCore.Controllers
{
    public class AccountController : Controller
    {
        private UserLogic _userLogic;
        public AccountController(UserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userLogic.CheckUserAsync(model))
                    return RedirectToAction("MostCommentedAnimals", "Home");

                TempData["UserNamePasswordWrong"] = UiMessages.UserNamePasswordWrong;
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _userLogic.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userLogic.MakeNewUserAsync(model);

                if (user)
                {
                    TempData["RegisterSucceeded"] = UiMessages.RegisterSucceeded;
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> CreateRoleAndUsers()
        {
            try
            {
                await _userLogic.CreateDefaultUsersAsync();
            }
            catch (Exception e)
            {
                TempData["errorUser"] = e.Message;
            }
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => RedirectToAction("MostCommentedAnimals", "Home");
    }
}
