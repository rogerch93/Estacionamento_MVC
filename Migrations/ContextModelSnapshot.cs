﻿// <auto-generated />
using System;
using EstacionamentoDotnet6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstacionamentoDotnet6.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarroId"), 1L, 1);

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCarro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PessoasId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarroId");

                    b.HasIndex("PessoasId")
                        .IsUnique();

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Estadia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("HoraEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraSaida")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumVaga")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Estadias");
                });

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<int>("PessoasId")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"), 1L, 1);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Carro", b =>
                {
                    b.HasOne("EstacionamentoDotnet6.Models.Pessoa", "Pessoas")
                        .WithOne("Carro")
                        .HasForeignKey("EstacionamentoDotnet6.Models.Carro", "PessoasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("EstacionamentoDotnet6.Models.Pessoa", b =>
                {
                    b.Navigation("Carro")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
