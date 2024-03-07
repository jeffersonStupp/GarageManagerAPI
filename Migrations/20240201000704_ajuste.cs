using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class ajuste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "CLIENTES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "normal",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Situacao",
                table: "CLIENTES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "normal");
        }
    }
}
