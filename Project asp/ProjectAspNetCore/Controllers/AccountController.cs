


namespace ProjectAspNetCore.Controllers
{
    public class AccountController : Controller
    {
        // change all async methods name to async at the end

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
                //move this to buisness logic
                if (await _userLogic.CheckUserAsync(model))
                {
                    return RedirectToAction("MostCommentedAnimals", "Home");
                }
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
                    // User registration successful, redirect to a success page or login page
                    TempData["RegisterSucceeded"] = UiMessages.RegisterSucceeded;
                    return RedirectToAction("Login");
                }
                else
                {
                    //// User registration failed, add error messages to ModelState
                }
            }
            // If registration fails or ModelState is invalid, return to the registration page with validation errors
            return View(model);
        }

        public IActionResult AccessDenied() => RedirectToAction("MostCommentedAnimals", "Home");


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
    }
}
