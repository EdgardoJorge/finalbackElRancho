namespace Model.Response
{
    public class DetallePedidoResponse
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
    }
}