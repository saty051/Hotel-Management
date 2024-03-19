using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class UpdateCustomersSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4054), new DateTime(2024, 2, 17, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4083) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4094), new DateTime(2024, 2, 22, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4095) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4098), new DateTime(2024, 2, 20, 11, 56, 53, 166, DateTimeKind.Local).AddTicks(4100) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1931), new DateTime(2024, 2, 17, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1962), new DateTime(2024, 2, 22, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1964) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1967), new DateTime(2024, 2, 20, 11, 55, 56, 963, DateTimeKind.Local).AddTicks(1969) });
        }
    }
}
