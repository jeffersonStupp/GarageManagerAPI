using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiCentralPark.Migrations
{
    /// <inheritdoc />
    public partial class VidaNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "usuario")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "USUARIOS",
                columns: new[] { "Id", "Email", "NomeUsuario", "Senha", "Tipo" },
                values: new object[,]
                {
                    { 1, "usuario@email.com", "usuario", "usuario", "usuario" },
                    { 2, "jeffersonstupp@hotmail.com", "Jefferson", "0411vm", "administrador" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "USUARIOS");
        }
    }
}
