using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class whatsObj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeWhats",
                table: "CLIENTES",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Obs",
                table: "CLIENTES",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeWhats",
                table: "CLIENTES");

            migrationBuilder.DropColumn(
                name: "Obs",
                table: "CLIENTES");
        }
    }
}
