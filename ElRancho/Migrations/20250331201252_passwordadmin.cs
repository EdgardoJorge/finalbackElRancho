using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class passwordadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Dni",
                schema: "Persona",
                table: "Administrador",
                newName: "DNI");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                schema: "Persona",
                table: "Administrador",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                schema: "Persona",
                table: "Administrador");

            migrationBuilder.RenameColumn(
                name: "DNI",
                schema: "Persona",
                table: "Administrador",
                newName: "Dni");
        }
    }
}
