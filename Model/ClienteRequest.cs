using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class ClienteRequest
    {
        [Required]
        public string Nombres { get; set; }

        [Required]
        public string ApellidoPaterno { get; set; }

        [Required]
        public string ApellidoMaterno { get; set; }

        [StringLength(8, ErrorMessage = "El DNI debe tener 8 caracteres.")]
        public string DNI { get; set; }

        [StringLength(11, ErrorMessage = "El RUC debe tener 11 caracteres.")]
        public string RUC { get; set; }

        [StringLength(9, ErrorMessage = "El teléfono móvil debe tener un máximo de 9 caracteres.")]
        public string TelefonoMovil { get; set; }

        [StringLength(10, ErrorMessage = "El teléfono fijo debe tener un máximo de 10 caracteres.")]
        public string? TelefonoFijo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string CorreoElectronico { get; set; }

        [Required]
        public string Direccion { get; set; }

        public string CodigoPostal { get; set; }
    }
}
