using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class tree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContraseñaHash",
                schema: "persona",
                table: "Cliente",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TokenRecuperacion",
                schema: "persona",
                table: "Cliente",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContraseñaHash",
                schema: "persona",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "TokenRecuperacion",
                schema: "persona",
                table: "Cliente");
        }
    }
}
