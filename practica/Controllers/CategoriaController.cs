using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sysProductosBL;
using sysProductoEN;

namespace practica.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaBL _categoriaBL;

        public CategoriaController(CategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }

        // GET: Categoria/Index
        public async Task<IActionResult> Index()
        {
            var categoria = await _categoriaBL.GetAllAsync();
            return View(categoria);
        }

        // GET: Categoria/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria pCategoria)
        {
            
                await _categoriaBL.CreateCategoriaAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Categoria/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categoria pCategoria)
        {
            await _categoriaBL.UpdateCategoriaAsync(pCategoria);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaBL.GetByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaBL.DeleteCategoriaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
