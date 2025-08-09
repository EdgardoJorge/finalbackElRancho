namespace Model.Response{
    public class BannerResponse
{
    public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string UrlImagen { get; set; } = "";
        public string Redireccion { get; set; } = "";
        public string TerminosYCondiciones { get; set; } = "";
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }
        public int ProductoId { get; set; }
}
}