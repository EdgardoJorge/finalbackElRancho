﻿// <auto-generated />
using System;
using DbModel.ElRancho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElRancho.Migrations
{
    [DbContext(typeof(ElRanchoDbContext))]
    partial class ElRanchoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.13");

            modelBuilder.Entity("DbModel.ElRancho.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoMovil")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Administrador", "Persona");
                });

            modelBuilder.Entity("DbModel.ElRancho.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Redireccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("banner", "producto");
                });

            modelBuilder.Entity("DbModel.ElRancho.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoriaNombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categoria", "producto");
                });

            modelBuilder.Entity("DbModel.ElRancho.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RUC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoFijo")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonoMovil")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cliente", "persona");
                });

            modelBuilder.Entity("DbModel.ElRancho.DetallePedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PedidoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("DetallePedido", "pedido");
                });

            modelBuilder.Entity("DbModel.ElRancho.Error", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("ClassComponent")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("class_component");

                    b.Property<string>("Controller")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("controller");

                    b.Property<string>("Error1")
                        .HasColumnType("TEXT")
                        .HasColumnName("error");

                    b.Property<int>("ErrorCode")
                        .HasColumnType("INTEGER")
                        .HasColumnName("error_code");

                    b.Property<string>("FunctionName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("function_name");

                    b.Property<string>("Host")
                        .HasColumnType("TEXT")
                        .HasColumnName("host");

                    b.Property<string>("Ip")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("ip");

                    b.Property<int>("LineNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("line_number");

                    b.Property<string>("Method")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("method");

                    b.Property<string>("Request")
                        .HasColumnType("TEXT")
                        .HasColumnName("request");

                    b.Property<string>("StackTrace")
                        .HasColumnType("TEXT");

                    b.Property<short>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("status");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT")
                        .HasColumnName("url");

                    b.Property<string>("UserAgent")
                        .HasMaxLength(150)
                        .HasColumnType("TEXT")
                        .HasColumnName("user_agent");

                    b.HasKey("Id");

                    b.ToTable("error", "error");
                });

            modelBuilder.Entity("DbModel.ElRancho.EstadoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EstadoPedido", "pedido");
                });

            modelBuilder.Entity("DbModel.ElRancho.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdministradorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("FechaEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoEvento")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("DbModel.ElRancho.Oferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FechaFin")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FechaInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TituloOferta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Oferta", "producto");
                });

            modelBuilder.Entity("DbModel.ElRancho.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CodigoPostal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FechaPedido")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("FechaRecojo")
                        .HasColumnType("TEXT");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Pedido", "pedido");
                });

            modelBuilder.Entity("DbModel.ElRancho.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Activo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagen2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Imagen3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Producto", "producto");
                });

            modelBuilder.Entity("DbModel.ElRancho.TipoEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FormaEntrega")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoEntrega", "pedido");
                });

            modelBuilder.Entity("DbModel.ElRancho.Banner", b =>
                {
                    b.HasOne("DbModel.ElRancho.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModel.ElRancho.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbModel.ElRancho.DetallePedido", b =>
                {
                    b.HasOne("DbModel.ElRancho.Pedido", null)
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModel.ElRancho.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbModel.ElRancho.Oferta", b =>
                {
                    b.HasOne("DbModel.ElRancho.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbModel.ElRancho.Producto", null)
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
