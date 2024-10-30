using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Services;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Compra
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductosWebAPI.Controllers
{
    
    public class CompraController : Controller
    {
        private readonly CompraService _compraService;

        public CompraController(CompraService compraService)
        {
            _compraService = compraService;
        }

        public async Task<ActionResult> Index()
        {
            var compra = await _compraService.GetComprasAsync();
            return View(compra);
        }

        public async Task<ActionResult> Details(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            return View(compra);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Compra compra)
        {
            await _compraService.DeleteCompra(id);
            return View(compra);
        }



        public async Task<ActionResult> Create()
        {
            var proveedores = await _compraService.GetProveedoresAsync();

            // Verificar si proveedores está nulo o vacío
            if (proveedores == null || !proveedores.Any())
            {
                ModelState.AddModelError("", "No se encontraron proveedores.");
                return View(new Compra());
            }

            // Crear el SelectList usando la propiedad correcta
            ViewBag.Proveedores = new SelectList(proveedores, "Id", "nombre"); // Cambia "Nombre" a "nombre"

            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id, Compra compra)
        {

            await _compraService.DeleteCompra(id);
            return RedirectToAction(nameof(Index));



        }
        public async Task<ActionResult> Edit(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Compra compra)
        {

            await _compraService.UpdateCompra(compra);
            return RedirectToAction(nameof(Index));

        }
    }
}