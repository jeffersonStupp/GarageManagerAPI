using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class UpdateParametrizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DescontoPagamentoVista",
                table: "PARAMETRIZACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaoDeObra",
                table: "PARAMETRIZACAO",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MargemPecas",
                table: "PARAMETRIZACAO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PARAMETRIZACAO",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescontoPagamentoVista", "MaoDeObra", "MargemPecas" },
                values: new object[] { 0, 0m, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescontoPagamentoVista",
                table: "PARAMETRIZACAO");

            migrationBuilder.DropColumn(
                name: "MaoDeObra",
                table: "PARAMETRIZACAO");

            migrationBuilder.DropColumn(
                name: "MargemPecas",
                table: "PARAMETRIZACAO");
        }
    }
}
