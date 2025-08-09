using System.ComponentModel.DataAnnotations;

namespace Model.Request;

public class RolRequest
{
    [Required] public string Name { get; set; } = "";
    [Required] public string Permisos { get; set; } = "";
}