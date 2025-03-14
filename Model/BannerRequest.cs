using System.ComponentModel.DataAnnotations;

namespace Model.Request{
    public class BannerRequest
{
    [Required]
    public string Titulo { get; set; }

    [Required]
    public string UrlImagen { get; set; }

    [Required]
    public string Redireccion { get; set; }

    public bool Activo { get; set; }

    public int ProductoId { get; set; }

    public int CategoriaId { get; set; }
}

}