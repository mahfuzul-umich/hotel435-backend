using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel435.Migrations
{
    public partial class RemoveDateCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCheckIn",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ActualCheckOut",
                table: "Reservations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckIn",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOut",
                table: "Reservations",
                type: "datetime2",
                nullable: true);
        }
    }
}
