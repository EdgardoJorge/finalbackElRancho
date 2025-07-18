using System.ComponentModel.DataAnnotations;

namespace Model.Request{

public class ImagenRequest
{
    [Required] public string Imagenes { get; set; } = "";
    [Required] public int IdProducto { get; set; } = 0;
}}