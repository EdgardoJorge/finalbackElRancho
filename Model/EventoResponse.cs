namespace Model.Response
{
    public class EventoResponse
    {
        public int Id { get; set; }
        public string TipoEvento { get; set; }
        public DateOnly FechaEvento { get; set; }
        public string Ubicacion { get; set; }
        public int AdministradorId { get; set; }
    }
}