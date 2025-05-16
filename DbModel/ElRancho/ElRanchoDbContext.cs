using Microsoft.EntityFrameworkCore;

namespace DbModel.ElRancho
{
    public class ElRanchoDbContext(DbContextOptions<ElRanchoDbContext> opts) : DbContext(opts)
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Error> Errores { get; set; }
        public DbSet<EstadoPedido> EstadosPedido { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<TipoEntrega> TiposEntrega { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public object? UpdateBehavior { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación entre Oferta y Producto
            modelBuilder.Entity<Oferta>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(o => o.ProductoId);

            // Relación entre Oferta y Categoria
            modelBuilder.Entity<Oferta>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(o => o.CategoriaId);

            // Relación entre Banner y Producto
            modelBuilder.Entity<Banner>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(b => b.ProductoId);

            // Relación entre Banner y Categoria
            modelBuilder.Entity<Banner>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(b => b.CategoriaId);

            // Relación entre DetallePedido y Producto
            modelBuilder.Entity<DetallePedido>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(dp => dp.ProductoId);

            // Relación entre DetallePedido y Pedido
            modelBuilder.Entity<DetallePedido>()
                .HasOne<Pedido>()
                .WithMany()
                .HasForeignKey(dp => dp.PedidoId);

            // Relación entre Reserva y Cliente
            modelBuilder.Entity<Reserva>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(r => r.ClienteId);

            // Relación entre Reserva y Mesa
            modelBuilder.Entity<Reserva>()
                .HasOne<Mesa>()
                .WithMany()
                .HasForeignKey(r => r.MesaId);
            modelBuilder.Entity<Producto>()
                .HasOne<Categoria>()
                .WithMany()
                .HasForeignKey(p => p.IdCategoria);
        }
    }
}
