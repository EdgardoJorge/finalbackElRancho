namespace Model.Request
{
    public class EventoRequest
    {
        public string TipoEvento { get; set; }
        public DateOnly FechaEvento { get; set; }
        public string Ubicacion { get; set; }
        public int AdministradorId { get; set; }
    }
}