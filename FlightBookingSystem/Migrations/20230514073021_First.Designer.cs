﻿// <auto-generated />
using System;
using FlightBookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    [DbContext(typeof(FlightDbContext))]
    [Migration("20230514073021_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ArrivalCityCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("BasePrice")
                        .HasColumnType("float");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("DepartureCityCode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FlightNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("FlightId");

                    b.HasIndex("AdminId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.FlightBooking", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ArrivalDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightBookingId")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("NoOfPassenger")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("FlightId");

                    b.HasIndex("UserId");

                    b.ToTable("FlightBookings");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Passenger", b =>
                {
                    b.Property<int>("PassengerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("FlightBookingId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("SeatAllocationId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("PassengerId");

                    b.HasIndex("FlightBookingId");

                    b.HasIndex("UserId");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("FlightBookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayemntTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.SeatAllocation", b =>
                {
                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<bool>("SeatAllocated")
                        .HasColumnType("bit");

                    b.Property<int>("SeatAllocationId")
                        .HasColumnType("int");

                    b.Property<int>("SeatAvailableId")
                        .HasColumnType("int");

                    b.Property<string>("SeatClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerId");

                    b.HasIndex("SeatAvailableId");

                    b.ToTable("SeatAllocations");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.SeatAvailable", b =>
                {
                    b.Property<int>("SeatAvailableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatAvailableId"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("SeatBooked")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeats")
                        .HasMaxLength(800)
                        .HasColumnType("int");

                    b.HasKey("SeatAvailableId");

                    b.HasIndex("FlightId");

                    b.ToTable("SeatAvailables");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("UserId");

                    b.HasIndex("AdminId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Flight", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.Admin", "Admin")
                        .WithMany("Flight")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.FlightBooking", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.Flight", "Flight")
                        .WithMany("FlightBooking")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBookingSystem.Models.Domain.Payment", "Payment")
                        .WithOne("FlightBooking")
                        .HasForeignKey("FlightBookingSystem.Models.Domain.FlightBooking", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBookingSystem.Models.Domain.User", "User")
                        .WithMany("FlightBooking")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Payment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Passenger", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.FlightBooking", "FlightBooking")
                        .WithMany("Passenger")
                        .HasForeignKey("FlightBookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBookingSystem.Models.Domain.User", "User")
                        .WithMany("Passenger")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlightBooking");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Payment", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.User", "User")
                        .WithMany("Payment")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.SeatAllocation", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.Passenger", "Passenger")
                        .WithOne("SeatAllocation")
                        .HasForeignKey("FlightBookingSystem.Models.Domain.SeatAllocation", "PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlightBookingSystem.Models.Domain.SeatAvailable", "SeatAvailable")
                        .WithMany("SeatAllocation")
                        .HasForeignKey("SeatAvailableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("SeatAvailable");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.SeatAvailable", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.Flight", "Flight")
                        .WithMany("SeatAvailable")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.User", b =>
                {
                    b.HasOne("FlightBookingSystem.Models.Domain.Admin", "Admin")
                        .WithMany("User")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Admin", b =>
                {
                    b.Navigation("Flight");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Flight", b =>
                {
                    b.Navigation("FlightBooking");

                    b.Navigation("SeatAvailable");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.FlightBooking", b =>
                {
                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Passenger", b =>
                {
                    b.Navigation("SeatAllocation")
                        .IsRequired();
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.Payment", b =>
                {
                    b.Navigation("FlightBooking")
                        .IsRequired();
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.SeatAvailable", b =>
                {
                    b.Navigation("SeatAllocation");
                });

            modelBuilder.Entity("FlightBookingSystem.Models.Domain.User", b =>
                {
                    b.Navigation("FlightBooking");

                    b.Navigation("Passenger");

                    b.Navigation("Payment");
                });
#pragma warning restore 612, 618
        }
    }
}
