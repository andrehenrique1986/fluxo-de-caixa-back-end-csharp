using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class CorrigindoCampos_Tabela_Subcategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria",
                table: "Registro");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdSubcategoria",
                table: "Registro",
                column: "IdSubcategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Subcategoria_IdSubcategoria",
                table: "Registro",
                column: "IdSubcategoria",
                principalTable: "Subcategoria",
                principalColumn: "IdSubcategoria",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Subcategoria_IdSubcategoria",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Registro_IdSubcategoria",
                table: "Registro");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria",
                table: "Registro",
                column: "IdCategoria",
                principalTable: "Subcategoria",
                principalColumn: "IdSubcategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
