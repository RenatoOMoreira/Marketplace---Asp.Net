﻿// <auto-generated />
using System;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpoCenter.Repositorios.SqlServer.Migrations
{
    [DbContext(typeof(ExpoCenterDbContext))]
    [Migration("20220615234324_AdicaoTabelaPagamento")]
    partial class AdicaoTabelaPagamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventoParticipante", b =>
                {
                    b.Property<int>("EventosId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantesId")
                        .HasColumnType("int");

                    b.HasKey("EventosId", "ParticipantesId");

                    b.HasIndex("ParticipantesId");

                    b.ToTable("EventoParticipante");
                });

            modelBuilder.Entity("ExpoCenterDominio.Entidades.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasPrecision(11, 2)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("Evento", (string)null);
                });

            modelBuilder.Entity("ExpoCenterDominio.Entidades.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCartao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Valor")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("Id");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("ExpoCenterDominio.Entidades.Participante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Participante", (string)null);
                });

            modelBuilder.Entity("EventoParticipante", b =>
                {
                    b.HasOne("ExpoCenterDominio.Entidades.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpoCenterDominio.Entidades.Participante", null)
                        .WithMany()
                        .HasForeignKey("ParticipantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
