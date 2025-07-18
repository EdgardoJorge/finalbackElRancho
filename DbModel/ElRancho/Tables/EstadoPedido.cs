using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("EstadoPedido", Schema = "pedido")]
    public class EstadoPedido
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
