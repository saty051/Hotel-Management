using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class UpdateHotelsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(141), new DateTime(2024, 2, 17, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(158), new DateTime(2024, 2, 22, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(159) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(160), new DateTime(2024, 2, 20, 5, 53, 44, 273, DateTimeKind.Local).AddTicks(161) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 14, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4893), new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4906) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 19, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912), new DateTime(2024, 2, 22, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4912) });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                columns: new[] { "CheckInDate", "CheckOutDate" },
                values: new object[] { new DateTime(2024, 2, 17, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4913), new DateTime(2024, 2, 20, 5, 37, 45, 506, DateTimeKind.Local).AddTicks(4914) });
        }
    }
}
