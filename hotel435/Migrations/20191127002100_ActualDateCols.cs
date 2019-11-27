using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel435.Migrations
{
    public partial class ActualDateCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckIn",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOut",
                table: "Reservations",
                nullable: true);
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
