﻿// <auto-generated />
using System;
using ConsoleApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp2.Migrations
{
    [DbContext(typeof(BookContext))]
    partial class BookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp2.Book", b =>
                {
                    b.Property<int>("idField")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("authorField");

                    b.Property<bool>("availableField");

                    b.Property<decimal>("barcodeField")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("bindingField");

                    b.Property<int>("categoryIdField");

                    b.Property<string>("currencyIdField");

                    b.Property<bool>("deliveryField");

                    b.Property<string>("descriptionField");

                    b.Property<string>("dimensionsField");

                    b.Property<int>("group_idField");

                    b.Property<string>("iSBNField");

                    b.Property<string>("languageField");

                    b.Property<long>("local_delivery_costField");

                    b.Property<bool>("manufacturer_warrantyField");

                    b.Property<string>("nameField");

                    b.Property<double>("oldpriceField");

                    b.Property<string>("page_extentField");

                    b.Property<bool>("pickupField");

                    b.Property<double>("priceField");

                    b.Property<string>("publisherField");

                    b.Property<string>("sales_notesField");

                    b.Property<string>("seriesField");

                    b.Property<bool>("storeField");

                    b.Property<string>("typeField");

                    b.Property<string>("urlField");

                    b.Property<decimal>("weightField");

                    b.Property<string>("yearField");

                    b.HasKey("idField");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConsoleApp2.Param", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookidField");

                    b.Property<string>("paramName");

                    b.Property<string>("paramUnit");

                    b.Property<string>("paramValue");

                    b.HasKey("Id");

                    b.HasIndex("BookidField");

                    b.ToTable("Params");
                });

            modelBuilder.Entity("ConsoleApp2.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookidField");

                    b.Property<string>("pictureUrl");

                    b.HasKey("Id");

                    b.HasIndex("BookidField");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ConsoleApp2.Param", b =>
                {
                    b.HasOne("ConsoleApp2.Book")
                        .WithMany("paramsField")
                        .HasForeignKey("BookidField");
                });

            modelBuilder.Entity("ConsoleApp2.Picture", b =>
                {
                    b.HasOne("ConsoleApp2.Book")
                        .WithMany("pictureField")
                        .HasForeignKey("BookidField");
                });
#pragma warning restore 612, 618
        }
    }
}