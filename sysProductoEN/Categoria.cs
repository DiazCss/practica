using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sysProductoEN
{
    public class Categoria
    {
        [Key] // Define la clave primaria.
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")] // Campo obligatorio.
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")] // Longitud máxima de caracteres.
        public string Nombre { get; set; }

        [StringLength(250, ErrorMessage = "La descripción no puede tener más de 250 caracteres.")] // Longitud máxima para la descripción.
        public string Descripcion { get; set; }

        [InverseProperty("Categoria")] // Relación inversa hacia la entidad Productos.
        public List<Productos> Productos { get; set; }
    }
}
