using System.ComponentModel.DataAnnotations;

namespace Model.Request{

public class ImagenRequest
{
    [Required] public string Imagenes { get; set; } = "";
}}