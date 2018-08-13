﻿// <auto-generated />
using System;
using ConsoleApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20180813122643_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp2.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ConsoleApp2.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int?>("Sales_noteId");

                    b.Property<bool>("available");

                    b.Property<decimal>("barcode")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("binding");

                    b.Property<int>("categoryId");

                    b.Property<string>("currencyId");

                    b.Property<bool>("delivery");

                    b.Property<string>("description");

                    b.Property<string>("dimensions")
                        .HasMaxLength(70);

                    b.Property<int>("group_id");

                    b.Property<string>("iSBN");

                    b.Property<int>("languageId");

                    b.Property<long>("local_delivery_cost");

                    b.Property<bool>("manufacturer_warranty");

                    b.Property<string>("name");

                    b.Property<double>("oldprice");

                    b.Property<string>("page_extent");

                    b.Property<bool>("pickup");

                    b.Property<double>("price");

                    b.Property<int>("publisherId");

                    b.Property<int>("sales_notesId");

                    b.Property<int>("seriesId");

                    b.Property<bool>("store");

                    b.Property<string>("type")
                        .HasMaxLength(70);

                    b.Property<string>("url");

                    b.Property<decimal>("weight");

                    b.Property<string>("year");

                    b.HasKey("id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Sales_noteId");

                    b.HasIndex("languageId");

                    b.HasIndex("publisherId");

                    b.HasIndex("seriesId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConsoleApp2.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ConsoleApp2.Param", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bookid");

                    b.Property<string>("paramName");

                    b.Property<string>("paramUnit");

                    b.Property<string>("paramValue");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.ToTable("Params");
                });

            modelBuilder.Entity("ConsoleApp2.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Bookid");

                    b.Property<string>("pictureUrl");

                    b.HasKey("Id");

                    b.HasIndex("Bookid");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ConsoleApp2.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("ConsoleApp2.Sales_note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Sales_Notes");
                });

            modelBuilder.Entity("ConsoleApp2.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("ConsoleApp2.Book", b =>
                {
                    b.HasOne("ConsoleApp2.Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleApp2.Sales_note")
                        .WithMany("Books")
                        .HasForeignKey("Sales_noteId");

                    b.HasOne("ConsoleApp2.Language")
                        .WithMany("Books")
                        .HasForeignKey("languageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleApp2.Publisher")
                        .WithMany("Books")
                        .HasForeignKey("publisherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ConsoleApp2.Series")
                        .WithMany("Books")
                        .HasForeignKey("seriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ConsoleApp2.Param", b =>
                {
                    b.HasOne("ConsoleApp2.Book")
                        .WithMany("_params")
                        .HasForeignKey("Bookid");
                });

            modelBuilder.Entity("ConsoleApp2.Picture", b =>
                {
                    b.HasOne("ConsoleApp2.Book")
                        .WithMany("picture")
                        .HasForeignKey("Bookid");
                });
#pragma warning restore 612, 618
        }
    }
}