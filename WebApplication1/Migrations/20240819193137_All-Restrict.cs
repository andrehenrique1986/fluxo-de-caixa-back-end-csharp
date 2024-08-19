﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class AllRestrict : Migration
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
                name: "FK_Registro_Subcategoria_IdSubcategoria",
                table: "Registro");

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
                name: "FK_Registro_Subcategoria_IdSubcategoria",
                table: "Registro");

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
                name: "FK_Registro_Subcategoria_IdSubcategoria",
                table: "Registro",
                column: "IdSubcategoria",
                principalTable: "Subcategoria",
                principalColumn: "IdSubcategoria",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
