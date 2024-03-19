using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementApplication.Migrations
{
    public partial class AddDataToEmployeesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HotelId", "LastName", "Position" },
                values: new object[] { 1, "Alice", 1, "Johnson", "Manager" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HotelId", "LastName", "Position" },
                values: new object[] { 2, "Bob", 1, "Smith", "Front Desk Staff" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HotelId", "LastName", "Position" },
                values: new object[] { 3, "Charlie", 2, "Brown", "Housekeeping" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);
        }
    }
}
