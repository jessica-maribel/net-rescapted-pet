using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FederacionController(IFederacionService _federacionService): ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<Federacione>> CreateAsync(Federacione federacione)
        {
            var created = await _federacionService.AddAsync(federacione);
            return Ok(created);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Federacione>> UpdateAsync(Federacione federacione, int id)
        {
            if (id != federacione.IdFederacion)
                return BadRequest("Id no existe");
            var updated = await _federacionService.UpdateAsync(federacione);
            if (updated == null)
                return NotFound();
            return NoContent();
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<Federacione>> GetById(int id)
        {
            var federacion = await _federacionService.GetByIdAsync(id);
            if (federacion == null)
                return NotFound();
            return Ok(federacion);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Federacione>>> GetAll()
        {
            return Ok(await _federacionService.GetAllAsync());
        }

        [HttpPost("change-stage/{id}")]
        public async Task<IActionResult> ChangeStage([FromBody] Federacione federacione, int id)
        {
            Federacione entity = new()
            {
                Activo = federacione.Activo,
                IdFederacion = federacione.IdFederacion
            };
            return Ok(await _federacionService.ChangeStateAsync(entity));
        }

    }
}
