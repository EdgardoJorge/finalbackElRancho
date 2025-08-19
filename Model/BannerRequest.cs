using System.ComponentModel.DataAnnotations;

namespace Model.Request{
    public class BannerRequest
{
        [Required]
        public string Titulo { get; set; } = "";
        [Required]
        public string Descripcion { get; set; } = "";

        [Required]
        public string UrlImagen { get; set; } = "";

        [Required]
        public string Redireccion { get; set; } = "";
        [Required]
        public string TerminosYCondiciones { get; set; } = "";
        [Required]
        public DateTime FechaInicio { get; set; }
        [Required]
        public DateTime FechaFin { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public int ProductoId { get; set; }

}

}