using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class idcategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                schema: "producto",
                table: "Producto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                schema: "producto",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Producto_IdCategoria",
                schema: "producto",
                table: "Producto",
                column: "IdCategoria",
                principalSchema: "producto",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Producto_IdCategoria",
                schema: "producto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdCategoria",
                schema: "producto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                schema: "producto",
                table: "Producto");
        }
    }
}
