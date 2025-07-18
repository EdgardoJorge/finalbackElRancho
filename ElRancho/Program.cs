using Business;
using Business.Profiles;
using Bussines;
using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;
using IBussines;
using Microsoft.Extensions.Options;

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
const string connectionString =
    "Server=localhost,1433;Database=ElRancho;User Id=sa;Password=Edgardo.,01;TrustServerCertificate=True;";
builder.Services.AddDbContext<ElRanchoDbContext>(Options =>
    Options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ElRancho")));
/*const string connectionString = "Data Source=ElRancho";
builder.Services.AddDbContext<ElRanchoDbContext>(options =>
    options.UseSqlite(
        connectionString,
        b => b.MigrationsAssembly("ElRancho")
    )
); */

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
    typeof(TipoEntregaProfile),
    typeof(MesaProfile),
    typeof(ReservaProfile),
    typeof(ImagenProfile),
    typeof(rolProfile)
);

// =============================================
// 4. Registro de dependencias
// =============================================
builder.Services.AddScoped<DbContext, ElRanchoDbContext>();
builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IBannerRepository, BannerRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IDetallePedidoRepository, DetallePedidoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IEstadoPedidoRepository, EstadoPedidoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<ITipoEntregaRepository, TipoEntregaRepository>();
builder.Services.AddScoped<IMesaRepository, MesaRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IImagenRepository, ImagenRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();

builder.Services.AddScoped<IAdministradorBusiness, AdministradorBusiness>();
builder.Services.AddScoped<IBannerBusiness, BannerBusiness>();
builder.Services.AddScoped<ICategoriaBusiness, CategoriaBusiness>();
builder.Services.AddScoped<IProductoBusiness, ProductoBusiness>();
builder.Services.AddScoped<IClienteBusiness, ClienteBusiness>();
builder.Services.AddScoped<IDetallePedidoBusiness, DetalleDePedidoBusiness>();
builder.Services.AddScoped<IPedidoBusiness, PedidoBusiness>();
builder.Services.AddScoped<IEstadoPedidoBusiness, EstadoPedidoBusiness>();
builder.Services.AddScoped<IEventoBusiness, EventoBusiness>();
builder.Services.AddScoped<ITipoEntregaBusiness, TipoEntregaBusiness>();
builder.Services.AddScoped<IMesaBusiness, MesaBusiness>();
builder.Services.AddScoped<IReservaBusiness, ReservaBusiness>();
builder.Services.AddScoped<IImagenBusiness, ImagenBusiness>();
builder.Services.AddScoped<IRolBussines, RolBussines>();
builder.Services.AddScoped<AuthAdminService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// =============================================
// 5. Configuración de autenticación JWT
// =============================================
// Leer configuración del appsettings.json
var jwtKey = builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is missing.");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT Issuer is missing.");
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT Audience is missing.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddScoped<AuthService>();

// =============================================
// 6. Construcción de la aplicación
// =============================================
var app = builder.Build();

// =============================================
// 7. Configuración del pipeline HTTP
// =============================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// =============================================
// 8. Aplicar migraciones automáticamente (OPCIONAL)
// =============================================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ElRanchoDbContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al aplicar migraciones: {ex.Message}");
    }
}

app.Run();
