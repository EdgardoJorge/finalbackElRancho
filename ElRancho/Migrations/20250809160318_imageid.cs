using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElRancho.Migrations
{
    /// <inheritdoc />
    public partial class imageid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Producto_IdProductos",
                schema: "producto",
                table: "Imagenes");

            migrationBuilder.RenameColumn(
                name: "IdProductos",
                schema: "producto",
                table: "Imagenes",
                newName: "IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_Imagenes_IdProductos",
                schema: "producto",
                table: "Imagenes",
                newName: "IX_Imagenes_IdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Producto_IdProducto",
                schema: "producto",
                table: "Imagenes",
                column: "IdProducto",
                principalSchema: "producto",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Producto_IdProducto",
                schema: "producto",
                table: "Imagenes");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                schema: "producto",
                table: "Imagenes",
                newName: "IdProductos");

            migrationBuilder.RenameIndex(
                name: "IX_Imagenes_IdProducto",
                schema: "producto",
                table: "Imagenes",
                newName: "IX_Imagenes_IdProductos");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Producto_IdProductos",
                schema: "producto",
                table: "Imagenes",
                column: "IdProductos",
                principalSchema: "producto",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
