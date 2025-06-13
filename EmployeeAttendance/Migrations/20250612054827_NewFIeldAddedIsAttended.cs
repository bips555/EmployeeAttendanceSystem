using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAttendance.Migrations
{
    /// <inheritdoc />
    public partial class NewFIeldAddedIsAttended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAttended",
                table: "EmployeeAttendanceRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAttended",
                table: "EmployeeAttendanceRecords");
        }
    }
}
