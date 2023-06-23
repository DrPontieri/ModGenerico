using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class RelacoesPaymentLogradouro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_LogradourosS_PessoaId",
                table: "LogradourosS");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "paymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_paymentDetails_PessoaId",
                table: "paymentDetails",
                column: "PessoaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LogradourosS_PessoaId",
                table: "LogradourosS",
                column: "PessoaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentDetails_Pessoa_PessoaId",
                table: "paymentDetails",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentDetails_Pessoa_PessoaId",
                table: "paymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_paymentDetails_PessoaId",
                table: "paymentDetails");

            migrationBuilder.DropIndex(
                name: "IX_LogradourosS_PessoaId",
                table: "LogradourosS");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "paymentDetails");

            migrationBuilder.CreateIndex(
                name: "IX_LogradourosS_PessoaId",
                table: "LogradourosS",
                column: "PessoaId");
        }
    }
}
