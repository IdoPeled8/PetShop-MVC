
namespace PetShopLogic
{
    public class UserLogic
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserLogic(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

        public async Task<bool> CheckUserAsync(LoginUserModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, false, false);
            if (result.Succeeded)
            { return true; }
            return false;
        }
        public async Task<bool> MakeNewUserAsync(RegisterUserModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            { return true; }
            return false;
        }

        public async Task CreateDefaultUsersAsync()
        {
            // Define user-role data using a collection or database query
            var userRoleData = new List<(string UserName, string Password, string RoleName)>
    {
        ("ido", "Ido123@", "Admin"),
        ("amir", "Amir123@", "Admin"),
        ("user1", "User1123@", "regularUser"),
        ("user2", "User2123@", "regularUser"),
        ("user3", "User3123@", "regularUser")
    };

            // Create roles
            await CreateRolesAsync();

            // Create and assign users to roles
            foreach (var userData in userRoleData)
            {
                var user = new IdentityUser { UserName = userData.UserName };
                var result = await _userManager.CreateAsync(user, userData.Password);

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(user, userData.RoleName);

                else
                    throw new Exception("sry Somthing went wrong try again please");
            }
        }

        private async Task CreateRolesAsync()
        {
            var roles = new List<string> { "Admin", "regularUser" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }

    }
}
