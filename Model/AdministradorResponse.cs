using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Response
{
    public class AdministradorResponse
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public string Dni { get; set; }
    public string TelefonoMovil { get; set; }
    public string CorreoElectronico { get; set; }
    public string Cargo { get; set; }
}
}