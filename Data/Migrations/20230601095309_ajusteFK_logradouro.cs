using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class ajusteFK_logradouro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DadosPessoais_PessoaId",
                table: "DadosPessoais");

            migrationBuilder.CreateTable(
                name: "Logradouro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logradouro_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_PessoaId",
                table: "DadosPessoais",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logradouro_PessoaId",
                table: "Logradouro",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logradouro");

            migrationBuilder.DropIndex(
                name: "IX_DadosPessoais_PessoaId",
                table: "DadosPessoais");

            migrationBuilder.CreateIndex(
                name: "IX_DadosPessoais_PessoaId",
                table: "DadosPessoais",
                column: "PessoaId");
        }
    }
}
