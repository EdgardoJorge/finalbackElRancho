using Business;
using Business.Profiles; // Perfiles de AutoMapper
using Bussines;
using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// =============================================
// 1. Configuración de servicios
// =============================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =============================================
// 2. Configuración de la base de datos (SQLite)
// =============================================
const string connectionString = "Data Source=ElRancho.db";
builder.Services.AddDbContext<ElRanchoDbContext>(options =>
    options.UseSqlite(
        connectionString,
        b => b.MigrationsAssembly("ElRancho") // Asegúrate de que el nombre del proyecto sea correcto
    )
);

// =============================================
// 3. Configuración de AutoMapper
// =============================================
builder.Services.AddAutoMapper(
    typeof(AdministradorProfile),
    typeof(BannerProfile),
    typeof(CategoriaProfile),
    typeof(ProductoProfile),
    typeof(ClienteProfile),
    typeof(DetalleDePedidoProfile),
    typeof(PedidoProfile),
    typeof(EstadoPedidoProfile),
    typeof(EventoProfile),
    typeof(OfertaProfile)
);

// =============================================
// 4. Registro de dependencias
// =============================================
// Registrar el contexto de la base de datos como `DbContext`
builder.Services.AddScoped<DbContext, ElRanchoDbContext>();

// Registrar CrudRepository con el contexto correcto
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));

// Registrar repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IOfertaRepository, OfertaRepository>();
// Registrar servicios específicos
builder.Services.AddScoped<IAdministradorBusiness, AdministradorBusiness>();
builder.Services.AddScoped<IBannerBusiness, BannerBusiness>();
builder.Services.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<IDetallePedidoBusiness, DetalleDePedidoBusiness>();
builder.Services.AddScoped<IPedidoBusiness, PedidoBusiness>();
builder.Services.AddScoped<IEstadoPedidoBusiness, EstadoPedidoBusiness>();
builder.Services.AddScoped<IEventoBusiness, EventoBusiness>();
builder.Services.AddScoped<IOfertaBusiness, OfertaBusiness>();

// =============================================
// 5. Construcción de la aplicación
// =============================================
var app = builder.Build();

// =============================================
// 6. Configuración del pipeline HTTP
// =============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// =============================================
// 7. Aplicar migraciones automáticamente (OPCIONAL)
// =============================================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ElRanchoDbContext>();
    try
    {
        dbContext.Database.Migrate(); // Aplica migraciones pendientes
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
    }
}

app.Run();
