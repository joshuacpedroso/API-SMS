using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _4Ucode_sms.Domain.Migrations
{
    public partial class Initial_31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    numero = table.Column<string>(type: "varchar(11)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Contatos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_Envio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumeroId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TextoEnvio = table.Column<string>(type: "varchar(260)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Enviado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Envio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_Envio_tb_Contatos_NumeroId",
                        column: x => x.NumeroId,
                        principalTable: "tb_Contatos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Envio_NumeroId",
                table: "tb_Envio",
                column: "NumeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Envio");

            migrationBuilder.DropTable(
                name: "tb_Contatos");
        }
    }
}
