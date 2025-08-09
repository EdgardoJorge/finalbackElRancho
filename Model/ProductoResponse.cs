namespace Model.Response
{
    public class ProductoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Precio_Oferta { get; set; }
        public bool Activo { get; set; }
        public int IdCategoria { get; set; }
    }
}
