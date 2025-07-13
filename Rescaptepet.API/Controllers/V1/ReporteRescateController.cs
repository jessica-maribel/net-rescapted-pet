using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Application.Services.Public;
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReporteRescateController(IReporteRescateService _reporteRescateService) : ControllerBase
    {

        [HttpPost("create")]
        public async Task<ActionResult<ReporteRescate>> CreateAsync([FromForm] ReporteRescate reporteRescate, IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                return BadRequest("Se debe enviar un archivo.");

            var created = await _reporteRescateService.AddAsync(reporteRescate, formFile);
            return Ok(created);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<ReporteRescate>> UpdateAsync(ReporteRescate reporteRescate, int id)
        {
            if (id != reporteRescate.Id)
                return BadRequest("Id no existe");
            var updated = await _reporteRescateService.UpdateAsync(reporteRescate);
            if (updated == null)
                return NotFound();
            return Ok(updated);
        }

        [HttpGet("get-by-id-user/{id}")]
        public async Task<ActionResult<IEnumerable<ReporteRescate>>> GetByIdUserAllAsync(int id)
        {
            return Ok(await _reporteRescateService.GetByIdUserAsync(id));
        }

        [HttpPost("change-stage/{id}")]
        public async Task<IActionResult> ChangeStage([FromBody]ReporteRescate rescate, int id)
        {
            ReporteRescate entity = new()
            {
                Activo = rescate.Activo,
                Id = id
            };
            return Ok(await _reporteRescateService.ChangeStateAsync(entity));
        }
    }
}
