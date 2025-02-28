using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("banner", Schema = "producto")]
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string UrlImagen { get; set; }
        [Required]
        public string Redireccion { get; set; }
        public bool Activo { get; set; }
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
