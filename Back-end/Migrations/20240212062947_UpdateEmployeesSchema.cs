using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class UpdateEmployeesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6165), new DateTime(2024, 2, 17, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6181) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6189), new DateTime(2024, 2, 22, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6191) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6194), new DateTime(2024, 2, 20, 11, 59, 46, 900, DateTimeKind.Local).AddTicks(6195) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
