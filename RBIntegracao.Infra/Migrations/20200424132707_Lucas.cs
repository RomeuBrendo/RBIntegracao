using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class Lucas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "Solicitacao",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "Solicitacao");
        }
    }
}
