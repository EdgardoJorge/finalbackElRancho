using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DbModel.ElRancho
{
    [Table("reserva", Schema = "reservas")]
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int MesaId { get; set; }

        [Required]
        public DateTime FechaReserva { get; set; }

        [Required]
        public TimeSpan HoraReserva { get; set; }

        [Required]
        public int NumeroPersonas { get; set; }

        public string? Observaciones { get; set; } // Puede ser nulo, ya que no siempre hay observaciones

        [Required]
        public bool Confirmada { get; set; } = false; // Inicialización por defecto

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Adelanto { get; set; } // Pago adelantado requerido para la reserva
    }
}