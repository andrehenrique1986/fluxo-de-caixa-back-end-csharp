using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class Novas_Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Custo",
                columns: table => new
                {
                    IdCusto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCusto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custo", x => x.IdCusto);
                });

            migrationBuilder.CreateTable(
                name: "Fluxo",
                columns: table => new
                {
                    IdFluxo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoFluxo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluxo", x => x.IdFluxo);
                });

            migrationBuilder.CreateTable(
                name: "FormaDePagamento",
                columns: table => new
                {
                    IdFormaDePagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoFormaDePagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaDePagamento", x => x.IdFormaDePagamento);
                });

            migrationBuilder.CreateTable(
                name: "Registro",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFluxo = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdSubcategoria = table.Column<int>(type: "int", nullable: false),
                    IdCusto = table.Column<int>(type: "int", nullable: false),
                    IdFormaDePagamento = table.Column<int>(type: "int", nullable: false),
                    DtRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorRegistro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro", x => new { x.IdRegistro, x.IdCategoria, x.IdSubcategoria, x.IdCusto, x.IdFluxo, x.IdFormaDePagamento });
                    table.ForeignKey(
                        name: "FK_Registro_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registro_Custo_IdCusto",
                        column: x => x.IdCusto,
                        principalTable: "Custo",
                        principalColumn: "IdCusto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registro_Fluxo_IdFluxo",
                        column: x => x.IdFluxo,
                        principalTable: "Fluxo",
                        principalColumn: "IdFluxo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registro_FormaDePagamento_IdFormaDePagamento",
                        column: x => x.IdFormaDePagamento,
                        principalTable: "FormaDePagamento",
                        principalColumn: "IdFormaDePagamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Registro_Subcategoria_IdCategoria_IdSubcategoria",
                        columns: x => new { x.IdCategoria, x.IdSubcategoria },
                        principalTable: "Subcategoria",
                        principalColumns: new[] { "IdCategoria", "IdSubcategoria" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCategoria_IdSubcategoria",
                table: "Registro",
                columns: new[] { "IdCategoria", "IdSubcategoria" });

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdCusto",
                table: "Registro",
                column: "IdCusto");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdFluxo",
                table: "Registro",
                column: "IdFluxo");

            migrationBuilder.CreateIndex(
                name: "IX_Registro_IdFormaDePagamento",
                table: "Registro",
                column: "IdFormaDePagamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro");

            migrationBuilder.DropTable(
                name: "Custo");

            migrationBuilder.DropTable(
                name: "Fluxo");

            migrationBuilder.DropTable(
                name: "FormaDePagamento");
        }
    }
}
