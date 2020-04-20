using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RBIntegracao.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome_RazaoSocial = table.Column<string>(maxLength: 500, nullable: true),
                    Nome_NomeFantasia = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    Senha = table.Column<string>(maxLength: 36, nullable: false),
                    CnpjCpf = table.Column<string>(nullable: false),
                    ClienteOuFornecedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdUsuario = table.Column<Guid>(nullable: true),
                    CodigoProduto = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(maxLength: 500, nullable: false),
                    PrevisaoTermino = table.Column<DateTime>(nullable: false),
                    QuantidadeSolicitada = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 1000, nullable: true),
                    DataSolicitacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GrupoFornecedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdFornecedor = table.Column<Guid>(nullable: true),
                    IdSolicitacao = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoFornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoFornecedor_Usuario_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GrupoFornecedor_Solicitacao_IdSolicitacao",
                        column: x => x.IdSolicitacao,
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoFornecedor_IdFornecedor",
                table: "GrupoFornecedor",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoFornecedor_IdSolicitacao",
                table: "GrupoFornecedor",
                column: "IdSolicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_IdUsuario",
                table: "Solicitacao",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoFornecedor");

            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
