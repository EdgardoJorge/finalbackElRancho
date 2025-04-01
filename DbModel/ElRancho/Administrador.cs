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
        public string DNI { get; set; }  // Está en mayúsculas como solicitaste

        [Required]
        public string TelefonoMovil { get; set; }

        [Required]
        public string CorreoElectronico { get; set; }

        [Required]
        public string Cargo { get; set; }

        [Required]
        public string Contraseña { get; set; }  // Se agregó la contraseña
    }
}
