using Microsoft.EntityFrameworkCore;
using sysProductoEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysProductosDAL
{
    public class CategoriaDAL
    {
        private readonly sysDbContext _sysDbContext;

        public CategoriaDAL(sysDbContext sysDbContext)
        {
            _sysDbContext = sysDbContext;
        }

        public async Task<int> CreateCategoriaAsync (Categoria pCategoria)
        {
            var categoria = new Categoria
            {
                Nombre = pCategoria.Nombre,
                Descripcion = pCategoria.Descripcion,
            };
            _sysDbContext.Add(categoria);
            return await _sysDbContext.SaveChangesAsync();
        }


        public async Task<int> UpdateCategoriaAsync(Categoria pCategoria)
        {
            var categoria = await _sysDbContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if (categoria != null)
            {
                categoria.Nombre = pCategoria.Nombre;
                categoria.Descripcion = pCategoria.Descripcion;
                return await _sysDbContext.SaveChangesAsync();
            };
            return 0;
        }

        public async Task<int> DeleteCategoriaAsync (Categoria pCategoria)
        {
            var categoria = await _sysDbContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if(categoria != null)
            {
                _sysDbContext.categoria.Remove(categoria);
                return await _sysDbContext.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Categoria> GetById (Categoria pCategoria)
        {
            var categoria = await _sysDbContext.categoria.FirstOrDefaultAsync(p => p.CategoriaId == pCategoria.CategoriaId);
            if ( categoria != null)
            {
                return new Categoria
                {
                    CategoriaId = categoria.CategoriaId,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
                };
            }
            return new Categoria();
        }

        public async Task<List<Categoria>> GetAllAsync (Categoria pCategoria)
        {
            var categoria = await _sysDbContext.categoria.ToListAsync();
            if (categoria != null && categoria.Count > 0)
            {
                var list = new List<Categoria>();
                categoria.ForEach(c => list.Add(new Categoria
                {
                    CategoriaId=c.CategoriaId,
                    Nombre = c.Nombre,
                    Descripcion=c.Descripcion,
                }));
                return list;
            }
            return new List<Categoria>();
        }
    }
}
