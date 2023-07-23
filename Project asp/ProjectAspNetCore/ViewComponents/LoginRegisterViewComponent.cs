namespace ProjectAspNetCore.ViewComponents
{
    public class LoginRegisterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View("PasswordEye"));
        }
    }
}
