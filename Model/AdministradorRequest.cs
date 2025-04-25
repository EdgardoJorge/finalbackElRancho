using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class AdministradorRequest
{ // Agregar la propiedad Id

    [Required]
    public string Nombres { get; set; }

    [Required]
    public string ApellidoPaterno { get; set; }

    [Required]
    public string ApellidoMaterno { get; set; }

    [Required]
    public string Dni { get; set; }

    [Required]
    public string TelefonoMovil { get; set; }

    [Required]
    public string CorreoElectronico { get; set; }

    [Required]
    public string Cargo { get; set; }
    [Required]
    public string Password { get; set; }  // Se agregó la contraseña
}
}