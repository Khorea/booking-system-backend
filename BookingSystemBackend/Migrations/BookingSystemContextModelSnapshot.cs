﻿// <auto-generated />
using System;
using BookingSystemBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingSystemBackend.Migrations
{
    [DbContext(typeof(BookingSystemContext))]
    partial class BookingSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(20)");

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

                    b.HasKey("BookingId");

                    b.HasIndex("PersonId");

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

                    b.HasKey("CarId");

                    b.HasIndex("TrainId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Connection", b =>
                {
                    b.Property<int>("StartStationId")
                        .HasColumnType("int");

                    b.Property<int>("EndStationId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("ArriveTime")
                        .HasColumnType("time(7)");

                    b.Property<TimeSpan?>("DepartureTime")
                        .HasColumnType("time(7)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("Line")
                        .HasColumnType("int");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.HasKey("StartStationId", "EndStationId", "TrainId");

                    b.HasIndex("EndStationId");

                    b.HasIndex("TrainId");

                    b.ToTable("Connections");
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PersonId");

                    b.HasIndex("Username");

                    b.ToTable("People");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Seat", b =>
                {
                    b.Property<int>("SeatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.HasKey("SeatId");

                    b.HasIndex("CarId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Station", b =>
                {
                    b.Property<int>("StationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StationId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.SubBooking", b =>
                {
                    b.Property<int>("SubBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("Date");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<int>("FirstStationId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SeatId")
                        .HasColumnType("int");

                    b.Property<int>("SecondStationId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("SubBookingId");

                    b.HasIndex("BookingId");

                    b.HasIndex("FirstStationId");

                    b.HasIndex("SeatId");

                    b.HasIndex("SecondStationId");

                    b.HasIndex("TrainId");

                    b.ToTable("SubBookings");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Train", b =>
                {
                    b.Property<int>("TrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("TrainType")
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

                    b.Navigation("Person");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Car", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Train", null)
                        .WithMany("Cars")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Connection", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Station", "EndStation")
                        .WithMany()
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Station", "StartStation")
                        .WithMany()
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Train", "Train")
                        .WithMany("Connections")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("EndStation");

                    b.Navigation("StartStation");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Person", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Username");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Seat", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Car", "Car")
                        .WithMany("Seats")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.SubBooking", b =>
                {
                    b.HasOne("BookingSystemBackend.Models.Booking", null)
                        .WithMany("SubBooking")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Station", "FirstStation")
                        .WithMany()
                        .HasForeignKey("FirstStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Station", "SecondStation")
                        .WithMany()
                        .HasForeignKey("SecondStationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookingSystemBackend.Models.Train", "Train")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstStation");

                    b.Navigation("Seat");

                    b.Navigation("SecondStation");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Booking", b =>
                {
                    b.Navigation("SubBooking");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Car", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Person", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BookingSystemBackend.Models.Train", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Connections");
                });
#pragma warning restore 612, 618
        }
    }
}
