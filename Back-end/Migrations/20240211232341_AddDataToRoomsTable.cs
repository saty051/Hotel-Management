using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class AddDataToRoomsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Capacity", "HotelId", "Price", "RoomNumber" },
                values: new object[] { 1, 2, 1, 150.00m, "101" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Capacity", "HotelId", "Price", "RoomNumber" },
                values: new object[] { 2, 4, 1, 200.00m, "102" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Capacity", "HotelId", "Price", "RoomNumber" },
                values: new object[] { 3, 3, 2, 180.00m, "201" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);
        }
    }
}
