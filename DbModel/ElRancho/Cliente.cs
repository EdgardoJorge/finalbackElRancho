using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("Cliente", Schema = "persona")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [StringLength(8)]
        public string DNI { get; set; }
        [StringLength(11)]
        public string RUC { get; set; }
        [StringLength(9)]
        public string TelefonoMovil { get; set; }
        [StringLength(10)]
        public string? TelefonoFijo { get; set; }
        public string CorreoElectronico { get; set; }
        [Required]
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
    }
}
