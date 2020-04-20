using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class AjusteMapeamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome_RazaoSocial",
                table: "Usuario",
                newName: "RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "Nome_NomeFantasia",
                table: "Usuario",
                newName: "NomeFantasia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RazaoSocial",
                table: "Usuario",
                newName: "Nome_RazaoSocial");

            migrationBuilder.RenameColumn(
                name: "NomeFantasia",
                table: "Usuario",
                newName: "Nome_NomeFantasia");
        }
    }
}
