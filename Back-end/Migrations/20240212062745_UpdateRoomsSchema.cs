using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class UpdateRoomsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2887), new DateTime(2024, 2, 17, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 2, 22, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2937), new DateTime(2024, 2, 20, 11, 57, 43, 956, DateTimeKind.Local).AddTicks(2938) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
