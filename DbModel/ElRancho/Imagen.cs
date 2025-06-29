using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("Imagenes", Schema = "producto")]
    public class Imagen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Imagenes { get; set; } = "";
        [Required]
        public int IdProductos { get; set; }
    }
}