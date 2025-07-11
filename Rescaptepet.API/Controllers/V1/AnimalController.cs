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
        [HttpPost("create")]
        public async Task<ActionResult<Animale>> CreateAsync(Animale animal)
        {
            var created = await _animalService.AddAsync(animal);
            return Ok(created);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Animale>> UpdateAsync(Animale animal, int id)
        {
            if (id != animal.IdAnimal)
            
                return BadRequest("Id no existe");
            
            var updated = await _animalService.UpdateAsync(animal);
            if (updated == null)
            
                return NotFound();
            
            return NoContent();
        }


        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Animale>> GetById(int id)
        {
            var animal = await _animalService.GetByIdAsync(id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Animale>>> GetAll()
        {
            return Ok(await _animalService.GetAllAsync());
        }
    }
}
