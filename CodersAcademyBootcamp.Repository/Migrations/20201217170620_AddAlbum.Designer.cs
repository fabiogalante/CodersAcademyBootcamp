﻿// <auto-generated />
using System;
using CodersAcademyBootcamp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodersAcademyBootcamp.Repository.Migrations
{
    [DbContext(typeof(ContextApp))]
    [Migration("20201217170620_AddAlbum")]
    partial class AddAlbum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Account.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Album.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Backdrop")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Album.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Album.Album", b =>
                {
                    b.OwnsOne("CodersAcademyBootcamp.Domain.Album.ValueObject.Band", "Band", b1 =>
                        {
                            b1.Property<Guid>("AlbumId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Band");

                            b1.HasKey("AlbumId");

                            b1.ToTable("Albuns");

                            b1.WithOwner()
                                .HasForeignKey("AlbumId");
                        });

                    b.Navigation("Band");
                });

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Album.Music", b =>
                {
                    b.HasOne("CodersAcademyBootcamp.Domain.Album.Album", "Album")
                        .WithMany("Musics")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("CodersAcademyBootcamp.Domain.Album.ValueObject.Duration", "Duration", b1 =>
                        {
                            b1.Property<Guid>("MusicId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Valor")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Duration");

                            b1.HasKey("MusicId");

                            b1.ToTable("Music");

                            b1.WithOwner()
                                .HasForeignKey("MusicId");
                        });

                    b.Navigation("Album");

                    b.Navigation("Duration");
                });

            modelBuilder.Entity("CodersAcademyBootcamp.Domain.Album.Album", b =>
                {
                    b.Navigation("Musics");
                });
#pragma warning restore 612, 618
        }
    }
}
