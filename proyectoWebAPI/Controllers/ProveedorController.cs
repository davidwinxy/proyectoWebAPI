using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;

namespace proyectoWebAPI.Controllers
{
    public class ProveedorController : Controller
    {
       private readonly ProveedorService _service;
        public ProveedorController(ProveedorService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var proveedor = await _service.GetProveedoresAsync();
            return View(proveedor);
        }

        public async Task<ActionResult> Details (int id)
        {
            var proveedor = await _service.GetProveedorById(id);
            return View(proveedor);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await _service.GetProveedorById(id);
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Proveedor proveedor)
        {
            await _service.DeleteProveedor(id);
            return View(proveedor);
        }



        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proveedor proveedor)
        {
            
                await _service.CreateProveedor(proveedor); 
                return RedirectToAction(nameof(Index)); 
            

             
        }
        public async Task<ActionResult> Edit(int id)
        {
            var proveedor = await _service.GetProveedorById(id); 
            if (proveedor == null)
            {
                return NotFound(); 
            }

            return View(proveedor); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Proveedor proveedor)
        {
          
                await _service.UpdateProveedor(proveedor); 
                return RedirectToAction(nameof(Index));  

        }

    }
}
