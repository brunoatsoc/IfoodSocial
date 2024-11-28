﻿// <auto-generated />
using IfoodSocial.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IfoodSocial.Service.Migrations
{
    [DbContext(typeof(IfoodSocialDBContext))]
    [Migration("20241127023513_Initial_1_5_4")]
    partial class Initial_1_5_4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("IfoodSocial.Core.Bairro", b =>
                {
                    b.Property<int>("Cod_Bairro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CidadeCod_Cidade")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cod_Cidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dcr_Bairro")
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_Bairro");

                    b.HasIndex("CidadeCod_Cidade");

                    b.ToTable("Bairros");
                });

            modelBuilder.Entity("IfoodSocial.Core.Cidade", b =>
                {
                    b.Property<int>("Cod_Cidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dcr_Cidade")
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_Cidade");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("IfoodSocial.Core.Localidade", b =>
                {
                    b.Property<int>("Cod_Localidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BairroCod_Bairro")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cod_Bairro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Dcr_Localidade")
                        .HasColumnType("TEXT");

                    b.HasKey("Cod_Localidade");

                    b.HasIndex("BairroCod_Bairro");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("IfoodSocial.Core.Bairro", b =>
                {
                    b.HasOne("IfoodSocial.Core.Cidade", "Cidade")
                        .WithMany("Bairros")
                        .HasForeignKey("CidadeCod_Cidade");

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("IfoodSocial.Core.Localidade", b =>
                {
                    b.HasOne("IfoodSocial.Core.Bairro", "Bairro")
                        .WithMany("Localidades")
                        .HasForeignKey("BairroCod_Bairro");

                    b.Navigation("Bairro");
                });

            modelBuilder.Entity("IfoodSocial.Core.Bairro", b =>
                {
                    b.Navigation("Localidades");
                });

            modelBuilder.Entity("IfoodSocial.Core.Cidade", b =>
                {
                    b.Navigation("Bairros");
                });
#pragma warning restore 612, 618
        }
    }
}
