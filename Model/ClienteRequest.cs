public class ClienteRequest
{
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public string DNI { get; set; }
    public string RUC { get; set; }
    public string TelefonoMovil { get; set; }
    public string TelefonoFijo { get; set; }
    public string CorreoElectronico { get; set; }
    public string Direccion { get; set; }
    public string CodigoPostal { get; set; }
    public string Contraseña { get; set; }  // ✅ Agregar campo para la contraseña
}
