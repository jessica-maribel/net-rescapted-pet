using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/adopcion")]
    public class AdopcionController(IAdopcionService _adopcionService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<Adopcione>> CreateAsync(Adopcione adopcione)
        {
            return await _adopcionService.AddAsync(adopcione);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Adopcione>> UpdateAsync(Adopcione adopcione, int id)
        {
            if (id != adopcione.IdAdopcion)
                return BadRequest("Id no existe");
            var updated = await _adopcionService.UpdateAsync(adopcione);

            if (updated == null)
                return NotFound();
            return NoContent();
        }

        [HttpGet("get_all")]
        public async Task<ActionResult<IEnumerable<Adopcione>>> GetAll()
        {
            return Ok(await _adopcionService.GetAllAsync());
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Adopcione>> GetById(int id)
        {
            var adopcione = await _adopcionService.GetByIdAsync(id);
            if (adopcione == null)
                return NotFound();
            return Ok(adopcione);
        }
    }
}
