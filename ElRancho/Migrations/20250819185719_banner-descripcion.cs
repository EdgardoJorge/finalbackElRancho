using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class bannerdescripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "producto",
                table: "banner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "producto",
                table: "banner");
        }
    }
}
