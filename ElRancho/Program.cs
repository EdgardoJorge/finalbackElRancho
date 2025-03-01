using Business;
using Business.Profiles; // Añade este using para los perfiles de AutoMapper
using DbModel.ElRancho;
using IBussnies;
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
        b => b.MigrationsAssembly("ElRancho") // Asegúrate que el nombre del proyecto sea correcto
    )
);

// =============================================
// 3. Configuración de AutoMapper (CORREGIDO)
// =============================================
builder.Services.AddAutoMapper(typeof(AdministradorProfile)); // Usa el perfil específico

// =============================================
// 4. Registro de dependencias
// =============================================
builder.Services.AddScoped<ICrudRepository<Administrador>, AdministradorRepository>();
builder.Services.AddScoped<IAdministradorBusiness, AdministradorBusiness>();

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
    dbContext.Database.Migrate(); // Aplica migraciones pendientes
}

app.Run();