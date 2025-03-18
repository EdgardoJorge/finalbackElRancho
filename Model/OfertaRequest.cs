using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Oferta
{
    public class OfertaRequest
    {
        [Required]
        public string TituloOferta { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateOnly FechaInicio { get; set; }

        [Required]
        public DateOnly FechaFin { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int CategoriaId { get; set; }
    }
}
