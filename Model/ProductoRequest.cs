namespace Model.Request
{
    public class ProductoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Precio_Oferta { get; set; }
        public bool Activo { get; set; }
        public string Imagen { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public int IdCategoria { get; set; }
    }
}
