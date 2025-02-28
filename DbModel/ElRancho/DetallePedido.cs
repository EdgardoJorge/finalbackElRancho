using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("DetallePedido", Schema = "pedido")]
    public class DetallePedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        [Required]
        public double PrecioTotal { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
    }
}
