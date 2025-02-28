using Bussnies;
using DbModel.ElRancho;
using IBussnies;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string con = "Data Source=DESKTOP-9N28ARR;Initial Catalog=FibertelDBase;Integrated Security=True;TrustServerCertificate=True";

// Configuración del DbContext
builder.Services.AddDbContext<ElRanchoDbContext>(options =>
    options.UseSqlServer(con, b => b.MigrationsAssembly("FibertelApiRest"))
);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program)); // Asegúrate de usar la clase correcta aquí

// Registrar el repositorio genérico
builder.Services.AddScoped(typeof(ICrudRepository<Administrador>), typeof(AdministradorRepository));

// Registrar las capas de negocio
builder.Services.AddScoped<IAdministradorBussnies, AdministradorBussnies>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
