using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysProductoEN
{
    public class Productos
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal? UnidadMedida { get; set; }
        public decimal Precio { get; set; }
        public DateTime? FechaVencimiento { get; set; }


        public int CategoriaId { get; set; }
        public Categoria? categoria { get; set; }
    }
}
