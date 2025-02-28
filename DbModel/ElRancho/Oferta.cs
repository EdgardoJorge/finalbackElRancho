using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("Oferta", Schema = "producto")]
    public class Oferta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TituloOferta { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public DateOnly FechaInicio { get; set; }
        [Required]
        public DateOnly FechaFin { get; set; }
        [Required]
        public Boolean Activo { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }

        // Relación con Categoria
        public int CategoriaId { get; set; }
    }
}
