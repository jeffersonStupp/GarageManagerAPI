using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class CelularImplement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeWhats",
                table: "CLIENTES");

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "CLIENTES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "CLIENTES");

            migrationBuilder.AddColumn<string>(
                name: "NomeWhats",
                table: "CLIENTES",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
