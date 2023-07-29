using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopLogic;

namespace ProjectAspNetCore.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly AnimalLogic _animalLogic;

        public AdminApiController(AnimalLogic animalLogic)
        {
            _animalLogic = animalLogic;
        }

        [HttpPost("RemoveAnimal/{animalId}")]
        public async Task RemoveAnimal(int animalId)
        {
            await _animalLogic.DeleteAnimalAsync(animalId);
        }
    }
}
