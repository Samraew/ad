﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using o.Data;

#nullable disable

namespace o.Migrations
{
    [DbContext(typeof(oContext))]
    [Migration("20230502063915_base")]
    partial class @base
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("o.Models.ekin", b =>
                {
                    b.Property<int>("ekinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ekinAdı")
                        .HasColumnType("TEXT");

                    b.Property<string>("ekinFiyat")
                        .HasColumnType("TEXT");

                    b.Property<string>("ekinstock")
                        .HasColumnType("TEXT");

                    b.Property<int>("tarlaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ekinId");

                    b.HasIndex("tarlaId");

                    b.ToTable("ekin");
                });

            modelBuilder.Entity("o.Models.ilac", b =>
                {
                    b.Property<int>("ilacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ekinId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ilacAdı")
                        .HasColumnType("TEXT");

                    b.Property<string>("ilacFiyat")
                        .HasColumnType("TEXT");

                    b.Property<string>("ilacStock")
                        .HasColumnType("TEXT");

                    b.HasKey("ilacId");

                    b.HasIndex("ekinId");

                    b.ToTable("ilac");
                });

            modelBuilder.Entity("o.Models.tarla", b =>
                {
                    b.Property<int>("tarlaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TarlaAdı")
                        .HasColumnType("TEXT");

                    b.Property<string>("TarlaGenislik")
                        .HasColumnType("TEXT");

                    b.Property<string>("tarlaBolge")
                        .HasColumnType("TEXT");

                    b.HasKey("tarlaId");

                    b.ToTable("tarla");
                });

            modelBuilder.Entity("o.Models.ekin", b =>
                {
                    b.HasOne("o.Models.tarla", "tarla")
                        .WithMany("ekin")
                        .HasForeignKey("tarlaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tarla");
                });

            modelBuilder.Entity("o.Models.ilac", b =>
                {
                    b.HasOne("o.Models.ekin", "ekin")
                        .WithMany("ilac")
                        .HasForeignKey("ekinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ekin");
                });

            modelBuilder.Entity("o.Models.ekin", b =>
                {
                    b.Navigation("ilac");
                });

            modelBuilder.Entity("o.Models.tarla", b =>
                {
                    b.Navigation("ekin");
                });
#pragma warning restore 612, 618
        }
    }
}
