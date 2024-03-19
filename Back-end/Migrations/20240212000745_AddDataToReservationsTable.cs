using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class AddDataToReservationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CheckInDate", "CheckOutDate", "CustomerId", "GuestName", "RoomId" },
                values: new object[] { 1, new DateTime(2024, 2, 14, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4893), new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4906), 1, "Satyam Verma", 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CheckInDate", "CheckOutDate", "CustomerId", "GuestName", "RoomId" },
                values: new object[] { 2, new DateTime(2024, 2, 19, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912), new DateTime(2024, 2, 22, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912), 2, "Aryan Sharma", 2 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "CheckInDate", "CheckOutDate", "CustomerId", "GuestName", "RoomId" },
                values: new object[] { 3, new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4913), new DateTime(2024, 2, 20, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4914), 3, "Sneha Gupta", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3);
        }
    }
}
