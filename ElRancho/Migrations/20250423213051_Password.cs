using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class Password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contraseña",
                schema: "Persona",
                table: "Administrador",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "Persona",
                table: "Administrador",
                newName: "Contraseña");
        }
    }
}
