using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho{
    [Table("Rol", Schema = "Persona")]
public class Rol
{
    [Key]
    public int Id {get; set; }
    [Required] public string Name { get; set; } = "";
    [Required] public string Permisos { get; set; } = "";
}}
