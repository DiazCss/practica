using sysProductosDAL;
using sysProductoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sysProductosBL
{
    public class CategoriaBL
    {
        private readonly CategoriaDAL _categoriaDAL;

        public CategoriaBL(CategoriaDAL categoriaDAL)
        {
            _categoriaDAL = categoriaDAL;
        }

        public async Task<int> CreateCategoriaAsync(Categoria pCategoria)
        {
            //if (pCategoria == null)
            //{
            //    throw new ArgumentNullException(nameof(pCategoria), "La categoría no puede ser nula.");
            //}

            //if (string.IsNullOrEmpty(pCategoria.Nombre))
            //{
            //    throw new ArgumentException("El nombre de la categoría es obligatorio.", nameof(pCategoria.Nombre));
            //}

            return await _categoriaDAL.CreateCategoriaAsync(pCategoria);
        }

        public async Task<int> UpdateCategoriaAsync(Categoria pCategoria)
        {
            //if (pCategoria == null)
            //{
            //    throw new ArgumentNullException(nameof(pCategoria), "La categoría no puede ser nula.");
            //}

            //if (pCategoria.CategoriaId <= 0)
            //{
            //    throw new ArgumentException("El ID de la categoría debe ser mayor que cero.", nameof(pCategoria.CategoriaId));
            //}

            return await _categoriaDAL.UpdateCategoriaAsync(pCategoria);
        }

        public async Task<int> DeleteCategoriaAsync(int categoriaId)
        {
            //if (categoriaId <= 0)
            //{
            //    throw new ArgumentException("El ID de la categoría debe ser mayor que cero.", nameof(categoriaId));
            //}

            var categoria = new Categoria { CategoriaId = categoriaId };
            return await _categoriaDAL.DeleteCategoriaAsync(categoria);
        }

        public async Task<Categoria> GetByIdAsync(int categoriaId)
        {
            //if (categoriaId <= 0)
            //{
            //    throw new ArgumentException("El ID de la categoría debe ser mayor que cero.", nameof(categoriaId));
            //}

            var categoria = await _categoriaDAL.GetById(new Categoria { CategoriaId = categoriaId });

            //if (categoria == null)
            //{
            //    throw new KeyNotFoundException($"No se encontró la categoría con ID {categoriaId}.");
            //}

            return categoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await _categoriaDAL.GetAllAsync(new Categoria());
        }
    }
}
