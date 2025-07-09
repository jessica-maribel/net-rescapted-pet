using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Application.Services.Public;
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AnimalController(IAnimalService _animalService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Animale>> GetById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }
    }
}
