using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class Relacao_Categoria_Subcategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria");

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Subcategoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria",
                columns: new[] { "IdCategoria", "IdSubcategoria" });

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategoria_Categoria_IdCategoria",
                table: "Subcategoria",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subcategoria_Categoria_IdCategoria",
                table: "Subcategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Subcategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria",
                column: "IdSubcategoria");
        }
    }
}
