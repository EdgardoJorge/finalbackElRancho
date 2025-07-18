using System.ComponentModel.DataAnnotations;

namespace Model.Response{

public class ImagenResponse
{
 public int Id { get; set; } = 0;
 [Required] public string Imagenes { get; set; } = "";
}}