using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sysProductoEN;
using sysProductosBL;
using sysProductosDAL;
namespace practica.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoBL _productoBL;

       public ProductoController(ProductoBL productoBL)
        {
            _productoBL = productoBL;
        }
        public async Task<IActionResult> Index()
        {
            var productos = await _productoBL.GetAllAsync();
            return View(productos);
        }
        public async Task<IActionResult> Create(Productos pProductos)
        {
            if (string.IsNullOrEmpty(pProductos.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(pProductos); 
            }

            int result = await _productoBL.CreateProductoAsync(pProductos);
            return Redirect("/Producto/Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var productos = await _productoBL.GetByIdAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Productos pProductos)
        {
            if (string.IsNullOrEmpty(pProductos.Nombre))
            {
                ModelState.AddModelError("Nombre", "El nombre del producto es obligatorio.");
                return View(pProductos); // Vuelve a la vista con el error.
            }

            int result = await _productoBL.EditProductoAsync(pProductos);
            return Redirect("/Producto/Index");
        }


        // GET: Categoria/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var productos = await _productoBL.GetByIdAsync(id);
            if (productos == null)
            {
                return NotFound();
            }
            return View(productos);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoBL.DeleteAsync(id);
            return Redirect("/Producto/Index");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await _productoBL.GetByIdAsync(id);
            return View(categoria);
        }
    }
}
