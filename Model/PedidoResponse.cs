namespace Model.Response
{
    public class PedidoResponse
    {
        public int Id { get; set; }
        public DateOnly FechaPedido { get; set; }
        public double Total { get; set; }
        public string? Direccion { get; set; }
        public string? CodigoPostal { get; set; }
        public DateOnly? FechaRecojo { get; set; }
    }
}
