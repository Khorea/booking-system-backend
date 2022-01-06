﻿// <auto-generated />
using System;
using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingSystemBackend.Migrations
{
    [DbContext(typeof(BookingSystemContext))]
    [Migration("20220103115655_FirstCompleteModel")]
    partial class FirstCompleteModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookingSystemBackend.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Username");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("PersonId");

                    b.HasIndex("RouteId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CarType")
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<string>("TrainId1")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CarId");

                    b.HasIndex("TrainId1");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PersonId");

                    b.HasIndex("Username");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TrainId")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("RouteId");

                    b.HasIndex("TrainId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.HasKey("SeatId");

                    b.HasIndex("BookingId");

                    b.HasIndex("CarId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("ArriveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("StationId");

                    b.HasIndex("RouteId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Train", b =>
                {
                    b.Property<string>("TrainId")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("TrainId");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Booking", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Person", "Person")
                        .WithMany("Bookings")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Car", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Train", null)
                        .WithMany("Cars")
                        .HasForeignKey("TrainId1");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Person", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Route", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Train", "Train")
                        .WithMany("Routes")
                        .HasForeignKey("TrainId");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Seat", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingId");

                    b.HasOne("BookingSystemBackend.Models.Car", "Car")
                        .WithMany("Seats")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Station", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Route", "Route")
                        .WithMany("Stations")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Booking", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Car", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Person", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Route", b =>
                {
                    b.Navigation("Stations");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Train", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}
