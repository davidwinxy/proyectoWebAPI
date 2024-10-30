using Microsoft.AspNetCore.Mvc;
using proyectoWebAPI.Models;
using proyectoWebAPI.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace proyectoWebAPI.Controllers
{
    public class ImagenArticuloController : Controller
    {
        private readonly ImagenArticuloService _imagenArticuloService;

        public ImagenArticuloController(ImagenArticuloService imagenArticuloService)
        {
            _imagenArticuloService = imagenArticuloService;
        }

        [HttpGet] // GET para obtener todas las imágenes
        public async Task<ActionResult> Index()
        {
            var imagenes = await _imagenArticuloService.GetArticulosAsync();
            return View(imagenes);
        }

        [HttpGet] // GET para obtener detalles de una imagen específica
        public async Task<ActionResult> Details(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen);
        }

        [HttpGet] // GET para mostrar el formulario de eliminación
        public async Task<ActionResult> Delete(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen);
        }

        [HttpGet] // GET para mostrar el formulario de creación
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost] // POST para manejar la creación de una nueva imagen
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int articuloId, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var result = await _imagenArticuloService.UploadImagenAsync(articuloId, file);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            ModelState.AddModelError("", "Error al subir la imagen.");
            return View();
        }

        [HttpGet] // GET para mostrar el formulario de edición
        public async Task<ActionResult> Edit(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen);
        }

        [HttpPost] // POST para manejar la edición de una imagen existente
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ImagenArticulo imagen)
        {
            // Aquí va la lógica de actualización de la imagen
            return RedirectToAction(nameof(Index));
        }
    }
}
