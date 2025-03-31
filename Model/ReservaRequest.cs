namespace Model.Request
{
    public class ReservaRequest
    {
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; } // Agregado porque es requerido en el modelo
        public int NumeroPersonas { get; set; }  // Corregido el nombre para coincidir con Reserva
        public decimal Adelanto { get; set; }    // Agregado porque es requerido en el modelo
    }
}
