using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("Cliente", Schema = "persona")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [StringLength(8)]
        public string DNI { get; set; }
        [StringLength(11)]
        public string RUC { get; set; }
        [StringLength(9)]
        public string TelefonoMovil { get; set; }
        [StringLength(10)]
        public string? TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }
        [Required]
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }

        // 🔐 Nueva propiedad para autenticación
        [Required]
        public string ContraseñaHash { get; set; } // Contraseña cifrada con BCrypt

        public string? TokenRecuperacion { get; set; } // Opcional para recuperar contraseña
    }
}
