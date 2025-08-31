namespace Model.Request
{
    public class PedidoRequest
    {
        public DateOnly FechaPedido { get; set; }
        public double Total { get; set; }
        public string? Direccion { get; set; }
        public string? CodigoPostal { get; set; }
        public DateOnly? FechaRecojo { get; set; }
    }
}
