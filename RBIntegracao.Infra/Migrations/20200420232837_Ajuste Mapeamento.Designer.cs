﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RBIntegracao.Infra.Repositories.Base;

namespace RBIntegracao.Infra.Migrations
{
    [DbContext(typeof(RBIntegracaoContext))]
    [Migration("20200420232837_Ajuste Mapeamento")]
    partial class AjusteMapeamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RBIntegracao.Domain.Entities.GrupoFornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdFornecedor")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdSolicitacao")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.HasIndex("IdSolicitacao");

                    b.ToTable("GrupoFornecedor");
                });

            modelBuilder.Entity("RBIntegracao.Domain.Entities.Solicitacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CodigoProduto")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataSolicitacao")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<Guid?>("IdUsuario")
                        .HasColumnType("char(36)");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("PrevisaoTermino")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<double>("QuantidadeSolicitada")
                        .HasColumnType("double");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Solicitacao");
                });

            modelBuilder.Entity("RBIntegracao.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("ClienteOuFornecedor")
                        .HasColumnType("int");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("RBIntegracao.Domain.Entities.GrupoFornecedor", b =>
                {
                    b.HasOne("RBIntegracao.Domain.Entities.Usuario", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("IdFornecedor");

                    b.HasOne("RBIntegracao.Domain.Entities.Solicitacao", "Solicitacao")
                        .WithMany()
                        .HasForeignKey("IdSolicitacao");
                });

            modelBuilder.Entity("RBIntegracao.Domain.Entities.Solicitacao", b =>
                {
                    b.HasOne("RBIntegracao.Domain.Entities.Usuario", "EmpresaSolicitante")
                        .WithMany()
                        .HasForeignKey("IdUsuario");
                });

            modelBuilder.Entity("RBIntegracao.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("RBIntegracao.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                                .HasMaxLength(200);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("RBIntegracao.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("NomeFantasia")
                                .IsRequired()
                                .HasColumnName("NomeFantasia")
                                .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                                .HasMaxLength(500);

                            b1.Property<string>("RazaoSocial")
                                .IsRequired()
                                .HasColumnName("RazaoSocial")
                                .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                                .HasMaxLength(500);

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}