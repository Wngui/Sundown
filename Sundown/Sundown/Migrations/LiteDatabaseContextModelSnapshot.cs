﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sundown.Models;

namespace Sundown.Migrations
{
    [DbContext(typeof(LiteDatabaseContext))]
    partial class LiteDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("Sundown.Models.Reservation", b =>
                {
                    b.Property<string>("ReservationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookingUser")
                        .HasColumnType("TEXT");

                    b.Property<string>("Drink")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestAmount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Menu")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ReservationTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ReservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Sundown.Models.Table", b =>
                {
                    b.Property<string>("TableId")
                        .HasColumnType("TEXT");

                    b.HasKey("TableId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = "65b4eccb-8ed7-4b0f-a022-6750d8d7aaaa"
                        },
                        new
                        {
                            TableId = "4ac9ea47-1864-4da2-a419-78bc13fb57b7"
                        },
                        new
                        {
                            TableId = "22924492-4cdf-4a89-9507-caee39adca8e"
                        },
                        new
                        {
                            TableId = "663ac989-965d-4967-9158-3cf552746787"
                        },
                        new
                        {
                            TableId = "5be7799a-5873-4392-ba8f-510aebd2c076"
                        },
                        new
                        {
                            TableId = "c7ea795a-b513-445a-bc58-1e447a94ef89"
                        },
                        new
                        {
                            TableId = "00ef3607-c0d9-4d61-b418-a8c7c5757012"
                        },
                        new
                        {
                            TableId = "ba8c9871-2eae-4df2-a017-faaaa6669e37"
                        },
                        new
                        {
                            TableId = "8f842ec3-d65a-443b-bb1d-8c11c6516313"
                        },
                        new
                        {
                            TableId = "52a5e6f8-bee2-4a09-bf6e-c60ff21eebff"
                        });
                });

            modelBuilder.Entity("Sundown.Models.TableReservation", b =>
                {
                    b.Property<string>("TableId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReservationId")
                        .HasColumnType("TEXT");

                    b.HasKey("TableId", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("TableReservation");
                });

            modelBuilder.Entity("Sundown.Models.TableReservation", b =>
                {
                    b.HasOne("Sundown.Models.Reservation", "Reservation")
                        .WithMany("TableReservations")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sundown.Models.Table", "Table")
                        .WithMany("TableReservations")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
