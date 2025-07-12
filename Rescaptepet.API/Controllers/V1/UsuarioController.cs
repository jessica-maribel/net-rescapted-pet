using Microsoft.AspNetCore.Mvc;
using Rescaptepet.Application.Interfaces.Public;
using Rescaptepet.Application.Services.Public;
using Rescaptepet.Domain.Entities.Public;

namespace Rescaptepet.API.Controllers.V1
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController(IUsuarioService _usuarioService) : ControllerBase
    {

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Usuario>> UpdateAsync(Usuario usuario, int id)
        {
            if (id != usuario.IdUsuario)
                return BadRequest("Id no existe");
            var updated = await _usuarioService.UpdateAsync(usuario);
            if (updated == null)
                return NotFound();
            return NoContent();
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            return Ok(await _usuarioService.GetAllAsync());
        }

    }
}
