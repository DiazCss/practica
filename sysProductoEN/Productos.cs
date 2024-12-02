using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sysProductoEN
{
    public class Productos
    {
        [Key] 
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")] 
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")] 
        public string Nombre { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo.")] 
        public int Cantidad { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "La unidad de medida debe ser un número positivo.")] 
        public decimal? UnidadMedida { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")] 
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un número positivo.")] 
        public decimal Precio { get; set; }

        [DataType(DataType.Date)] 
        [Display(Name = "Fecha de Vencimiento")] 
        public DateTime? FechaVencimiento { get; set; }

        [ForeignKey("Categoria")] 
        public int CategoriaId { get; set; }

        public Categoria? categoria { get; set; } 
    }
}
