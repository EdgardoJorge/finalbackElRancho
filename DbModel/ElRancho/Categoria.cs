using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("Categoria", Schema = "producto")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CategoriaNombre { get; set; }
    }
}
