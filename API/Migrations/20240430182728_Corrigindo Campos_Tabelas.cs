using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class CorrigindoCampos_Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategoria_Categoria_IdCategoria",
                table: "Subcategoria");

            migrationBuilder.DropIndex(
                name: "IX_Subcategoria_IdCategoria",
                table: "Subcategoria");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIdCategoria",
                table: "Subcategoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategoria_CategoriaIdCategoria",
                table: "Subcategoria",
                column: "CategoriaIdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategoria_Categoria_CategoriaIdCategoria",
                table: "Subcategoria",
                column: "CategoriaIdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategoria_Categoria_CategoriaIdCategoria",
                table: "Subcategoria");

            migrationBuilder.DropIndex(
                name: "IX_Subcategoria_CategoriaIdCategoria",
                table: "Subcategoria");

            migrationBuilder.DropColumn(
                name: "CategoriaIdCategoria",
                table: "Subcategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategoria_IdCategoria",
                table: "Subcategoria",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategoria_Categoria_IdCategoria",
                table: "Subcategoria",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
