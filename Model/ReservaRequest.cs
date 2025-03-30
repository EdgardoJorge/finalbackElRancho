namespace Model.Request
{
    public class ReservaRequest
    {
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
    }
}