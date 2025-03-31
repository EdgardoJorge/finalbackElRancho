namespace Model.Response
{
    public class ReservaResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraReserva { get; set; }
        public int NumeroPersonas { get; set; }
        public decimal Adelanto { get; set; }
        public bool Confirmada { get; set; } // Agregado para reflejar el estado de la reserva
    }
}
