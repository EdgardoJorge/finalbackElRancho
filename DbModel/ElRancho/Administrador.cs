using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModel.ElRancho
{
    [Table("Administrador" , Schema = "persona")]
    public class Administrador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string ApellidoPaterno { get; set; }
        [Required]
        public string ApellidoMaterno { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string TelefonoMovil { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Cargo { get; set; }
    }
}
