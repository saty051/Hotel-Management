using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class UpdateReservationsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7280), new DateTime(2024, 2, 17, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7301) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7310), new DateTime(2024, 2, 22, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7311) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7314), new DateTime(2024, 2, 20, 11, 58, 28, 268, DateTimeKind.Local).AddTicks(7316) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
