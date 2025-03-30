namespace Model.Response
{
   public class ReservaResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
    }
}