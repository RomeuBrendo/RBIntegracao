using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class Ajute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Solicitacao",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000) CHARACTER SET utf8mb4",
                oldMaxLength: 1000,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Solicitacao",
                type: "varchar(1000) CHARACTER SET utf8mb4",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1500,
                oldNullable: true);
        }
    }
}
