using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TipoEvento { get; set; }
        [Required]
        public DateOnly FechaEvento { get; set; }
        [Required]
        public string Ubicacion { get; set; }
        public int AdministradorId { get; set; }
    }
}
