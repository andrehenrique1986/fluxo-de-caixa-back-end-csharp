using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class CorrigindoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Categoria_IdCategoria",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Custo_IdCusto",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Fluxo_IdFluxo",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_FormaDePagamento_IdFormaDePagamento",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria_IdSubcategoria",
                table: "Registro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registro",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Registro_IdCategoria_IdSubcategoria",
                table: "Registro");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategoria",
                table: "Subcategoria",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria",
                column: "IdSubcategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registro",
                table: "Registro",
                column: "IdRegistro");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategoria_IdCategoria",
                table: "Subcategoria",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCategoria",
                table: "Registro",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Categoria_IdCategoria",
                table: "Registro",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Custo_IdCusto",
                table: "Registro",
                column: "IdCusto",
                principalTable: "Custo",
                principalColumn: "IdCusto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Fluxo_IdFluxo",
                table: "Registro",
                column: "IdFluxo",
                principalTable: "Fluxo",
                principalColumn: "IdFluxo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_FormaDePagamento_IdFormaDePagamento",
                table: "Registro",
                column: "IdFormaDePagamento",
                principalTable: "FormaDePagamento",
                principalColumn: "IdFormaDePagamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria",
                table: "Registro",
                column: "IdCategoria",
                principalTable: "Subcategoria",
                principalColumn: "IdSubcategoria",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Categoria_IdCategoria",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Custo_IdCusto",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Fluxo_IdFluxo",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_FormaDePagamento_IdFormaDePagamento",
                table: "Registro");

            migrationBuilder.DropForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria",
                table: "Registro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria");

            migrationBuilder.DropIndex(
                name: "IX_Subcategoria_IdCategoria",
                table: "Subcategoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Registro",
                table: "Registro");

            migrationBuilder.DropIndex(
                name: "IX_Registro_IdCategoria",
                table: "Registro");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategoria",
                table: "Subcategoria",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subcategoria",
                table: "Subcategoria",
                columns: new[] { "IdCategoria", "IdSubcategoria" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Registro",
                table: "Registro",
                columns: new[] { "IdRegistro", "IdCategoria", "IdSubcategoria", "IdCusto", "IdFluxo", "IdFormaDePagamento" });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCategoria_IdSubcategoria",
                table: "Registro",
                columns: new[] { "IdCategoria", "IdSubcategoria" });

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Categoria_IdCategoria",
                table: "Registro",
                column: "IdCategoria",
                principalTable: "Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Custo_IdCusto",
                table: "Registro",
                column: "IdCusto",
                principalTable: "Custo",
                principalColumn: "IdCusto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Fluxo_IdFluxo",
                table: "Registro",
                column: "IdFluxo",
                principalTable: "Fluxo",
                principalColumn: "IdFluxo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_FormaDePagamento_IdFormaDePagamento",
                table: "Registro",
                column: "IdFormaDePagamento",
                principalTable: "FormaDePagamento",
                principalColumn: "IdFormaDePagamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Registro_Subcategoria_IdCategoria_IdSubcategoria",
                table: "Registro",
                columns: new[] { "IdCategoria", "IdSubcategoria" },
                principalTable: "Subcategoria",
                principalColumns: new[] { "IdCategoria", "IdSubcategoria" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
