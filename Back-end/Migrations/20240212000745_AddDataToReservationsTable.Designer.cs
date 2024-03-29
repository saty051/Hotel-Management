﻿// <auto-generated />
using System;
using HotelManagementApplication.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    [DbContext(typeof(HotelDBContext))]
    [Migration("20240212000745_AddDataToReservationsTable")]
    partial class AddDataToReservationsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelManagementApplication.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "emily@email.com",
                            FirstName = "Emily",
                            LastName = "Davis",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "james@email.com",
                            FirstName = "James",
                            LastName = "Miller",
                            Phone = "987-654-3210"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "sophia@email.com",
                            FirstName = "Sophia",
                            LastName = "Anderson",
                            Phone = "456-789-0123"
                        });
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("HotelId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Alice",
                            HotelId = 1,
                            LastName = "Johnson",
                            Position = "Manager"
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Bob",
                            HotelId = 1,
                            LastName = "Smith",
                            Position = "Front Desk Staff"
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Charlie",
                            HotelId = 2,
                            LastName = "Brown",
                            Position = "Housekeeping"
                        });
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            Address = "123 Main St",
                            Name = "Grand Plaza",
                            Rating = 4.5m
                        },
                        new
                        {
                            HotelId = 2,
                            Address = "456 Oak St",
                            Name = "Luxury Heaven",
                            Rating = 5.0m
                        },
                        new
                        {
                            HotelId = 3,
                            Address = "789 Beach Blvd",
                            Name = "Seaside Retreat",
                            Rating = 4.0m
                        });
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CheckInDate = new DateTime(2024, 2, 14, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4893),
                            CheckOutDate = new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4906),
                            CustomerId = 1,
                            GuestName = "Satyam Verma",
                            RoomId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CheckInDate = new DateTime(2024, 2, 19, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912),
                            CheckOutDate = new DateTime(2024, 2, 22, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912),
                            CustomerId = 2,
                            GuestName = "Aryan Sharma",
                            RoomId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CheckInDate = new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4913),
                            CheckOutDate = new DateTime(2024, 2, 20, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4914),
                            CustomerId = 3,
                            GuestName = "Sneha Gupta",
                            RoomId = 3
                        });
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomId = 1,
                            Capacity = 2,
                            HotelId = 1,
                            Price = 150.00m,
                            RoomNumber = "101"
                        },
                        new
                        {
                            RoomId = 2,
                            Capacity = 4,
                            HotelId = 1,
                            Price = 200.00m,
                            RoomNumber = "102"
                        },
                        new
                        {
                            RoomId = 3,
                            Capacity = 3,
                            HotelId = 2,
                            Price = 180.00m,
                            RoomNumber = "201"
                        });
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Employee", b =>
                {
                    b.HasOne("HotelManagementApplication.Models.Hotel", "Hotel")
                        .WithMany("Employees")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Reservation", b =>
                {
                    b.HasOne("HotelManagementApplication.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelManagementApplication.Models.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Room", b =>
                {
                    b.HasOne("HotelManagementApplication.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Hotel", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HotelManagementApplication.Models.Room", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
