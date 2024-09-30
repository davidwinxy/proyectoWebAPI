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

        // Acción para mostrar todas las imágenes de los artículos
        public async Task<ActionResult> Index()
        {
            var imagenes = await _imagenArticuloService.GetArticulosAsync();
            return View(imagenes); // Asegúrate de tener una vista correspondiente
        }

        // Acción para ver detalles de una imagen específica
        public async Task<ActionResult> Details(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen); // Asegúrate de tener una vista correspondiente para los detalles
        }

        // Acción para mostrar el formulario de eliminación
        public async Task<ActionResult> Delete(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen); // Asegúrate de tener una vista de confirmación de eliminación
        }

        // Acción para mostrar el formulario de creación
        public async Task<ActionResult> Create()
        {
            return View(); // Asegúrate de tener una vista para crear imágenes
        }

        // Acción para manejar la creación de una nueva imagen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int articuloId, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var result = await _imagenArticuloService.UploadImagenAsync(articuloId, file);
                if (result)
                {
                    return RedirectToAction(nameof(Index)); // Redirige a la lista de imágenes
                }
            }

            ModelState.AddModelError("", "Error al subir la imagen."); // Agregar un error al modelo si la carga falla
            return View(); // Volver a mostrar el formulario de carga
        }

        // Acción para mostrar el formulario de edición
        public async Task<ActionResult> Edit(int id)
        {
            var imagen = await _imagenArticuloService.GetArticuloById(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen); // Asegúrate de tener una vista para editar imágenes
        }

        // Acción para manejar la edición de una imagen existente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ImagenArticulo imagen)
        {
            // Aquí iría la lógica para actualizar la imagen en el servidor (si es necesario)
            // Esta parte puede requerir un método adicional en el servicio si planeas actualizar metadatos de la imagen

            return RedirectToAction(nameof(Index)); // Redirige a la lista de imágenes
        }
    }
}
