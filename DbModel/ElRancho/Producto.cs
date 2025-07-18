using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("Producto", Schema = "producto")]
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }
        public double Precio_Oferta { get; set; }
        [Required]
        public Boolean Activo { get; set; }
        [Required]
        public string Imagen { get; set; }
        [Required]
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public int IdCategoria { get; set; }
    }
}
