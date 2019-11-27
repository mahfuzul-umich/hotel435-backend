using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel435.Migrations
{
    public partial class AddActualCheckInOutProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckIn",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOut",
                table: "Reservations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCheckIn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ActualCheckOut",
                table: "Reservations");
        }
    }
}
