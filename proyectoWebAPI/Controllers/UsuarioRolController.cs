using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;



namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly UsuarioRolService _usuarioRolService;

        public UsuarioRolController(UsuarioRolService usuarioRolService)
        {
            _usuarioRolService = usuarioRolService;
        }

        // GET: api/UsuarioRol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> Index()
        {
            var usuarioRoles = await _usuarioRolService.GetUsuarioRolAsync();
            return Ok(usuarioRoles);
        }

        // GET: api/usuarUsuarioRol
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> Details(int id)
        {
            var usuarioRol = await _usuarioRolService.GetUsuarioRolById(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }
            return Ok(usuarioRol);
        }

        // POST: api/UsuarioRol
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> Create([FromBody] UsuarioRol usuarioRol)
        {
            if (ModelState.IsValid)
            {
                await _usuarioRolService.CreateUsuarioRol(usuarioRol);
                return CreatedAtAction(nameof(Details), new { id = usuarioRol.Id }, usuarioRol);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/UsuarioRol
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioRolService.UpdateUsuarioRol(usuarioRol);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/UsuarioRol
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioRol = await _usuarioRolService.GetUsuarioRolById(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            await _usuarioRolService.DeleteUsuarioRol(id);
            return NoContent();
        }
    }
}


