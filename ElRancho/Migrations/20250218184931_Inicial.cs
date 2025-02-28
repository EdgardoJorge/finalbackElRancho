﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "persona");

            migrationBuilder.EnsureSchema(
                name: "producto");

            migrationBuilder.EnsureSchema(
                name: "pedido");

            migrationBuilder.EnsureSchema(
                name: "error");

            migrationBuilder.CreateTable(
                name: "Administrador",
                schema: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RUC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    TelefonoFijo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    controller = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    method = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    user_agent = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    host = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    class_component = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    function_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    line_number = table.Column<int>(type: "int", nullable: false),
                    error = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    request = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    error_code = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoEvento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaEvento = table.Column<DateOnly>(type: "date", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecojo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntrega",
                schema: "pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntrega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "banner",
                schema: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Redireccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false),
                    PrecioTotal = table.Column<double>(type: "float", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    PedidoId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TituloOferta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrador",
                schema: "persona");

            migrationBuilder.DropTable(
                name: "banner",
                schema: "producto");

            migrationBuilder.DropTable(
                name: "Cliente",
                schema: "persona");

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
                name: "TipoEntrega",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "Pedido",
                schema: "pedido");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "producto");

            migrationBuilder.DropTable(
                name: "Producto",
                schema: "producto");
        }
    }
}
