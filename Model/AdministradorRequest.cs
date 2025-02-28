using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class AdministradorRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string TelefonoMovil { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Cargo { get; set; }
    }
}