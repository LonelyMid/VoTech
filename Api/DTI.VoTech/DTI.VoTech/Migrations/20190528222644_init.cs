using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DTI.VoTech.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    TemaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Votos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.TemaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Techshots",
                columns: table => new
                {
                    TechshotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TemasTemaId = table.Column<int>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techshots", x => x.TechshotId);
                    table.ForeignKey(
                        name: "FK_Techshots_Temas_TemasTemaId",
                        column: x => x.TemasTemaId,
                        principalTable: "Temas",
                        principalColumn: "TemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votacoes",
                columns: table => new
                {
                    VotacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Duracao = table.Column<DateTime>(nullable: false),
                    TemaVencedorTemaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votacoes", x => x.VotacaoId);
                    table.ForeignKey(
                        name: "FK_Votacoes_Temas_TemaVencedorTemaId",
                        column: x => x.TemaVencedorTemaId,
                        principalTable: "Temas",
                        principalColumn: "TemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Techshots_TemasTemaId",
                table: "Techshots",
                column: "TemasTemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Votacoes_TemaVencedorTemaId",
                table: "Votacoes",
                column: "TemaVencedorTemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Techshots");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Votacoes");

            migrationBuilder.DropTable(
                name: "Temas");
        }
    }
}
