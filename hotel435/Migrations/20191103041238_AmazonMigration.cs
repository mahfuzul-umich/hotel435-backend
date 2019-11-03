using Microsoft.EntityFrameworkCore.Migrations;

namespace hotel435.Migrations
{
    public partial class AmazonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Reservations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Reservations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "ConfirmationNumber",
                table: "Reservations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNum",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cvv",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpMonth",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpYear",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Reservations",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Reservations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Reservations",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ConfirmationNumber",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CreditCardNum",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Cvv",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ExpMonth",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ExpYear",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Reservations");

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });
        }
    }
}
