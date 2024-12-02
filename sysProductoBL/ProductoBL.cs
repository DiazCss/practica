using sysProductosDAL;
using sysProductoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sysProductosBL
{
    public class ProductoBL
    {
        private readonly ProductosDAL _productosDAL;

        public ProductoBL(ProductosDAL productosDAL)
        {
            _productosDAL = productosDAL;
        }

        public async Task<int> CreateProductoAsync(Productos pProducto)
        {
            //if (pProducto == null)
            //{
            //    throw new ArgumentNullException(nameof(pProducto), "El producto no puede ser nulo.");
            //}

            return await _productosDAL.CreateProductoAsync(pProducto);
        }

        public async Task<int> EditProductoAsync(Productos pProducto)
        {
            //if (pProducto == null)
            //{
            //    throw new ArgumentNullException(nameof(pProducto), "El producto no puede ser nulo.");
            //}

            return await _productosDAL.EditProductoAsync(pProducto);
        }

        public async Task<Productos> GetByIdAsync(int id)
        {
            //if (id <= 0)
            //{
            //    throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            //}

            var producto = await _productosDAL.GetByIdAsync(new Productos { id = id });

            //if (producto == null)
            //{
            //    throw new KeyNotFoundException($"No se encontró el producto con ID {id}.");
            //}

            return producto;
        }

        public async Task<List<Productos>> GetAllAsync()
        {
            return await _productosDAL.GetAllAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            //if (id <= 0)
            //{
            //    throw new ArgumentException("El ID debe ser mayor que cero.", nameof(id));
            //}

            
            var producto = new Productos { id = id };

            return await _productosDAL.DeleteAsync(producto);
        }
    }
}
