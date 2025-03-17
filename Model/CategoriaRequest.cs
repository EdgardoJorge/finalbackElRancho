using System.ComponentModel.DataAnnotations;

namespace Model.Request
{
    public class CategoriaRequest
    {
        [Required]
        public string CategoriaNombre { get; set; }
    }
}
