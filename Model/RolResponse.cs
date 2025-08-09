using System.ComponentModel.DataAnnotations;

namespace Model.Response;

public class RolResponse
{
    public int Id { get; set; } = 0;
    [Required] public string Name { get; set; } = "";
    [Required] public string Permisos { get; set; } = "";
}