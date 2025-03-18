namespace Model.Request
{
    public class DetallePedidoRequest
    {
        public int Id { get; set; }  // 🔹 Asegúrate de que esta línea exista
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }
        public int ProductoId { get; set; }
        public int PedidoId { get; set; }
    }
}
