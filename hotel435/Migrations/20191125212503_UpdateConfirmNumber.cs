using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel435.Migrations
{
    public partial class UpdateConfirmNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConfirmationNumber",
                table: "Reservations",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "ConfirmationNumber",
                table: "Reservations",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
