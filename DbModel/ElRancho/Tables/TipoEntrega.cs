using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("TipoEntrega", Schema = "pedido")]
    public class TipoEntrega
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FormaEntrega { get; set; }
    }
}
