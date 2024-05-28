﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240522044411_DB")]
    partial class DB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Model.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("RealeaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tracks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistID");

                    b.HasIndex("ProductID");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("WebAPI.Model.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int?>("FilmParticipated")
                        .HasColumnType("int");

                    b.Property<string>("HomeTown")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StyleOfMusic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalSong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("WebAPI.Model.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComicID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("chapterNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComicID");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("WebAPI.Model.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("Comics");
                });

            modelBuilder.Entity("WebAPI.Model.MusicVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductID");

                    b.ToTable("MusicVideos");
                });

            modelBuilder.Entity("WebAPI.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebAPI.Model.Single", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("ArtistName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("albumID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("ProductID");

                    b.HasIndex("albumID");

                    b.ToTable("Singles");
                });

            modelBuilder.Entity("WebAPI.Model._3D", b =>
                {
                    b.Property<int>("_3DID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("_3DID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("_3DID");

                    b.HasIndex("ProductID");

                    b.ToTable("3D");
                });

            modelBuilder.Entity("WebAPI.Model.Album", b =>
                {
                    b.HasOne("WebAPI.Model.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistID");

                    b.HasOne("WebAPI.Model.Product", "Product")
                        .WithMany("albums")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Model.Chapter", b =>
                {
                    b.HasOne("WebAPI.Model.Comic", "Comic")
                        .WithMany("Chapters")
                        .HasForeignKey("ComicID");

                    b.Navigation("Comic");
                });

            modelBuilder.Entity("WebAPI.Model.Comic", b =>
                {
                    b.HasOne("WebAPI.Model.Product", "Product")
                        .WithMany("Comics")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Model.MusicVideo", b =>
                {
                    b.HasOne("WebAPI.Model.Product", "Product")
                        .WithMany("musicVideos")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Model.Single", b =>
                {
                    b.HasOne("WebAPI.Model.Artist", null)
                        .WithMany("Singles")
                        .HasForeignKey("ArtistId");

                    b.HasOne("WebAPI.Model.Product", "Product")
                        .WithMany("singles")
                        .HasForeignKey("ProductID");

                    b.HasOne("WebAPI.Model.Album", "Album")
                        .WithMany("Singles")
                        .HasForeignKey("albumID");

                    b.Navigation("Album");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Model._3D", b =>
                {
                    b.HasOne("WebAPI.Model.Product", "Product")
                        .WithMany("_3D")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebAPI.Model.Album", b =>
                {
                    b.Navigation("Singles");
                });

            modelBuilder.Entity("WebAPI.Model.Artist", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Singles");
                });

            modelBuilder.Entity("WebAPI.Model.Comic", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("WebAPI.Model.Product", b =>
                {
                    b.Navigation("Comics");

                    b.Navigation("_3D");

                    b.Navigation("albums");

                    b.Navigation("musicVideos");

                    b.Navigation("singles");
                });
#pragma warning restore 612, 618
        }
    }
}
