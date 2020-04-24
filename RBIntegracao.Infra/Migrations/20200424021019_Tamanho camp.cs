using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class Tamanhocamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Solicitacao",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1500) CHARACTER SET utf8mb4",
                oldMaxLength: 1500,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Solicitacao",
                type: "varchar(1500) CHARACTER SET utf8mb4",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
