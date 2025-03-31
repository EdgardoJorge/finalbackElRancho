using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "reservas");

            migrationBuilder.RenameColumn(
                name: "DNI",
                schema: "Persona",
                table: "Administrador",
                newName: "Dni");

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
                name: "reserva",
                schema: "reservas");

            migrationBuilder.DropTable(
                name: "mesa",
                schema: "reservas");

            migrationBuilder.RenameColumn(
                name: "Dni",
                schema: "Persona",
                table: "Administrador",
                newName: "DNI");
        }
    }
}
