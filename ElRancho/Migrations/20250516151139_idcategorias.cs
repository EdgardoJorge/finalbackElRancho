using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class idcategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Producto_IdCategoria",
                schema: "producto",
                table: "Producto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                schema: "producto",
                table: "Producto",
                column: "IdCategoria",
                principalSchema: "producto",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Categoria_IdCategoria",
                schema: "producto",
                table: "Producto");

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
    }
}
