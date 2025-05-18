using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Persona");

            migrationBuilder.EnsureSchema(
                name: "producto");

            migrationBuilder.EnsureSchema(
                name: "persona");

            migrationBuilder.EnsureSchema(
                name: "pedido");

            migrationBuilder.EnsureSchema(
                name: "error");

            migrationBuilder.EnsureSchema(
                name: "reservas");

            migrationBuilder.CreateTable(
                name: "Administrador",
                schema: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonoMovil = table.Column<string>(type: "TEXT", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaNombre = table.Column<string>(type: "TEXT", nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                schema: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "TEXT", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "TEXT", nullable: false),
                    DNI = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    RUC = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    TelefonoMovil = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    TelefonoFijo = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoPostal = table.Column<string>(type: "TEXT", nullable: false),
                    ContraseñaHash = table.Column<string>(type: "TEXT", nullable: false),
                    TokenRecuperacion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "error",
                schema: "error",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    url = table.Column<string>(type: "TEXT", nullable: true),
                    controller = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ip = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    method = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    user_agent = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    host = table.Column<string>(type: "TEXT", nullable: true),
                    class_component = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    function_name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    line_number = table.Column<int>(type: "INTEGER", nullable: false),
                    error = table.Column<string>(type: "TEXT", nullable: true),
                    StackTrace = table.Column<string>(type: "TEXT", nullable: true),
                    status = table.Column<short>(type: "INTEGER", nullable: false),
                    request = table.Column<string>(type: "TEXT", nullable: true),
                    error_code = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_error", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPedido",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoEvento = table.Column<string>(type: "TEXT", nullable: false),
                    FechaEvento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Ubicacion = table.Column<string>(type: "TEXT", nullable: false),
                    AdministradorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mesa",
                schema: "reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponible = table.Column<bool>(type: "INTEGER", nullable: false),
                    Ubicacion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaPedido = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", nullable: false),
                    CodigoPostal = table.Column<string>(type: "TEXT", nullable: false),
                    FechaRecojo = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntrega",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormaEntrega = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Imagen = table.Column<string>(type: "TEXT", nullable: false),
                    Imagen2 = table.Column<string>(type: "TEXT", nullable: false),
                    Imagen3 = table.Column<string>(type: "TEXT", nullable: false),
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalSchema: "producto",
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reserva",
                schema: "reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraReserva = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    NumeroPersonas = table.Column<int>(type: "INTEGER", nullable: false),
                    Confirmada = table.Column<bool>(type: "INTEGER", nullable: false),
                    Adelanto = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reserva_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalSchema: "persona",
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reserva_mesa_MesaId",
                        column: x => x.MesaId,
                        principalSchema: "reservas",
                        principalTable: "mesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "banner",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    UrlImagen = table.Column<string>(type: "TEXT", nullable: false),
                    Redireccion = table.Column<string>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_banner_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "producto",
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_banner_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "producto",
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "REAL", nullable: false),
                    PrecioTotal = table.Column<double>(type: "REAL", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalSchema: "pedido",
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "producto",
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TituloOferta = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "producto",
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oferta_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalSchema: "producto",
                        principalTable: "Producto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_banner_CategoriaId",
                schema: "producto",
                table: "banner",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_banner_ProductoId",
                schema: "producto",
                table: "banner",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoId",
                schema: "pedido",
                table: "DetallePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoId",
                schema: "pedido",
                table: "DetallePedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_CategoriaId",
                schema: "producto",
                table: "Oferta",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ProductoId",
                schema: "producto",
                table: "Oferta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                schema: "producto",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_reserva_ClienteId",
                schema: "reservas",
                table: "reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_reserva_MesaId",
                schema: "reservas",
                table: "reserva",
                column: "MesaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador",
                schema: "Persona");

            migrationBuilder.DropTable(
                name: "banner",
                schema: "producto");

            migrationBuilder.DropTable(
                name: "DetallePedido",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "error",
                schema: "error");

            migrationBuilder.DropTable(
                name: "EstadoPedido",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Oferta",
                schema: "producto");

            migrationBuilder.DropTable(
                name: "reserva",
                schema: "reservas");

            migrationBuilder.DropTable(
                name: "TipoEntrega",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "producto");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "persona");

            migrationBuilder.DropTable(
                name: "mesa",
                schema: "reservas");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "producto");
        }
    }
}
