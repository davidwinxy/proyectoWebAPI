using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;

namespace ProductosWebAPI.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        public async Task<ActionResult> Index()
        {
            var prestamos = await _prestamoService.GetAllPrestamosAsync();
            return View(prestamos);
        }

        public async Task<ActionResult> Details(int id)
        {
            var prestamos = await _prestamoService.GetPrestamoByIdAsync(id);
            return View(prestamos);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var prestamos = await _prestamoService.GetPrestamoByIdAsync(id);
            return View(prestamos);
        }




        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Prestamo prestamos)
        {

            await _prestamoService.CreatePrestamoAsync(prestamos);
            return RedirectToAction(nameof(Index));



        }
        public async Task<ActionResult> Edit(int id)
        {
            var prestamos = await _prestamoService.GetPrestamoByIdAsync(id);
            if (prestamos == null)
            {
                return NotFound();
            }

            return View(prestamos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Prestamo prestamos)
        {

            await _prestamoService.UpdatePrestamoAsync(prestamos);
            return RedirectToAction(nameof(Index));

        }
    }
}
