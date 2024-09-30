using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Articulo
using ProductosWEB.Services; // Asegúrate de incluir el espacio de nombres correcto para ArticuloService
using proyectoWebAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyectoWebAPI.Controllers
{
    
    public class ArticuloController : Controller
    {
        private readonly ArticuloService _articuloService;

        public ArticuloController(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }
        public async Task<ActionResult> Index()
        {
            var articulos = await _articuloService.GetArticulosAsync();
            return View(articulos);
        }

        public async Task<ActionResult> Details(int id)
        {
            var articulo = await _articuloService.GetArticuloById(id);
            return View(articulo);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var articulo = await _articuloService.GetArticuloById(id);
            return View(articulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Articulo articulo)
        {
            await _articuloService.DeleteArticulo(id);
            return View(articulo);
        }



        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Articulo articulo)
        {

            await _articuloService.CreateArticulo(articulo);
            return RedirectToAction(nameof(Index));



        }
        public async Task<ActionResult> Edit(int id)
        {
            var articulo = await _articuloService.GetArticuloById(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Articulo articulo)
        {

            await _articuloService.UpdateArticulo(articulo);
            return RedirectToAction(nameof(Index));

        }
    }
}
