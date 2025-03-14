using Business;
using Business.Profiles; // Perfiles de AutoMapper
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
builder.Services.AddAutoMapper(typeof(AdministradorProfile), typeof(BannerProfile));

// =============================================
// 4. Registro de dependencias
// =============================================
// Registrar CrudRepository para cualquier entidad genérica
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped(typeof(CrudRepository<>)); // Registro sin la interfaz

// Registrar servicios específicos
builder.Services.AddScoped<IAdministradorBusiness, AdministradorBusiness>();
builder.Services.AddScoped<IBannerBusiness, BannerBusiness>();

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
