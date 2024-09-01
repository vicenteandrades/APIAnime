using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace APIAnime.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.GeneroId);
                });

            migrationBuilder.CreateTable(
                name: "Desenho",
                columns: table => new
                {
                    DesenhoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    AnoDeLancamento = table.Column<int>(type: "integer", nullable: false),
                    GeneroId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenho", x => x.DesenhoId);
                    table.ForeignKey(
                        name: "FK_Desenho_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "GeneroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Resumo = table.Column<string>(type: "text", nullable: false),
                    Foto = table.Column<string>(type: "text", nullable: false),
                    DesenhoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.PersonagemId);
                    table.ForeignKey(
                        name: "FK_Personagem_Desenho_DesenhoId",
                        column: x => x.DesenhoId,
                        principalTable: "Desenho",
                        principalColumn: "DesenhoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desenho_GeneroId",
                table: "Desenho",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_DesenhoId",
                table: "Personagem",
                column: "DesenhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Desenho");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
