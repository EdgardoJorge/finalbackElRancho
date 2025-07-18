using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModel.ElRancho
{
    [Table("mesa", Schema = "reservas")]
    public class Mesa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required]
        public bool Disponible { get; set; }

        public string Ubicacion { get; set; }
    }
}
