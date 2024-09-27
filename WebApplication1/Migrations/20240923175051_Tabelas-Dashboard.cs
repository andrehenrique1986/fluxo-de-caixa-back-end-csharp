using Microsoft.EntityFrameworkCore.Migrations;

namespace FluxoCaixa.Migrations
{
    public partial class TabelasDashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fk_IdFluxoRegistro",
                table: "Registro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_IdFluxoRegistro",
                table: "Registro",
                type: "int",
                nullable: true);
        }
    }
}
