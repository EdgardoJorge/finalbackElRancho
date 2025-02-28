using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("Pedido", Schema = "pedido")]
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly FechaPedido { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string CodigoPostal { get; set; }
        [Required]
        public DateOnly FechaRecojo { get; set; }
    }
}
