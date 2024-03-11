using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class Parametrizaca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PARAMETRIZACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomologacaoDireta = table.Column<bool>(type: "bit", nullable: false),
                    IdadeMinimaCadastro = table.Column<int>(type: "int", nullable: false),
                    IdadeMaximaCadastro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETRIZACAO", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PARAMETRIZACAO",
                columns: new[] { "Id", "HomologacaoDireta", "IdadeMaximaCadastro", "IdadeMinimaCadastro" },
                values: new object[] { 1, false, 100, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PARAMETRIZACAO");
        }
    }
}
