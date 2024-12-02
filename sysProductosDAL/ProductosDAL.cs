using Microsoft.EntityFrameworkCore;
using sysProductoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysProductosDAL
{
    public class ProductosDAL
    {
        private readonly sysDbContext _sysDbContext;
        public ProductosDAL(sysDbContext sysDbContext)
        {
            _sysDbContext = sysDbContext;
        }

        public async Task<int> CreateProductoAsync (Productos pProductos)
        {
            var producto = new Productos
            {
                Nombre = pProductos.Nombre,
                Cantidad = pProductos.Cantidad,
                Precio = pProductos.Precio,
                FechaVencimiento = pProductos.FechaVencimiento,
                UnidadMedida = pProductos.UnidadMedida,
                CategoriaId = pProductos.CategoriaId,
            };
            _sysDbContext.productos.Add(producto);
            return await _sysDbContext.SaveChangesAsync();
        }

        public async Task<int> EditProductoAsync (Productos pProductos)
        {
            var producto = await _sysDbContext.productos.FirstOrDefaultAsync(p => p.id == pProductos.id);
            if (producto != null) 
            { 
                producto.Nombre = pProductos.Nombre;
                producto.Cantidad = pProductos.Cantidad;
                producto.Precio = pProductos.Precio;
                producto.FechaVencimiento = pProductos.FechaVencimiento;
                producto.UnidadMedida = pProductos.UnidadMedida;
                producto.CategoriaId = pProductos.CategoriaId;
                return await _sysDbContext.SaveChangesAsync();
            };
            return 0;
        }
        
        public async Task<Productos> GetByIdAsync ( Productos pProductos)
        {
            var productos = await _sysDbContext.productos
                .Include(p => p.categoria)
                .FirstOrDefaultAsync(p => p.id == pProductos.id);

            if(productos != null)
            {
                return new Productos
                {
                    id = productos.id,
                    Nombre = productos.Nombre,
                    Cantidad = productos.Cantidad,
                    Precio = productos.Precio,
                    FechaVencimiento = productos.FechaVencimiento,
                    UnidadMedida = productos.UnidadMedida,
                    CategoriaId = productos.CategoriaId,
                };
            }
            return new Productos();
        }

        public async Task<List<Productos>> GetAllAsync()
        {
            var producto = await _sysDbContext.productos.ToListAsync();
            if (producto != null && producto.Count > 0)
            {
                var list = new List<Productos>();
                producto.ForEach(p => list.Add(new Productos
                    {
                     id =p.id,
                     Nombre = p.Nombre,
                     Cantidad =p.Cantidad,
                     Precio = p.Precio,
                     FechaVencimiento = p.FechaVencimiento,
                     UnidadMedida =p.UnidadMedida,
                     CategoriaId =p.CategoriaId,
                    }));
                return list;
            }
            return new List<Productos>();
        }

        public async Task<int> DeleteAsync (Productos pProductos)
        {
            var productos = await _sysDbContext.productos.FirstOrDefaultAsync(p => p.id == pProductos.id);
            if (productos != null)
            {
                _sysDbContext.productos.Remove(productos);
                return await _sysDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}
