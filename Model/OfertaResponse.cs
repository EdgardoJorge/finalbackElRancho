using System;

namespace Model.Oferta
{
    public class OfertaResponse
    {
        public int Id { get; set; }
        public string TituloOferta { get; set; }
        public string Descripcion { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public bool Activo { get; set; }
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
    }
}
