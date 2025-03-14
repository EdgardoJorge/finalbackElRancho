using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("Administrador", Schema="Persona")]
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [Required]
        public string Dni { get; set; }  // Cambié de "DNI" a "Dni"

        [Required]
        public string TelefonoMovil { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public string Cargo { get; set; }
    }
}
