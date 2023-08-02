namespace ProjectAspNetCore.ViewComponents
{
    public class CatalogAdminViewComponent : ViewComponent
    {
        private readonly CategoryLogic _categoryLogic;
        private readonly AnimalLogic _animalLogic;

        public CatalogAdminViewComponent(CategoryLogic categoryLogic, AnimalLogic animalLogic)
        {
            _categoryLogic = categoryLogic;
            _animalLogic = animalLogic;
        }

        public async Task<IViewComponentResult> InvokeAsync(Tuple<string, int?> store)
        {
            ViewBag.Categories = new SelectList(await _categoryLogic.GetAllCategoriesAsync(), "CategoryId", "Name");

            var animals = store.Item2.HasValue
                ? _animalLogic.GetAnimalsByCategoryAsync(store.Item2.Value)
                : _animalLogic.GetAllAnimalsAsync();
            ViewBag.PageType = store.Item1;
            return await Task.FromResult<IViewComponentResult>(View("CatalogPage", await animals));
        }
    }
}