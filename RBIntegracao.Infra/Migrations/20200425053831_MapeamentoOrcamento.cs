using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class MapeamentoOrcamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    Frete = table.Column<double>(nullable: false),
                    Seguro = table.Column<double>(nullable: false),
                    FormaPagamento = table.Column<string>(maxLength: 50, nullable: true),
                    Parcelas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    ValorUnitarioItem = table.Column<double>(nullable: false),
                    ValorTotalItem = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoSolicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdOrcamento = table.Column<Guid>(nullable: true),
                    IdSolicitacao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoSolicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoSolicitacao_Orcamento_IdOrcamento",
                        column: x => x.IdOrcamento,
                        principalTable: "Orcamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrcamentoSolicitacao_Solicitacao_IdSolicitacao",
                        column: x => x.IdSolicitacao,
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoSolicitacao_IdOrcamento",
                table: "OrcamentoSolicitacao",
                column: "IdOrcamento");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoSolicitacao_IdSolicitacao",
                table: "OrcamentoSolicitacao",
                column: "IdSolicitacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoItem");

            migrationBuilder.DropTable(
                name: "OrcamentoSolicitacao");

            migrationBuilder.DropTable(
                name: "Orcamento");
        }
    }
}
