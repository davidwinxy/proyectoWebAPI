using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Services;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Usuario
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosWEB.Controllers
{
    
    public class UsuarioController : Controller
    {
        private readonly UsuarioServices _usuarioService;

        public UsuarioController(UsuarioServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ActionResult> Index()
        {
            var usuario = await _usuarioService.GetUsuariosAsync();
            return View(usuario);
        }

        public async Task<ActionResult> Details(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            return View(usuario);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Usuario usuario)
        {
            await _usuarioService.DeleteUsuario(id);
            return View(usuario);
        }



        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Usuario usuario)
        {

            await _usuarioService.CreateUsuario(usuario);
            return RedirectToAction(nameof(Index));



        }
        public async Task<ActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.Id) // Verifica que el ID coincida
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioService.UpdateUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }

            return View(usuario); // Si el modelo no es válido, vuelve a mostrar el formulario
        }


    }
}