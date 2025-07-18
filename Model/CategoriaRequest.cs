using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class CategoriaRequest
    {
        public required string  CategoriaNombre { get; set; }
        public required string Imagen { get; set; }
    }
}
